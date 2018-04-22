using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace TranslationUtil
{
    public static class Bing
    {
        private static string Content_Length(string text, string fromlang, string tolang)
        {
            return string.Format("&text={0}&from={1}&to={2}", new string[] { HttpUtility.UrlEncode(text).Replace("+", "%20"), fromlang, tolang });
        }

        public static string Translation(string text, string fromLanguage, string toLanguage)
        {
            var cookie = new CookieContainer();
            const string TransBaseUrl = "http://cn.bing.com/";
            const string TransUrl = "http://cn.bing.com/ttranslate";
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

                return r.TranslationResponse.ToString();
            }
            catch (Exception)
            {
                return "服务器返回异常，请重试。";
            }
        }

        private class TransResult
        {
            public string StatusCode { get; set; }
            public string TranslationResponse { get; set; }
        }
    }
}