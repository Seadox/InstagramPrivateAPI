using Newtonsoft.Json.Linq;
using System;

namespace Instagram_Private_API.src.Request
{
    class Timeline
    {
        public static string GetTimelineFeed(string max_id = null)
        {
            dynamic data = new JObject();
            data._csrftoken = Globals.csrftoken;
            data._uuid = Globals.uuid;
            data.is_prefetch = "0";
            data.phone_id = Globals.phone_id;
            data.battery_level = "100";
            data.is_charging = "1";
            data.will_sound_on = "1";
            data.is_on_screen = "true";
            data.timezone_offset = DateTimeOffset.Now.Offset.TotalSeconds;

            if (max_id != null)
            {
                data.reason = "pagination";
                data.is_pull_to_refresh = "0";
            }

            Client.SendRequest("feed/timeline/?max_id=" + max_id, data.ToString());
            return Globals.LastResponse;
        }

        public static string GetUserFeed(string userId, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest("feed/user/" + userId + "/?&ranked_content=true&max_id=" + maxId);
            return Globals.LastResponse;
        }

        public static string GetSelfFeed(string maxId = null, string minTimestamp = null)
        {
            GetUserFeed(Globals.username_id, maxId);
            return Globals.LastResponse;
        }
    }
}
