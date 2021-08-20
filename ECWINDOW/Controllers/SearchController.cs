using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using ecw.Data;
using Microsoft.EntityFrameworkCore;
using ecw.ViewModels;
using ecw.Models;
using System.Collections.Generic;
using ecw.Services;

namespace ecw.Controllers {

    //  商品検索コントローラ。
    //  localhost//Search/　のURLでのリクエストを処理する
    public class SearchController : BaseController {
        public SearchController(ecwContext context) : base(context) {
        }

        //　localhost//Search（/index）のURLに来たリクエストを処理するメソッド
        public IActionResult Index(string k, string c1, string c2, string min, string max, int p=1) {

            // 商品分類サービスのインスタンス生成
            ItemCategoryService itemCategoryService = new ItemCategoryService(_context);

            // 商品サービスのインスタンス生成
            ItemService itemService = new ItemService(_context);

            // 画面左側で表示する商品分類リスト
            List<TmItemCategory1> itemCategory1List = itemCategoryService.getItemCategory1s();
            List<TmItemCategory2> itemCategory2List = itemCategoryService.getItemCategory2s();

            // 商品分類検索時に表示する商品分類名
            TmItemCategory1 currentCategory1 = itemCategoryService.getCurrentItemCategory1(c1);
            TmItemCategory2 currentCategory2 = itemCategoryService.getCurrentItemCategory2(c1,c2);

            // 商品検索結果を取得
            var items = itemService.getItemList(k, c1, c2, min, max);

            // 検索ヒット数を変数に代入
            int count = items.Count();

            //  ページのオフセットを反映
            items = items.Skip((p - 1) * 20)
            //  1ページに表示する項目数に限定
                    .Take(20).ToList();


            // ビューへ渡すデータをビューモデルに格納
            var model = new ItemViewModel {
                k = k,
                c1 = c1,
                c2 = c2,
                min = min,
                max = max,
                p = p,
                count = count,
                currentCategory1 = currentCategory1,
                currentCategory2 = currentCategory2,
                itemCategory1List = itemCategory1List,
                itemCategory2List = itemCategory2List,
                common_ss = getCommonSystemSetting(),
                common_msg = getCommonMessage(),
                items = items
                ,
                rd = new System.Random().Next(0, 10)
            };

            // itemlist.cshtmlへ遷移、modelオブジェクトを渡す
            return View("itemlist", model);

        }
    }
}
