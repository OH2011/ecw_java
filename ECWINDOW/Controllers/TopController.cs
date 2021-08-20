using Microsoft.AspNetCore.Mvc;
using ecw.Data;
using ecw.ViewModels;
using ecw.Services;

namespace ecw.Controllers
{
    //  トップ画面コントローラ
    //  localhost//Top/  のURLに来たリクエストを受け付ける
    public class TopController : BaseController
    {
        public TopController(ecwContext context) : base(context) {
        }

        // localhost//Top（/index）　に来たリクエストを処理する
        public IActionResult Index()
        {
            // 商品分類サービスのインスタンス生成
            ItemCategoryService itemCategoryService = new ItemCategoryService(_context);

            // ビューへ渡すデータをビューモデルに格納
            var model = new ItemViewModel {
                itemCategory1List = itemCategoryService.getItemCategory1s()
                , itemCategory2List = itemCategoryService.getItemCategory2s()
                , common_ss = getCommonSystemSetting()
                , common_msg = getCommonMessage()
                , rd = new System.Random().Next(0, 10)
            };
                
            // Top.cshtmlへ遷移、modelオブジェクトを渡す
            return View("Top", model);
            
        }
    }
}
