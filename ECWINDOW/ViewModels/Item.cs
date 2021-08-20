namespace ecw.ViewModels
{
    // 一つ一つの商品情報を保持するためのクラス
    public class Item
    {
        
        // 商品コード
        public string itemCd { get; set; }
        // 商品名1
        public string itemName1 { get; set; }
        // 商品名2
        public string itemName2 { get; set; }
        // 商品画像1URL
        public string itemImage1 { get; set; }
        // ブランド名
        public string brandName { get; set; }
        // 商品下代単価
        public int wholesalePrice { get; set; }
        // 商品在庫数
        public int stockNum { get; set; }
        // 商品状態コード
        public string statusCd { get; set; }
        // 商品状態名
        public string statusName { get; set; }
        // 商品カテゴリ1コード
        public string itemCategory1Cd { get; set; }
        // 商品カテゴリ1名
        public string itemCategory1Name { get; set; }
        // 商品カテゴリ2コード
        public string itemCategory2Cd { get; set; }
        // 商品カテゴリ2名
        public string itemCategory2Name { get; set; }
        // 型番
        public string modelNumber { get; set; }
        // JANコード
        public string janCd { get; set; }
        // 商品詳細
        public string description { get; set; }
    }
}
