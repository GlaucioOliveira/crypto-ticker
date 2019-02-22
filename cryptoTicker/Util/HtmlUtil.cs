using System.IO;
using System.Net;

namespace cryptoTicker.Util
{
    public static class HtmlUtil
    {
        public static Stream getHTML(string URL, CookieContainer cookieContainer = null, bool useProxy = false)
        {
            var request = WebRequest.Create(URL) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            request.CookieContainer = cookieContainer;
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();

            return response.GetResponseStream();
        }
    }
}
