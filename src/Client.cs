using InstagramPrivateAPI.src.requests;
using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.accounts;
using InstagramPrivateAPI.src.utils;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src
{
    internal class Client
    {
        public LoginResponse Login(string username, string password, bool use_cookie = true, string cookie_fname = "cookie_data.txt", string session_fname = "session.txt", bool force = false)
        {
            LoginResponse login = null;

            Globals.uuid = Signatures.generateUUID(true);
            Globals.advertising_id = Signatures.generateUUID(true);
            Globals.phone_id = Signatures.generateUUID(true);
            Globals.device_id = Signatures.generateDeviceId(username + password);

            bool cookie_is_loaded = false;
            if (use_cookie)
            {
                try
                {
                    JObject o = JObject.Parse(Request.LoadCookiesData(cookie_fname));
                    Globals.csrftoken = o["csrftoken"].ToString();
                    Globals.username_id = o["ds_user_id"].ToString();
                    Globals.rank_token = Globals.username_id + "_" + Globals.uuid;
                    Globals.token = Globals.csrftoken;

                    Request.ReadCookies(session_fname);

                    cookie_is_loaded = true;
                    Globals.isLoggedIn = true;
                }
                catch
                {
                    Console.WriteLine("The cookie is not found");
                }
            }

            if (!cookie_is_loaded && !(Globals.isLoggedIn || force))
            {
                dynamic data = new JObject();
                data.country_codes = "[{\"country_code\":\"1\",\"source\":[\"default\"]}]";
                data.phone_id = Globals.phone_id;
                data._csrftoken = Globals.csrftoken;
                data.username = username;
                data.adid = Globals.advertising_id;
                data.guid = Globals.uuid;
                data.device_id = Globals.device_id;
                data.password = password;
                data.google_tokens = "[]";
                data.login_attempt_count = "0";

                login = Request.Send<LoginResponse>("accounts/login/", data.ToString(), true);

                if (login.status.Equals("ok"))
                {
                    Globals.isLoggedIn = true;
                    try
                    {
                        Globals.username_id = login.logged_in_user.pk.ToString();
                        Globals.rank_token = Globals.username_id + "_" + Globals.uuid;
                        Globals.token = Globals.csrftoken;
                    }
                    catch { }

                    if (use_cookie)
                        Request.UseCookies();


                    Console.WriteLine("Login success!");
                }
            }
            return login;
        }

        public Object Logout() => Request.Send<Response>("accounts/logout/");

        public Account account = new Account();
        public Direct direct = new Direct();
        public Discover discover = new Discover();
        public Hashtag hashtag = new Hashtag();
        public Live live = new Live();
        public Location location = new Location();
        public Media media = new Media();
        public People people = new People();
        public Story story = new Story();
        public Timeline timeline = new Timeline();
        public Map map = new Map();
    }
}
