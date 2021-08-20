using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ecw.Data;
using ecw.ViewModels;
using ecw.Models;
using ecw.Services;

namespace ecw.Controllers
{
    public class DetailController : BaseController
    {
        public DetailController(ecwContext context) : base(context) {
        }

        public IActionResult Index(string item_cd)
        {
            // 商品分類サービスのインスタンス生成
            ItemCategoryService itemCategoryService = new ItemCategoryService(_context);

            // 商品サービスのインスタンス生成
            ItemService itemService = new ItemService(_context);

            // カテゴリ一覧を自作のCategoryクラスに格納してリスト化してビューに渡す
            List<TmItemCategory1> itemCategory1List = itemCategoryService.getItemCategory1s();
            List<TmItemCategory2> itemCategory2List = itemCategoryService.getItemCategory2s();

            Item item = new ItemService(_context).getItemInfo(item_cd);

            // ビューへ渡す為のモデルに格納
            var model = new ItemViewModel { 
                itemCategory1List = itemCategory1List
                ,itemCategory2List = itemCategory2List
                ,common_ss = getCommonSystemSetting()
                ,common_msg = getCommonMessage()
                ,item = item
                ,items = itemService.getRecommendations(item_cd,item.itemCategory1Cd)
                ,
                rd = new System.Random().Next(0, 10)
            };

            // ItemDetail.cshtmlへ遷移、modelオブジェクトを渡す
            return View("ItemDetail", model);
            
        }
    }
}
