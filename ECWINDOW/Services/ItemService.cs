using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecw.ViewModels;
using ecw.Data;

namespace ecw.Services {

    //  商品に関する処理本体（ビジネスロジック）を記述するクラス
    public class ItemService : CommonService{

        public ItemService(ecwContext context) : base(context) {

        }

        public List<Item> getItemList(string k, string c1, string c2, string min, string max) {
            // 直近1000件受注
            var subquery1 = _context.TtOrderHistories
                .OrderByDescending(x => x.OrderDate)
                .GroupBy(x => new { x.OrderNo, x.OrderDate })
                .Select(x => new {
                    OrderNo = x.Key.OrderNo,
                    OrderDate = x.Key.OrderDate
                })
                .Take(1000);

            // 商品別受注計
            var subquery2 = _context.TtOrderHistories
                // サブクエリ1を内部結合
                .Join(subquery1, x => x.OrderNo, y => y.OrderNo, (x, y) => new { OrderQuantity = x.OrderQuantity, ItemCd = x.ItemCd })

                // 商品マスタを左外部結合
                .GroupJoin(_context.TmItems, x => x.ItemCd, y => y.ItemCd, (x, tmpy) => new { OrderQuantity = x.OrderQuantity, ItemCd = x.ItemCd, tmpy })
                // 結合後の列 I(商品マスタ）、B（ブランドマスタ）、IP（商品単価マスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    OrderQuantity = x.OrderQuantity,
                    ItemCd = x.ItemCd,
                    I = y
                })

                // 商品在庫マスタを内部結合
                .Join(_context.TmItemStocks, x => x.I.ItemCd, y => y.ItemCd, (x, y) => new {
                    OrderQuantity = x.OrderQuantity,
                    ItemCd = x.ItemCd,
                    I = x.I,
                    StockNum = y.StockNum
                })
                // 商品在庫があるものに絞り込み
                .Where(x => x.StockNum > 0)
                // 商品ステータスが「取扱終了」のものを除外
                .Where(x => x.I.StatusCd != "99")
                // 商品コード毎に集計
                .GroupBy(x => x.ItemCd)
                // 最終的な列情報に整形
                .Select(x => new {
                    OrderSum = x.Sum(y => y.OrderQuantity),
                    ItemCd = x.Key
                });



            // 商品を取得するメインクエリ
            var items = _context.TmItems

                // ブランドマスタと外部結合、
                .GroupJoin(_context.TmBrands, x => x.BrandCd, y => y.BrandCd, (x, tmpy) => new { I = x, tmpy })
                // 結合後の列 I(商品マスタ）、B（ブランドマスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    B = y
                })

                //// 商品単価マスタと外部結合
                //.GroupJoin(_context.TmItemPrices, x => x.I.ItemCd, y => y.ItemCd, (x, tmpy) => new { I = x.I, B = x.B, tmpy })
                //// 結合後の列 I(商品マスタ）、B（ブランドマスタ）、IP（商品単価マスタ）
                //.SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                //    I = x.I,
                //    B = x.B,
                //    IP = y
                //})

                // 商品単価マスタを内部結合
                .Join(_context.TmItemPrices, x => x.I.ItemCd, y => y.ItemCd, (x, y) => new { I = x.I, B = x.B, IP = y })

                // 商品在庫マスタと外部結合 
                .GroupJoin(_context.TmItemStocks, x => x.I.ItemCd, y => y.ItemCd, (x, tmpy) => new { I = x.I, B = x.B, IP = x.IP, tmpy })
                // 結合後の列 I(商品マスタ）、B（ブランドマスタ）、IP（商品単価マスタ）、STK（商品在庫マスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    B = x.B,
                    IP = x.IP,
                    STK = y
                })

                // 商品ステータスマスタと外部結合 
                .GroupJoin(_context.TmItemStatuses, x => x.I.StatusCd, y => y.StatusCd, (x, tmpy) => new { I = x.I, B = x.B, IP = x.IP, STK = x.STK, tmpy })
                // 結合後の列 I(商品マスタクラス）、B（ブランドマスタクラス）、IP（商品単価マスタクラス）、STK（商品在庫マスタ）、STA（商品ステータスマスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    B = x.B,
                    IP = x.IP,
                    STK = x.STK,
                    STA = y
                })

                // サブクエリを左外部結合
                .GroupJoin(subquery2, x => x.I.ItemCd, y => y.ItemCd, (x, tmpy) => new { I = x.I, B = x.B, IP = x.IP, STK = x.STK, STA = x.STA, tmpy })
                // 外部結合をする際にGroupByとセットで必要になる処理
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    B = x.B,
                    IP = x.IP,
                    STK = x.STK,
                    STA = x.STA,
                    OrderSum = y.OrderSum
                })

                // カテゴリ検索。リクエストパラメータが入ってない場合は空文字の部分一致
                .Where(x => x.I.ItemCategory1Cd.Contains(c1 ?? ""))
                .Where(x => x.I.ItemCategory2Cd.Contains(c2 ?? ""))

                // 結合して手に入れた商品別受注計を元に並び替え
                .OrderByDescending(x => x.OrderSum)

                // Itemクラスに格納
                .Select(x => new Item {

                    // 商品コード
                    itemCd = x.I.ItemCd
                    // 商品名1
                    ,
                    itemName1 = x.I.ItemName1
                    // 商品名2
                    ,
                    itemName2 = x.I.ItemName2
                    // 商品画像1
                    ,
                    itemImage1 = x.I.ItemImage1
                    // ブランド名
                    ,
                    brandName = x.B.BrandName
                    // 税抜下代単価
                    ,
                    wholesalePrice = (int)x.IP.NoTaxWholesalePrice
                    // 商品在庫数
                    ,
                    stockNum = (int)x.STK.StockNum
                    // ステータスコード
                    ,
                    statusCd = x.I.StatusCd
                    // ステータス名
                    ,
                    statusName = x.STA.StatusName

                })
            ;

            //　キーワード検索
            if (k != null && yokeinaMethod(k).Equals("")) {
                items = items.Where(i => (i.itemName1 + i.itemName2 + i.brandName).Contains(k));
            }

            //　価格帯検索
            if (min != null && min != "") {
                items = items.Where(i => i.wholesalePrice > Convert.ToInt64(min));
            }
            if (max != null && max != "") {
                items = items.Where(i => i.wholesalePrice < long.Parse(max));
            }

            return items.ToList();
        }


        // 商品詳細取得
        public Item getItemInfo(string item_cd) {

            Item item = _context.TmItems

                // 商品単価マスタを内部結合
                .Join(_context.TmItemPrices, x => x.ItemCd, y => y.ItemCd, (x, y) => new {
                    I = x,
                    P = y
                })

                // ブランドマスタを左外部結合、
                .GroupJoin(_context.TmBrands, x => x.I.BrandCd, y => y.BrandCd, (x, tmpy) => new { I = x.I, P = x.P, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = y
                })

                // 商品在庫マスタを左外部結合
                .GroupJoin(_context.TmItemStocks, x => x.I.ItemCd, y => y.ItemCd, (x, tmpy) => new { I = x.I, P = x.P, B = x.B, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）、STK（商品在庫マスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = y
                })

                // 商品ステータスマスタを左外部結合
                .GroupJoin(_context.TmItemStatuses, x => x.I.StatusCd, y => y.StatusCd, (x, tmpy) => new { I = x.I, P = x.P, B = x.B, STK = x.STK, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）、STK（商品在庫マスタ）、STA（商品ステータスマスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = x.STK,
                    STA = y
                })

                // 商品分類1マスタを左外部結合
                .GroupJoin(_context.TmItemCategory1s, x => x.I.ItemCategory1Cd, y => y.ItemCategory1Cd, (x, tmpy) => new { I = x.I, P = x.P, B = x.B, STK = x.STK, STA = x.STA, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）、STK（商品在庫マスタ）、STA（商品ステータスマスタ）、IC1（商品分類１マスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = x.STK,
                    STA = x.STA,
                    IC1 = y
                })

                // 商品分類2マスタを左外部結合
                .GroupJoin(_context.TmItemCategory2s, x => x.I.ItemCategory2Cd, y => y.ItemCategory2Cd, (x, tmpy) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = x.STK,
                    STA = x.STA,
                    IC1 = x.IC1,
                    tmpy
                })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）、STK（商品在庫マスタ）、
                // STA（商品ステータスマスタ）、IC1（商品分類１マスタ）、IC2（商品分類２マスタ)
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = x.STK,
                    STA = x.STA,
                    IC1 = x.IC1,
                    IC2 = y
                })

                // リクエストパラメータ　商品コード
                .Where(x => x.I.ItemCd == item_cd)
                //　表示フラグがオンか
                .Where(x => x.I.DispFlg == "1")

                // Itemに格納
                .Select(x => new Item {
                    // 商品コード
                    itemCd = x.I.ItemCd
                    // 商品名1
                    ,itemName1 = x.I.ItemName1 ?? ""
                    // 商品名2
                    ,itemName2 = x.I.ItemName2 ?? ""
                    // 商品画像1
                    ,itemImage1 = x.I.ItemImage1 ?? "noimage.png"
                    // ブランド名
                    ,brandName = x.B.BrandName ?? ""
                    // 税抜下代単価
                    ,wholesalePrice = (int)x.P.NoTaxWholesalePrice
                    // 商品在庫数
                    ,stockNum = (int)x.STK.StockNum
                    // ステータスコード
                    ,statusCd = x.I.StatusCd
                    // ステータス名
                    ,statusName = x.STA.StatusName
                    // 商品分類1コード
                    ,itemCategory1Cd = x.I.ItemCategory1Cd
                    // 商品分類1名
                    ,itemCategory1Name = x.IC1.ItemCategory1Name
                    // 商品分類2コード
                    ,itemCategory2Cd = x.I.ItemCategory2Cd
                    // 商品分類2名
                    ,itemCategory2Name = x.IC2.ItemCategory2Name
                    // 型番
                    ,modelNumber = x.I.ModelNumber
                    // JANコード
                    ,janCd = x.I.JanCd
                })
                // 最初の1件を取得指定＆クエリ発動
                .First();

            return item;
        }


        // お勧め商品取得
        public List<Item> getRecommendations(string item_cd,string item_category1_cd) {
            
            List<Item> recomms = _context.TmItems

                // 商品単価マスタを内部結合
                .Join(_context.TmItemPrices, x => x.ItemCd, y => y.ItemCd, (x, y) => new {
                    I = x,
                    P = y
                })

                // ブランドマスタを左外部結合、
                .GroupJoin(_context.TmBrands, x => x.I.BrandCd, y => y.BrandCd, (x, tmpy) => new { I = x.I, P = x.P, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = y
                })

                // 商品在庫マスタを左外部結合
                .GroupJoin(_context.TmItemStocks, x => x.I.ItemCd, y => y.ItemCd, (x, tmpy) => new { I = x.I, P = x.P, B = x.B, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）、STK（商品在庫マスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = y
                })

                // 商品ステータスマスタを左外部結合
                .GroupJoin(_context.TmItemStatuses, x => x.I.StatusCd, y => y.StatusCd, (x, tmpy) => new { I = x.I, P = x.P, B = x.B, STK = x.STK, tmpy })
                // 結合後の列 I(商品マスタ）、P（商品単価マスタ）、B（ブランドマスタ）、STK（商品在庫マスタ）、STA（商品ステータスマスタ）
                .SelectMany(x => x.tmpy.DefaultIfEmpty(), (x, y) => new {
                    I = x.I,
                    P = x.P,
                    B = x.B,
                    STK = x.STK,
                    STA = y
                })

                // カテゴリが同じ商品に限定
                .Where(x => x.I.ItemCategory1Cd == item_category1_cd)
                // 表示フラグがオン
                .Where(x => x.I.DispFlg == "1")
                // ステータスが「販売中」
                .Where(x => x.STA.StatusCd == "00")
                // 在庫が有る
                .Where(x => x.STK.StockNum > 0)
                // 画面に表示中の商品と同じ物を除外
                .Where(x => x.I.ItemCd != item_cd)

                // Itemに格納
                .Select(x => new Item {
                    // 商品コード
                    itemCd = x.I.ItemCd
                    // 商品名1
                    ,
                    itemName1 = x.I.ItemName1 ?? ""
                    // 商品名2
                    ,
                    itemName2 = x.I.ItemName2 ?? ""
                    // 商品画像1
                    ,
                    itemImage1 = x.I.ItemImage1 ?? "noimage.png"
                    // ブランド名
                    ,
                    brandName = x.B.BrandName ?? ""
                    // 税抜下代単価
                    ,
                    wholesalePrice = (int)x.P.NoTaxWholesalePrice
                    // 商品在庫数
                    ,
                    stockNum = (int)x.STK.StockNum
                    // ステータスコード
                    ,
                    statusCd = x.I.StatusCd
                    // ステータス名
                    ,
                    statusName = x.STA.StatusName
                })

                // ランダムソート
                .OrderBy(x => Guid.NewGuid())
                // 先頭6件を取得
                .Take(6)
                // リスト化
                .ToList();

            return recomms;
        }
    }
}
