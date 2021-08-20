using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecw.Data;
using ecw.Models;

namespace ecw.Services{

    //  商品分類に関する処理本体（ビジネスロジック）を記述するクラス
    public class ItemCategoryService : CommonService{
        
        public ItemCategoryService(ecwContext context) : base(context) { }

        //  商品分類1リスト取得
        public List<TmItemCategory1> getItemCategory1s() {
            var category1s = _context.TmItemCategory1s.ToList();

            return category1s;
        }

        // 　商品分類2リスト取得
        public List<TmItemCategory2> getItemCategory2s() {
            var category2s = _context.TmItemCategory2s.ToList();

            return category2s;
        }

        //　現在商品分類1情報取得
        public TmItemCategory1 getCurrentItemCategory1(string itemCategory1Cd) {
            if (itemCategory1Cd == null || itemCategory1Cd == "") {
                return null;
            }

            TmItemCategory1 itemCategory1 = _context.TmItemCategory1s.Where(c => c.ItemCategory1Cd == itemCategory1Cd).First();

            return itemCategory1;
        }

        //  現在商品分類2情報取得
        public TmItemCategory2 getCurrentItemCategory2(string itemCategory1Cd,string itemCategory2Cd) {

            if (itemCategory2Cd == null || itemCategory2Cd == "") {
                return null;
            }

            TmItemCategory2 itemCategory2 = _context.TmItemCategory2s
                .Where(c => c.ItemCategory1Cd == itemCategory1Cd && c.ItemCategory2Cd == itemCategory2Cd).First();

            return itemCategory2;
        }
    }
}
