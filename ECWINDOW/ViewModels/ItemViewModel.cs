using System.Collections.Generic;
using ecw.Models;

namespace ecw.ViewModels
{
    // コントローラからビューへデータを渡す入れ物のクラス
    public class ItemViewModel
    {
        // 左のカテゴリ一覧へ渡すリスト
        public List<TmItemCategory1> itemCategory1List { get; set; }
        public List<TmItemCategory2> itemCategory2List { get; set; }

        // 商品のリスト(検索商品一覧、お勧め商品）
        public List<Item> items { get; set; }
        // 検索ヒット数
        public int count { get; set; }
        // 詳細商品
        public Item item { get; set; }

        // リクエスト情報を保持するためのパラメータ
        public string k { get; set; }
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string min { get; set; }
        public string max { get; set; }
        public int p { get; set; }

        // カテゴリ検索時に表示するカテゴリ情報
        public TmItemCategory1 currentCategory1 { get; set; }
        public TmItemCategory2 currentCategory2 { get; set; }

        // システム設定情報
        public Dictionary<string, string> common_ss { get; set; }
        // メッセージ情報
        public Dictionary<string, string> common_msg { get; set; }

        // ランダム数値
        public int rd { get; set; }

    }
}
