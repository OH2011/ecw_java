using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ecw.Models;
using ecw.Data;


namespace ecw.Controllers {

    //  基底Controllerクラス
    public class BaseController : Controller {

        protected readonly ecwContext _context;

        public BaseController(ecwContext context) {
            _context = context;
        }


        // システム設定一括取得
        protected Dictionary<string,string> getCommonSystemSetting() {
            // セッションからシステム設定情報を取得
            // SessionExtensions.csに作成した拡張メソッドを使用
            Dictionary<string,string> common_ss = HttpContext.Session.GetObject("common_ss");

            // セッションにシステム設定情報が存在しなければDBから取得
            if (common_ss.Count <= 0) {
                var systemSettings = _context.TmSystemSettings.ToList();

                // Listで取ってきたシステム設定情報を辞書に代入
                foreach (TmSystemSetting ss in systemSettings) {
                    if (ss.SsCd != null && ss.SsName != null) {
                        common_ss.Add(ss.SsCd, ss.SsName);
                    }
                }
            }
            // セッションにシステム設定情報を格納する
            HttpContext.Session.SetObject("common_ss", common_ss);

            return common_ss;
        }

        // メッセージ一括取得
        protected Dictionary<string, string> getCommonMessage() {
            // セッションからメッセージ情報を取得
            // SessionExtensions.csに作成した拡張メソッドを使用
            Dictionary<string,string> common_msg = HttpContext.Session.GetObject("common_msg");

            // セッションにメッセージ情報が存在しなければDBから取得
            if (common_msg.Count <= 0) {
                var messages = _context.TmMessages.ToList();

                // Listで取ってきたメッセージ情報を辞書に代入
                foreach (TmMessage msg in messages) {
                    if (msg.MsgCd != null && msg.MsgVal != null) {
                        common_msg.Add(msg.MsgCd,msg.MsgVal);
                    }
                }
            }
            // セッションにメッセージ情報を格納する
            HttpContext.Session.SetObject("common_msg", common_msg);

            return common_msg;
        }

    }
}
