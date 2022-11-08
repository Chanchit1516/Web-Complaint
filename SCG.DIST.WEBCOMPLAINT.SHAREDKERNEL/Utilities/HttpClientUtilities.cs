using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Utilities
{
    public class HttpClientUtilities
    {
        public static async Task RequestPost(string url, string json, Dictionary<string, string> header, int timeout = 0)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                if (timeout != 0) httpWebRequest.Timeout = timeout;
                httpWebRequest.Method = "POST";
                if (header != null && header.Any())
                {
                    foreach (var h in header)
                    {
                        httpWebRequest.Headers.Add(h.Key, h.Value);
                    }
                }
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var str = streamReader.ReadToEnd();



                streamReader.Dispose();


            }
            catch (WebException e)
            {
                var webResponse = (HttpWebResponse)e.Response;
                Uri baseUrl = new Uri(url);
                var msg = $"({webResponse?.StatusCode})Error from " + baseUrl.Host + ":";

                if (webResponse.CharacterSet != null)
                {
                    var encoding = Encoding.GetEncoding(webResponse.CharacterSet);

                    using (var responseStream = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(responseStream, encoding))
                    {
                        msg += reader.ReadToEnd();
                    }

                }
                HttpStatusCode? status = webResponse?.StatusCode;


                if (status == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();

                throw new Exception(msg);
            }
        }

        public static async Task RequestPut(string url, string json, Dictionary<string, string> header, int timeout = 0)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                if (timeout != 0) httpWebRequest.Timeout = timeout;
                httpWebRequest.Method = "PUT";
                if (header != null && header.Any())
                {
                    foreach (var h in header)
                    {
                        httpWebRequest.Headers.Add(h.Key, h.Value);
                    }
                }
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var str = streamReader.ReadToEnd();



                streamReader.Dispose();


            }
            catch (WebException e)
            {
                var webResponse = (HttpWebResponse)e.Response;
                Uri baseUrl = new Uri(url);
                var msg = $"({webResponse?.StatusCode})Error from " + baseUrl.Host + ":";

                if (webResponse.CharacterSet != null)
                {
                    var encoding = Encoding.GetEncoding(webResponse.CharacterSet);

                    using (var responseStream = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(responseStream, encoding))
                    {
                        msg += reader.ReadToEnd();
                    }

                }
                HttpStatusCode? status = webResponse?.StatusCode;


                if (status == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();

                throw new Exception(msg);
            }
        }
        public static async Task RequestDelete(string url, int timeout = 0)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                if (timeout != 0) httpWebRequest.Timeout = timeout;
                httpWebRequest.Method = "DELETE";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {


                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var str = streamReader.ReadToEnd();



                streamReader.Dispose();


            }
            catch (WebException e)
            {
                var webResponse = (HttpWebResponse)e.Response;
                Uri baseUrl = new Uri(url);
                var msg = $"({webResponse?.StatusCode})Error from " + baseUrl.Host + ":";

                if (webResponse.CharacterSet != null)
                {
                    var encoding = Encoding.GetEncoding(webResponse.CharacterSet);

                    using (var responseStream = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(responseStream, encoding))
                    {
                        msg += reader.ReadToEnd();
                    }

                }

                HttpStatusCode? status = webResponse?.StatusCode;


                if (status == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();

                throw new Exception(msg);
            }
        }

        public static async Task<T> RequestPost<T>(string url, string json, Dictionary<string, string> header, string userName, string password, int timeout = 0) where T : new()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                if (timeout != 0) httpWebRequest.Timeout = timeout;
                httpWebRequest.Method = "POST";
                if (header != null && header.Any())
                {
                    foreach (var h in header)
                    {
                        httpWebRequest.Headers.Add(h.Key, h.Value);
                    }
                }
                NetworkCredential networkCredential = new NetworkCredential(userName, password);

                httpWebRequest.Credentials = networkCredential;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var str = streamReader.ReadToEnd();
                var obj = str.ToObject<T>();
                streamReader.Dispose();
                return obj;

            }
            catch (WebException e)
            {
                var webResponse = (HttpWebResponse)e.Response;
                Uri baseUrl = new Uri(url);
                var msg = $"({webResponse?.StatusCode})Error from " + baseUrl.Host + ":";

                if (webResponse.CharacterSet != null)
                {
                    var encoding = Encoding.GetEncoding(webResponse.CharacterSet);

                    using (var responseStream = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(responseStream, encoding))
                    {
                        msg += reader.ReadToEnd();
                    }

                }
                HttpStatusCode? status = webResponse?.StatusCode;


                if (status == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();

                throw new Exception(msg);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public static async Task<T> RequestGet<T>(string url, Dictionary<string, string> header = null) where T : new()
        {
            try
            {
                StringBuilder token = new StringBuilder();
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        if (string.IsNullOrEmpty(h.Value) == false)
                            token.Append(h.Key + h.Value);
                    }
                }


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        httpWebRequest.Headers.Add(h.Key, h.Value);
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());
                if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();
                var str = streamReader.ReadToEnd();


                var obj = str.ToObject<T>();
                streamReader.Dispose();
                return obj;

            }
            catch (WebException e)
            {
                Uri baseUrl = new Uri(url);
                var webResponse = (HttpWebResponse)e.Response;
                var msg = $"({webResponse?.StatusCode})Error from " + baseUrl.Host + ":";

                if (webResponse.CharacterSet != null)
                {
                    var encoding = Encoding.GetEncoding(webResponse.CharacterSet);

                    using (var responseStream = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(responseStream, encoding))
                    {
                        msg += reader.ReadToEnd();
                    }
                }

                HttpStatusCode? status = webResponse?.StatusCode;


                if (status == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();

                throw new Exception(msg);
            }

        }

        public static string DownloadString(string url)
        {

            try
            {
                WebClient webpage = new WebClient();
                webpage.Encoding = Encoding.UTF8;

                var result = webpage.DownloadString(url);

                return result;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public static async Task RequestGet(string url, Dictionary<string, string> header = null, int httpTimeOut = 0)
        {
            try
            {

                StringBuilder token = new StringBuilder();
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        if (string.IsNullOrEmpty(h.Value) == false)
                            token.Append(h.Key + h.Value);
                    }
                }



                var client = new HttpClient();
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        client.DefaultRequestHeaders.Add(h.Key, h.Value);
                    }
                }

                if (httpTimeOut != 0)
                {
                    client.Timeout = TimeSpan.FromMinutes(httpTimeOut);
                }
                var task = client.GetAsync(url);
                task.Wait();
                var contents = task.Result.StatusCode;
                if (contents != HttpStatusCode.OK)
                    throw new Exception(" Url " + url + ",Error RequestGet:" + task.Result.Content.ToString());


            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
