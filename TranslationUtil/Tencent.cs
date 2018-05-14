using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TranslationUtil
{
    public static class Tencent
    {
        //内容长度
        private static string Content_Length(string text, string fromlang, string tolang)
        {
            return "source=" + fromlang + "&target=" + tolang + "&sourceText=" + HttpUtility.UrlEncode(text).Replace("+", "%20") + "&sessionUuid=translate_uuid" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
        }

        private static string CookieStr
        {
            get;
            set;
        }

        /// <summary>
        /// 腾讯翻译
        /// </summary>
        /// <param name="text">待翻译文本</param>
        /// <param name="fromLanguage">自动检测：auto</param>
        /// <param name="toLanguage">中文：zh，英文：en</param>
        /// <returns>翻译后文本</returns>
        public static string Translation(string text, string fromLanguage, string toLanguage)
        {
            var cc = new CookieContainer();
            const string TransBaseUrl = "http://fanyi.qq.com/";
            var BaseHtml = TencentGET(TransBaseUrl, cc);

            //在TencentGET中正则匹配cookie的fy_guid值
            var re1 = new Regex("fy_guid.*?;");
            var fy_guid = re1.Match(CookieStr);

            //在返回的HTML中正则匹配qtv和qtk值
            var colls = Regex.Matches(BaseHtml, "(?<=document.cookie = \")(.*?)(?=\";)");
            var qt = new StringBuilder();
            for (int i = 0; i < colls.Count; i++)
            {
                qt.Append(colls[i].Value.ToString() + "; ");
            }
            CookieStr = fy_guid + " " + qt.ToString();
            const string TransUrl = "http://fanyi.qq.com/api/translate";
            var ResultHtml = TencentPOST(TransUrl, CookieStr, TransBaseUrl, Content_Length(text, fromLanguage, toLanguage));

            try
            {
                var sr = new StringReader(ResultHtml);
                var jsonReader = new JsonTextReader(sr);
                var serializer = new JsonSerializer();
                var r = serializer.Deserialize<TransResult>(jsonReader);
                var len = r.Translate.Records.Count;
                var s = new StringBuilder();
                for (int i = 0; i < len; i++)
                {
                    s.Append(r.Translate.Records[i].TargetText);
                }
                return s.ToString().Replace("\n", "\r\n");
            }
            catch (Exception)
            {
                return "服务器返回异常，请重试。";
            }
        }

        private static string TencentGET(string url, CookieContainer cookie)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.CookieContainer = cookie;
            webRequest.Timeout = 20000;
            webRequest.ReadWriteTimeout = 20000;
            webRequest.Accept = "*/*";
            webRequest.Headers.Add("Accept-Encoding: gzip,deflate");
            webRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; WOW64; Trident / 7.0; rv: 11.0) like Gecko";

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var st = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        st = new GZipStream(st, CompressionMode.Decompress);
                    using (var reader = new StreamReader(st, Encoding.UTF8))
                    {
                        html = reader.ReadToEnd();
                        reader.Close();
                        CookieStr = webResponse.Headers.Get("Set-Cookie");
                        webResponse.Close();
                    }
                }
                return html;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string TencentPOST(string url, string cookiestr, string refer, string content_length)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.Referer = refer;
            webRequest.Timeout = 20000;
            webRequest.ReadWriteTimeout = 20000;
            webRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            webRequest.Headers.Add("Cookie", cookiestr);
            webRequest.Headers.Add("Origin: http://fanyi.qq.com");
            webRequest.Headers.Add("X-Requested-With: XMLHttpRequest");
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)";
            webRequest.Headers.Add("Accept-Encoding: gzip,deflate");
            webRequest.Headers.Add("Accept-Language: zh-CN,zh;q=0.9");
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.ProtocolVersion = new Version(1, 1);

            var con_len_byte = Encoding.UTF8.GetBytes(content_length);
            webRequest.ContentLength = con_len_byte.Length;
            var requsetSteam = webRequest.GetRequestStream();
            requsetSteam.Write(con_len_byte, 0, con_len_byte.Length);
            requsetSteam.Close();

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var st = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        st = new GZipStream(st, CompressionMode.Decompress);
                    using (var reader = new StreamReader(st, Encoding.UTF8))
                    {
                        html = reader.ReadToEnd();
                        reader.Close();
                        webResponse.Close();
                    }
                }
                return html;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private class Records
        {
            public string SourceText { get; set; }
            public string TargetText { get; set; }
        }

        private class Translate
        {
            public string Source { get; set; }
            public string Target { get; set; }
            public List<Records> Records { get; set; }
        }

        private class TransResult
        {
            public Translate Translate { get; set; }
        }
    }
}