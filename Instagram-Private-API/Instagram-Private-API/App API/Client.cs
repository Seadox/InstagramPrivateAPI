using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Instagram_Private_API.src
{
    class Client
    {
        public static bool debuger = false;
        private static CookieContainer Cookies;
        private static HttpWebResponse postResponse;
        private static string cookie_fname = "cookie_data.txt";
        private static string session_fname = "session.txt";


        public static bool SendRequest(string endpoint, string post = null, bool login = false, int version=0)
        {
            if (!Globals.isLoggedIn && !login)
            {
                Console.WriteLine("Not logged in!");
            }
            if(debuger)
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
                byte[] bytes = ASCIIEncoding.UTF8.GetBytes("ig_sig_key_version=4&signed_body=" + Signatures.HMAC(post, Constants.IG_SIG_KEY) + "." + Signatures.EncodeUrl(post));
                postReq.Method = "POST";
                Stream postStream = postReq.GetRequestStream();
                postStream.Write(bytes, 0, bytes.Length);
                postStream.Close();
            }

            postResponse = (HttpWebResponse)postReq.GetResponse();
            if (postResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                string Response = reader.ReadToEnd();
                Globals.LastResponse = Response;
                try
                {
                    Globals.csrftoken = postResponse.Cookies["csrftoken"].Value.ToUpper();
                }
                catch { }
                return true;
            }
            else
            {
                Console.WriteLine("Request return " + postResponse.StatusCode + " error");
            }
            return false;
        }

        internal static void login()
        {
            throw new NotImplementedException();
        }

        public static void Login(string username, string password, bool use_cookie = true, bool force = false)
        {
            Cookies = new CookieContainer();
            Globals.uuid = Signatures.generateUUID(true);
            Globals.advertising_id = Signatures.generateUUID(true);
            Globals.phone_id = Signatures.generateUUID(true);
            Globals.device_id = Signatures.generateDeviceId(username + password);

            bool cookie_is_loaded = false;
            string cookies_username;
            if (use_cookie)
            {
                try
                {
                    JObject o = JObject.Parse(LoadCookiesData(cookie_fname));
                    Globals.csrftoken = o["csrftoken"].ToString();
                    Globals.username_id = o["ds_user_id"].ToString();
                    Globals.rank_token = Globals.username_id + "_" + Globals.uuid;
                    Globals.token = Globals.csrftoken;
                    cookies_username = o["ds_user"].ToString();

                    if (cookies_username == username)
                    {
                        Cookies = ReadCookiesFromDisk(session_fname);

                        cookie_is_loaded = true;
                        Globals.isLoggedIn = true;
                    }
                }
                catch
                {
                    Console.WriteLine("The cookie is not found");
                }
            }

            if (!cookie_is_loaded && !(Globals.isLoggedIn || force))
            {
                if (SendRequest("si/fetch_headers/?challenge_type=signup&guid=" + Signatures.generateUUID(false), null, true))
                {
                    dynamic data = new JObject();
                    data.phone_id = Globals.phone_id;
                    data._csrftoken = Globals.csrftoken;
                    data.username = username;
                    data.guid = Globals.uuid;
                    data.device_id = Globals.device_id;
                    data.password = password;
                    data.adid = Globals.advertising_id;
                    data.login_attempt_count = "0";

                    if (SendRequest("accounts/login/", data.ToString(), true))
                    {
                        Globals.isLoggedIn = true;
                        JObject o = JObject.Parse(Globals.LastResponse);
                        Globals.username_id = o["logged_in_user"]["pk"].ToString();
                        Globals.rank_token = Globals.username_id + "_" + Globals.uuid;
                        Globals.token = Globals.csrftoken;

                        if (use_cookie)
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

                        Console.WriteLine("Login success!");
                    }
                }
            }
        }

        private static void SaveCookiesData(string file, string cookie)
        {
            File.WriteAllText(file, cookie);
        }

        private static string LoadCookiesData(string file)
        {
            return File.ReadAllText(file);
        }

        private static void WriteCookiesToDisk(string file, CookieContainer cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    Console.Write("Writing cookies to disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                    Console.WriteLine("Done.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Problem writing cookies to disk: " + e.GetType());
                }
            }
        }

        private static CookieContainer ReadCookiesFromDisk(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    Console.Write("Reading cookies from disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    Console.WriteLine("Done.");
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem reading cookies from disk: " + e.GetType());
                return new CookieContainer();
            }
        }

        public static void Logout()
        {
            SendRequest("accounts/logout/");
            Console.WriteLine("Logout success");

            //delete cookies
            File.WriteAllText(cookie_fname, string.Empty);
            File.WriteAllText(session_fname, string.Empty);
            Console.WriteLine("All cookies have been deleted");
        }
    }
}

