using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ecw {

    // セッションにオブジェクトを格納するための拡張クラス
    public static class SessionExtensions {

        // セッションにオブジェクトを書き込む
        public static void SetObject(this ISession session,string key, Dictionary<string,string> obj) {
            var json = JsonConvert.SerializeObject(obj);
            session.SetString(key, json);
        }

        // セッションからオブジェクトを読み込む
        public static Dictionary<string,string> GetObject(this ISession session, string key) {
            var json = session.GetString(key);
            return string.IsNullOrEmpty(json)
                ? new Dictionary<string, string>()
                : JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }
}
