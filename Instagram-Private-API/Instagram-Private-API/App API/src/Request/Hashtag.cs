using Newtonsoft.Json.Linq;
using System;

namespace Instagram_Private_API.src.Request
{
    class Hashtag
    {
        public static string getInfo(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag);//for non-English chars

            Client.SendRequest($"tags/{urlhashtag}/info/");
            return Globals.LastResponse;
        }

        public static string getFeed(string hashtag, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag);//for non-English chars

            Client.SendRequest($"feed/tag/{urlhashtag}/&max_id=" + maxId);
            return Globals.LastResponse;
        }

        public static string getRelated(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag);//for non-English chars

            dynamic data = new JObject();
            data.visited = "[{\"id\":\"" + urlhashtag + "\",\"type\":\"hashtag\"}]";
            data.related_types = "[\"hashtag\"]";

            Client.SendRequest($"tags/{urlhashtag}/related/", data.ToString());
            return Globals.LastResponse;
        }

        public static string search(string query)
        {
            dynamic data = new JObject();
            data.q = query;
            data.timezone_offset = DateTimeOffset.Now.Offset.TotalSeconds;
            data.count = "30";
            data.rank_token = Globals.rank_token;

            Client.SendRequest("tags/search/", data.ToString());
            return Globals.LastResponse;
        }

        public static string follow(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag); //for non-English chars
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest($"tags/follow/{urlhashtag}/", data.ToString());
            return Globals.LastResponse;
        }

        public static string unfollow(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag); //for non-English chars
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest($"tags/unfollow/{urlhashtag}/", data.ToString());
            return Globals.LastResponse;
        }
    }
}
