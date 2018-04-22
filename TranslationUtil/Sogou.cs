using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace TranslationUtil
{
    public static class Sogou
    {
        private static string Content_Length(string text, string fromlang, string tolang)
        {
            return string.Format("from={0}&to={1}&client=pc&fr=browser_pc&text={2}&useDetect=on&useDetectResult=on&needQc=1&oxford=on&isReturnSugg=off", new string[] { fromlang, tolang, HttpUtility.UrlEncode(text).Replace("+", "%20") });
        }

        public static string Translation(string text, string fromLanguage, string toLanguage)
        {
            var cookie = new CookieContainer();
            const string TransBaseUrl = "http://fanyi.sogou.com";
            const string TransUrl = "http://fanyi.sogou.com/reventondc/translate";
            var other = new Dictionary<string, string>
            {
                { "Origin", TransBaseUrl }
            };
            var ResultHtml = HttpUtil.Post(TransUrl, Content_Length(text, fromLanguage, toLanguage), other);

            try
            {
                var sr = new StringReader(ResultHtml);
                var jsonReader = new JsonTextReader(sr);
                var serializer = new JsonSerializer();
                var r = serializer.Deserialize<TransResult>(jsonReader);

                return r.Translate.Dit.ToString();
            }
            catch (Exception)
            {
                return "服务器返回异常，请重试。";
            }
        }

        private class Detect
        {
            public string Zly { get; set; }
            public string _Detect { get; set; }
            public string ErrorCode { get; set; }
            public string Language { get; set; }
            public string Id { get; set; }
            public string Text { get; set; }
        }

        private class Translate
        {
            public string Qc_type { get; set; }
            public string Zly { get; set; }
            public string ErrorCode { get; set; }
            public string Index { get; set; }
            public string From { get; set; }
            public string Source { get; set; }
            public string Text { get; set; }
            public string To { get; set; }
            public string Id { get; set; }
            public string Dit { get; set; }
            public string Orig_text { get; set; }
            public string Md5 { get; set; }
        }

        private class TransResult
        {
            private int ErrorCode { get; set; }
            public Detect Detect { get; set; }
            private string Message { get; set; }
            public Translate Translate { get; set; }

            private bool IsHasOxford { get; set; }
            private bool IsHasChinese { get; set; }
        }
    }
}