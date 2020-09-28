using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Utity
{
    public class HttpHelp
    {
        public static string HttpGet(string Url, out string cookie)
        {
            cookie = null;
            try
            {
                string url = Url;
                HttpClientHandler handler = new HttpClientHandler() { UseCookies = true };
                using (HttpClient client = new HttpClient(handler))
                {
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
                    HttpResponseMessage response = client.SendAsync(message).Result;
                    cookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
                    byte[] resultBytes = response.Content.ReadAsByteArrayAsync().Result;
                    return Encoding.GetEncoding("gb2312").GetString(resultBytes);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static string Network()
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler() { UseCookies = true };
                using(HttpClient client=new HttpClient(handler))
                {
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "http://jw.jltc.edu.cn/");
                    HttpResponseMessage response = client.SendAsync(message).Result;
                    return response.Headers.GetValues("Set-Cookie").FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static byte[] GetImg(string Url, string cookie = null)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "Get";
                request.ContentType = "text/html;charset=gb2312";
                if (cookie != null)
                {
                    request.Headers.Add("Cookie", cookie);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    using (Stream fs = new MemoryStream())
                    {
                        byte[] bArr = new byte[1024];
                        int size = stream.Read(bArr, 0, bArr.Length);
                        while (size > 0)
                        {
                            fs.Write(bArr, 0, size);
                            size = stream.Read(bArr, 0, bArr.Length);
                        }
                        byte[] imgbt = new byte[fs.Length];
                        fs.Position = 0;
                        fs.Read(imgbt, 0, imgbt.Length);
                        return imgbt;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public static string HttpGet(string Url, string cookie)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler() { UseCookies = true };
                using (HttpClient client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Connection.Add("keep-alive");
                    client.DefaultRequestHeaders.Add("Cookie", cookie);
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, Url);
                    HttpResponseMessage response = client.SendAsync(message).Result;
                    System.Net.Http.Headers.HttpResponseHeaders heads = response.Headers;
                    string cookie1 = response.RequestMessage.Headers.ToString();//从这个里边把sessionid的cookie拿到
                    byte[] resultBytes = response.Content.ReadAsByteArrayAsync().Result;
                    return Encoding.GetEncoding("GB2312").GetString(resultBytes);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string HttpPost(string Url, string cookie, IEnumerable<KeyValuePair<string, string>> postDataStr)
        {
            try
            {
                using (HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false, AllowAutoRedirect = false }))
                {
                    client.DefaultRequestHeaders.Connection.Add("keep-alive");
                    client.DefaultRequestHeaders.Add("Cookie", cookie);
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, Url)
                    {
                        Content = new FormUrlEncodedContent(postDataStr)
                    };
                    HttpResponseMessage response = client.SendAsync(message).Result;
                    System.Net.Http.Headers.HttpResponseHeaders heads = response.Headers;
                    string cookie1 = response.RequestMessage.Headers.ToString();
                    byte[] resultBytes = response.Content.ReadAsByteArrayAsync().Result;
                    return Encoding.GetEncoding("GB2312").GetString(resultBytes);
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static string LoginGetSessin(string Url, IEnumerable<KeyValuePair<string, string>> postDataStr, string ContentType = "application/x-www-form-urlencoded", string cookie = null)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler() { UseCookies = true };
                if (cookie != null)
                {
                    handler = new HttpClientHandler() { UseCookies = false, AllowAutoRedirect = false };
                }
                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Connection.Add("keep-alive");
                    client.DefaultRequestHeaders.Add("Cookie", cookie);
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, Url)
                    {
                        Content = new FormUrlEncodedContent(postDataStr)
                    };
                    HttpResponseMessage response = client.SendAsync(message).Result;
                    if (response.StatusCode == HttpStatusCode.Found)
                    {
                        IEnumerable<string> result = response.Headers.GetValues("Set-Cookie");
                        return result.FirstOrDefault();
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
