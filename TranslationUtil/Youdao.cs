using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TranslationUtil
{
    public static class Youdao
    {
        private static string Content_Length(string text, string fromlang, string tolang)
        {
            var salt = (DateTimeOffset.Now.ToUnixTimeMilliseconds() + 9).ToString();
            return string.Format("i={0}&from={1}&to={2}&smartresult=dict&client=fanyideskweb&salt={3}&sign={4}&doctype=json&version=2.1&keyfrom=fanyi.web&action=FY_BY_REALTIME&typoResult=false", new string[] { HttpUtility.UrlEncode(text), fromlang, tolang, salt, MakeSign(text, salt) });
        }
        private static string CookieStr { get; set; }

        public static string Translation(string text, string fromLanguage, string toLanguage)
        {
            var cookie = new CookieContainer();
            const string TransBaseUrl = "http://fanyi.youdao.com/";
            var BaseHtml = YoudaoGET(TransBaseUrl, cookie);

            const string TransUrl = "http://fanyi.youdao.com/translate_o?smartresult=dict&smartresult=rule";

            var ResultHtml = YoudaoPOST(TransUrl, CookieStr, TransBaseUrl, Content_Length(text, fromLanguage, toLanguage));

            try
            {
                var sr = new StringReader(ResultHtml);
                var jsonReader = new JsonTextReader(sr);
                var serializer = new JsonSerializer();
                var r = serializer.Deserialize<Result>(jsonReader);

                var len = r.TranslateResult.Count;
                var builder = new StringBuilder();

                for (int i = 0; i < len; i++)
                {
                    if (i + 1 != len)
                        builder.Append(r.TranslateResult[i][0].Tgt + "\r\n");
                    else
                        builder.Append(r.TranslateResult[i][0].Tgt);
                }
                return builder.ToString();
            }
            catch (Exception)
            {
                return "服务器返回异常，请重试。";
            }
        }

        private static string YoudaoPOST(string url, string cookiestr, string refer, string content_length)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.Referer = refer;
            webRequest.Timeout = 10000;
            webRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            webRequest.Headers.Add("Cookie", cookiestr);
            webRequest.Headers.Add("X-Requested-With: XMLHttpRequest");
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            webRequest.Headers.Add("Accept-Encoding: gzip,deflate");
            webRequest.Headers.Add("Accept-Language: zh-CN");
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


        private static string YoudaoGET(string url, CookieContainer cookie)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.CookieContainer = cookie;
            webRequest.Timeout = 20000;
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

        private static string MakeSign(string text, string salt)
        {//o = n.md5("fanyideskweb" + t + i + "ebSeFb%=XZ%T[KZ)c(sy!");
            var temp = string.Format("fanyideskweb{0}{1}ebSeFb%=XZ%T[KZ)c(sy!", new string[] { text, salt });
            return MD5Encrypt(temp);
        }

        private class Result
        {
            public List<List<TransResult>> TranslateResult { get; set; }

            [JsonIgnore]
            public int ErrorCode { get; set; }

            [JsonIgnore]
            public string Type { get; set; }
        }

        private class TransResult
        {
            public string Tgt { get; set; }
            public string Src { get; set; }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns></returns>
        public static string MD5Encrypt(string input)
        {
            return MD5Encrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// md5加密16|32位
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string input, int length)
        {
            var res = MD5Encrypt(input, new UTF8Encoding());
            if (length == 16)
            {
                res = res.Substring(8, 16);
            }
            return res;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        public static string MD5Encrypt(string input, Encoding encode)
        {
            if (string.IsNullOrEmpty(input)) return null;
            using (var md5Hasher = new MD5CryptoServiceProvider())
            {
                var data = md5Hasher.ComputeHash(encode.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}