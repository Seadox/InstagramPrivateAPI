using InstagramPrivateAPI.src.responses;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Internal
    {
        public static Response markStoryMediaSeen(string itemSourceId, string itemId, string itemTakenAt)
        {
            Int32 maxSeenAt = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int seenAt = maxSeenAt - 3;

            string reelId = itemId + "_" + itemSourceId;

            JObject data = new JObject(
                    new JProperty("_uuid", Globals.uuid),
                    new JProperty("_uid", Globals.username_id),
                    new JProperty("_csrftoken", Globals.csrftoken),
                    new JProperty("live_vods", new JArray()),
                    new JProperty("reels", new JObject(new JProperty(reelId, new JArray(itemTakenAt + "_" + seenAt)))),
                    new JProperty("reel", 1),
                    new JProperty("live_vod", 0)
                    );

            return Request.Send<Response>("media/seen/", data.ToString(), true, 1);
        }
    }
}
