using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TranslationUtil
{
    public static class HttpUtil
    {
        public static string Post(string url, string postData, Dictionary<string, string> headerDic = null)
        {
            var ret = string.Empty;
            try
            {
                if (!url.StartsWith("http://")) return ret;

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = @"POST";
                request.ContentType = @"application/x-www-form-urlencoded; charset=UTF-8";
                request.ContentLength = Encoding.UTF8.GetByteCount(postData);
                request.UserAgent = @"Mozilla / 5.0(Windows NT 6.1; WOW64; Trident / 7.0; rv: 11.0) like Gecko";

                if (headerDic != null && headerDic.Count > 0)
                {
                    foreach (var item in headerDic)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }

                var stream = request.GetRequestStream();
                stream.Write(Encoding.UTF8.GetBytes(postData), 0, postData.Length);
                stream.Close();

                var response = (HttpWebResponse)request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    ret = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ret;
        }
    }
}