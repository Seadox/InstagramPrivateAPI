using Newtonsoft.Json.Linq;
using System;

namespace Instagram_Private_API.src.Request
{
    class Discover
    {
        public static string getExploreFeed(string maxId = null, bool isPrefetch = false)
        {
            dynamic data = new JObject();
            data.is_prefetch = isPrefetch;
            data.is_from_promote = false;
            data.timezone_offset = DateTimeOffset.Now.Offset.TotalSeconds;
            data.session_id = Signatures.generateUUID(true);

            Client.SendRequest("discover/explore/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getPopularFeed()
        {
            dynamic data = new JObject();
            data.people_teaser_supported = "1";
            data.rank_token = Globals.csrftoken;
            data.ranked_content = "true";

            Client.SendRequest("feed/popular/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getHomeChannelFeed(string maxId = null)
        {
            Client.SendRequest("discover/channels_home/");
            return Globals.LastResponse;
        }
    }
}
