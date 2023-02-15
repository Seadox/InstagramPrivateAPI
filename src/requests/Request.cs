using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace InstagramPrivateAPI.src.requests
{
    internal class Request
    {
        public static CookieContainer Cookies = new CookieContainer();
        private static HttpWebResponse postResponse;
        public static T Send<T>(string endpoint, string post = null, bool login = false, int version = 0) where T : Response
        {
            if (!Globals.isLoggedIn && !login)
                Console.WriteLine("Not logged in!");

            Console.WriteLine($"Debugging ... {endpoint}");
            HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(Constants.API_URLS[version] + endpoint);
            postReq.AutomaticDecompression = DecompressionMethods.GZip;
            WebHeaderCollection postHeaders = postReq.Headers;
            postReq.KeepAlive = true;
            postReq.Accept = "*/*";
            postReq.UserAgent = Constants.UserAgent;
            postReq.ContentType = Constants.CONTENT_TYPE;
            postReq.CookieContainer = Cookies;
            postHeaders.Add("Cookie2", "$Version=1");
            postHeaders.Add("Accept-Language", Constants.ACCEPT_LANGUAGE);
            postHeaders.Add("X-IG-Connection-Type", Constants.X_IG_Connection_Type);
            //POST
            if (post != null)
            {
                byte[] bytes = ASCIIEncoding.UTF8.GetBytes("signed_body=" + Signatures.HMAC(post, Constants.IG_SIG_KEY) + "." + Signatures.EncodeUrl(post));
                postReq.Method = "POST";
                Stream postStream = postReq.GetRequestStream();
                postStream.Write(bytes, 0, bytes.Length);
                postStream.Close();
            }
            try
            {
                postResponse = (HttpWebResponse)postReq.GetResponse();
                if (postResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                    Globals.LastResponse = reader.ReadToEnd();
                    try
                    {
                        Globals.csrftoken = postResponse.Cookies["csrftoken"].Value.ToUpper();
                    }
                    catch { }
                }
                else
                    Console.WriteLine("Request return " + postResponse.StatusCode + " error");

            }
            catch (WebException e)
            {
                Globals.LastResponse = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(Globals.LastResponse);
        }

        public static void ReadCookies(String session_fname) => Cookies = ReadCookiesFromDisk(session_fname);

        public static void UseCookies(string cookie_fname = "cookie_data.txt", string session_fname = "session.txt")
        {
            JObject cookie = new JObject();
            foreach (Cookie cook in postResponse.Cookies)
            {
                string name = cook.ToString().Split('=')[0];
                string value = cook.ToString().Split('=')[1];

                cookie.Add(new JProperty(name, value));
            }
            SaveCookiesData(cookie_fname, cookie.ToString());

            WriteCookiesToDisk(session_fname, Cookies);
        }

        public static void SaveCookiesData(string file, string cookie) => File.WriteAllText(file, cookie);

        public static string LoadCookiesData(string file) => File.ReadAllText(file);

        public static void WriteCookiesToDisk(string file, CookieContainer cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    Console.Out.Write("Writing cookies to disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                    Console.Out.WriteLine("Done.");
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Problem writing cookies to disk: " + e.GetType());
                }
            }
        }

        public static CookieContainer ReadCookiesFromDisk(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    Console.Out.Write("Reading cookies from disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    Console.Out.WriteLine("Done.");
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Problem reading cookies from disk: " + e.GetType());
                return new CookieContainer();
            }
        }
    }
}
