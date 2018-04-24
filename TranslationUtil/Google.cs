using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace TranslationUtil
{
    public static class Google
    {
        /// <summary>
        /// 谷歌翻译
        /// </summary>
        /// <param name="text">待翻译文本</param>
        /// <param name="fromLanguage">自动检测：auto</param>
        /// <param name="toLanguage">中文：zh-CN，英文：en</param>
        /// <returns>翻译后文本</returns>
        public static string Translate(string text, string fromLanguage, string toLanguage)
        {
            var cc = new CookieContainer();
            var tk = TokenGenerator.GetToken(text);

            var googleTransUrl = string.Format("https://translate.google.cn/translate_a/single?client=t&sl={0}&tl={1}&hl=en&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&ie=UTF-8&oe=UTF-8&otf=1&ssel=0&tsel=0&kc=1&tk={2}&q={3}", new string[] { fromLanguage, toLanguage, tk, HttpUtility.UrlEncode(text) });

            var ResultHtml = GetResultHtml(googleTransUrl, cc, "https://translate.google.com/");

            try
            {
                var TempResult = JsonConvert.DeserializeObject<List<object>>(ResultHtml);
                TempResult = JsonConvert.DeserializeObject<List<object>>(TempResult[0].ToString());

                var builder = new StringBuilder();

                for (int i = 0; i < TempResult.Count - 1; i++)
                {
                    var temp = JsonConvert.DeserializeObject<List<object>>(TempResult[i].ToString());

                    builder.Append(temp[0]);
                }

                return builder.ToString();
            }
            catch (Exception)
            {
                return "服务器返回异常，请重试。";
            }
        }

        private static string GetResultHtml(string url, CookieContainer cc, string refer)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            webRequest.Method = "GET";
            webRequest.CookieContainer = cc;
            webRequest.Referer = refer;
            webRequest.Timeout = 20000;
            webRequest.Headers.Add("X-Requested-With:XMLHttpRequest");
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; WOW64; Trident / 7.0; rv: 11.0) like Gecko";

            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (var reader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    html = reader.ReadToEnd();
                    reader.Close();
                    webResponse.Close();
                }
            }
            return html;
        }

        private class Tr
        {
            public string Tgt { get; set; }
            public string Src { get; set; }
            public object C { get; set; }
            public object D { get; set; }
            public int E { get; set; }

            public static explicit operator Tr(List<object> v)
            {
                throw new NotImplementedException();
            }
        }
        private static class TokenGenerator
        {
            private static A[] rl1 = new A[] { new A { a = true, b = false, c = 10 }, new A { a = false, b = true, c = 6 } };
            private static A[] rl2 = new A[] { new A { a = true, b = false, c = 3 }, new A { a = false, b = true, c = 11 }, new A { a = true, b = false, c = 15 } };

            public static string GetToken(string a)
            {
                long b = 406398;

                for (int i = 0; i < a.Length; i++)
                {
                    int c = a[i];
                    if (c < 128)
                    {
                        B(ref b, c);
                    }
                    else
                    {
                        if (c < 2048)
                        {
                            B(ref b, c >> 6 | 192);
                        }
                        else
                        {
                            if ((c & 64512) == 55296 && i < a.Length - 1 && (a[i + 1] & 64512) == 56320)
                            {
                                c = 65536 + ((c & 1023) << 10) + (a[++i] & 1023);
                                B(ref b, c >> 18 | 240);
                                B(ref b, c >> 12 & 63 | 128);
                            }
                            else
                            {
                                B(ref b, c >> 12 | 224);
                            }
                            B(ref b, c >> 6 & 63 | 128);
                        }
                        B(ref b, c & 63 | 128);
                    }
                }

                RL(ref b, rl2);
                b ^= 2087938574;
                if (b < 0)
                    b = (b & 2147483647) + 2147483648;
                b %= 1000000;
                return $"{b}.{b ^ 406398}";
            }

            private static void B(ref long a, int b)
            {
                a += b;
                RL(ref a, rl1);
            }

            private static void RL(ref long a, A[] b)
            {
                foreach (A c in b)
                {
                    var d = c.b ? ((uint)a >> c.c) : a << c.c;
                    a = c.a ? ((a + d) & 4294967295) : a ^ d;
                }
            }
        }

        private struct A
        {
            public bool a;
            public bool b;
            public int c;
        }
    }
}