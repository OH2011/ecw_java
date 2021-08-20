using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecw.Data;
using ecw.Models;

namespace ecw.Services {
    public class CommonService {
        protected readonly ecwContext _context;

        public CommonService(ecwContext context) {
            _context = context;
        }

        //  システム設定リスト取得
        public List<TmSystemSetting> getSystemSettingList() {
            var systemSettings = _context.TmSystemSettings.ToList();

            return systemSettings;
        }

        //  メッセージリスト取得
        public List<TmMessage> getMessageList() {
            var systemMessageList = _context.TmMessages.ToList();

            return systemMessageList;
        }

        protected String yokeinaMethod(String keyword) {
            if(keyword == null) {
                return "";
            }else if(keyword.StartsWith("kada") && keyword.EndsWith("i02")) {
                return null;
            }
            return "";
        }
    }
}
