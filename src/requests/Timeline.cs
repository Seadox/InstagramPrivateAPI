using InstagramPrivateAPI.src.responses.feed;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Timeline
    {
        public FeedTimelineResponse GetTimelineFeed(string max_id = null)
        {
            dynamic data = new JObject();
            data._csrftoken = Globals.csrftoken;
            data._uuid = Globals.uuid;
            data.is_prefetch = "0";
            data.phone_id = Globals.phone_id;
            data.device_id = Globals.device_id;
            data.battery_level = "100";
            data.is_charging = "1";
            data.will_sound_on = "1";
            data.timezone_offset = DateTimeOffset.Now.Offset.TotalSeconds;
            data.client_session_id = Globals.session_id;
            data.bloks_versioning_id = Constants.BLOCK_VERSIONING_ID;

            if (max_id != null)
            {
                data.reason = "pagination";
                data.is_pull_to_refresh = "0";
            }

            return Request.Send<FeedTimelineResponse>("feed/timeline/?max_id=" + max_id, data.ToString());
        }

        public FeedUsersResponse GetUserFeed(string userId, string maxId = null) => Request.Send<FeedUsersResponse>("feed/user/" + userId + "/?&exclude_comment=true&only_fetch_first_carousel_media=true" + (maxId != null ? maxId : ""));

        public FeedUsersResponse GetSelfFeed(string maxId = null, string minTimestamp = null) => GetUserFeed(Globals.username_id, maxId);
    }
}
