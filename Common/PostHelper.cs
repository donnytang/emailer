using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace Common
{
    public class PostHelper
    {
        public const string HTML_IP_NOT_OK = " IP <strong>[1:1";

        public static string GetResponseFromPostParam(string method,
            string Url,
            string Param,
            CookieContainer sendCookie,
            out CookieContainer receiveCookie)
        {

            return GetResponseFromPostParam(method, Url, Param, "", sendCookie, "", out receiveCookie);
        }

        public static string GetResponseFromPostParam(string method, string Url, string Param, string Referer,
            CookieContainer sendCookie, string cookieDomain, out CookieContainer receiveCookie)
        {
            return GetResponseFromPostParam(method, Url, Param, Referer, sendCookie, cookieDomain, out receiveCookie, "");
        }

        public static string GetResponseFromPostParam(string method, string Url, string Param, string Referer,
            CookieContainer sendCookie, string cookieDomain, out CookieContainer receiveCookie, string UserAgent)
        {

            string sReponseHttp = null;
            receiveCookie = new CookieContainer();

            /*Random r = new Random();
            System.Threading.Thread.Sleep(r.Next(10) * 200);
            return "test";*/


            System.Net.HttpWebRequest oRequest = null;

            if (method.ToUpper() == "POST")
            {
                oRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
                oRequest.ContentType = "application/x-www-form-urlencoded";
                oRequest.Method = "POST";
                oRequest.KeepAlive = true;
                oRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                if (!string.IsNullOrEmpty(Referer)) oRequest.Referer = Referer;
                //oRequest.Host = "secure.picaplay.com";

                oRequest.CookieContainer = sendCookie;


                byte[] tabBytes = System.Text.Encoding.UTF8.GetBytes(Param);
                oRequest.ContentLength = tabBytes.Length;

                try
                {
                    System.IO.Stream oStream = oRequest.GetRequestStream();
                    oStream.Write(tabBytes, 0, tabBytes.Length);
                    oStream.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("无法远程连接"))
                        return HTML_IP_NOT_OK;
                    return ex.Message;
                }
            }
            else
            {
                if (Param.Length > 0)
                    oRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(Url + "?" + Param));
                else
                    oRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(Url));
                oRequest.CookieContainer = sendCookie;
                if (!string.IsNullOrEmpty(Referer)) oRequest.Referer = Referer;
                oRequest.Method = "GET";
            }

            if (!string.IsNullOrEmpty(UserAgent))
                oRequest.Headers.Add("User-Agent", UserAgent);
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)oRequest.GetResponse();
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;

                if (res == null)
                    return HTML_IP_NOT_OK;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("ks_c_5601-1987"));
            receiveCookie = sendCookie;
            receiveCookie.Add(res.Cookies);
            sReponseHttp = sr.ReadToEnd();


            /*using (HttpWebResponse oResponse = (HttpWebResponse)oRequest.GetResponse())
            {
                using (StreamReader oReader = new StreamReader(oResponse.GetResponseStream(), Encoding.GetEncoding("gb2312")))
                {
                    receiveCookie.Add(oResponse.Cookies);
                    sReponseHttp = oReader.ReadToEnd();
                }
            }*/
            return sReponseHttp;
        }

        public static string GetResponse(string url)
        {
            return GetResponse(url, Encoding.Default);
        }

        public static string GetResponse(string url, Encoding encoding)
        {
            string webPage = string.Empty;
            WebRequest request;
            Stream stream;
            StreamReader sr;
            try
            {
                request = HttpWebRequest.Create(url);
                stream = request.GetResponse().GetResponseStream();
                using (sr = new StreamReader(stream, encoding))
                {
                    webPage = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { }
            return webPage;
        }

        public static string ConvertEncoding(string str, Encoding sourceE, Encoding targetE)
        {
            byte[] myByte = sourceE.GetBytes(str);
            return targetE.GetString(myByte);
        }

        public static bool DowloadCheckImg(string Url, CookieContainer cookCon, string savePath)
        {
            bool bol = true;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            //属性配置   
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            webRequest.MaximumResponseHeadersLength = -1;
            webRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";
            webRequest.Headers.Add("Accept-Language", "zh-cn");
            webRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            webRequest.KeepAlive = true;
            webRequest.CookieContainer = cookCon;
            try
            {
                //获取服务器返回的资源   
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream sream = webResponse.GetResponseStream())
                    {
                        List<byte> list = new List<byte>();
                        while (true)
                        {
                            int data = sream.ReadByte();
                            if (data == -1)
                                break;
                            list.Add((byte)data);
                        }
                        File.WriteAllBytes(savePath, list.ToArray());
                    }
                }
            }
            catch (WebException ex)
            {
                bol = false;
            }
            catch (Exception ex)
            {
                bol = false;
            }
            return bol;
        }

    }
}
