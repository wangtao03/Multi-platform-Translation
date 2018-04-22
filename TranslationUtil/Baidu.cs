using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;

namespace TranslationUtil
{
    public static class Baidu
    {
        //内容长度
        private static string Content_Length(string text, string fromlang, string tolang)
        {
            var s = "from=" + fromlang + "&to=" + tolang + "&query=" + HttpUtility.UrlEncode(text).Replace("+", "%20");
            return s;
        }

        /// <summary>
        /// 百度翻译
        /// </summary>
        /// <param name="text">待翻译文本</param>
        /// <param name="fromLanguage">自动检测：auto</param>
        /// <param name="toLanguage">中文：zh，英文：en</param>
        /// <returns>翻译后文本</returns>
        public static string Translation(string text, string fromLanguage, string toLanguage)
        {
            var cc = new CookieContainer();
            const string baiduTransUrl = @"http://fanyi.baidu.com/transapi";
            var ResultHtml = GetBaiduHtml(baiduTransUrl, cc, @"http://fanyi.baidu.com/", Content_Length(text, fromLanguage, toLanguage));

            try
            {
                var sr = new StringReader(ResultHtml);
                var jsonReader = new JsonTextReader(sr);
                var serializer = new JsonSerializer();

                var r = serializer.Deserialize<TransObj>(jsonReader);

                var len = r.Data.Count;
                var builder = new StringBuilder();

                for (int i = 0; i < len; i++)
                {
                    if (i + 1 != len)
                        builder.Append(r.Data[i].Dst + "\r\n");
                    else
                        builder.Append(r.Data[i].Dst);
                }
                return builder.ToString();
            }
            catch (Exception)
            {
                return "服务器返回异常，请重试。";
            }
        }

        private static string GetBaiduHtml(string url, CookieContainer cookie, string refer, string content_length)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.CookieContainer = cookie;
            webRequest.Referer = refer;
            webRequest.Timeout = 10000;
            webRequest.Accept = "*/*";
            webRequest.Headers.Add("Accept-Language: zh-CN;q=0.8,en-US;q=0.6,en;q=0.4");
            webRequest.Headers.Add("Accept-Encoding: gzip,deflate");
            webRequest.Headers.Add("Accept-Charset: utf-8");
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.ProtocolVersion = new Version(1, 1);

            var con_len_byte = Encoding.UTF8.GetBytes(content_length);
            webRequest.ContentLength = con_len_byte.Length;
            var requsetSteam = webRequest.GetRequestStream();
            requsetSteam.Write(con_len_byte, 0, con_len_byte.Length);
            requsetSteam.Close();

            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
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

        [Serializable]
        private class TransObj
        {
            public string From { get; set; }
            public string To { get; set; }
            public List<TransResult> Data { get; set; }
        }

        [Serializable]
        private class TransResult
        {
            public string Src { get; set; }
            public string Dst { get; set; }
        }
    }
}