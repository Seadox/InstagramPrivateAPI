using Newtonsoft.Json.Linq;

namespace Instagram_Private_API.src.Request
{
    class Story
    {
        public static string getReelsTrayFeed()
        {
            Client.SendRequest("feed/reels_tray/");
            return Globals.LastResponse;
        }

        public static string getUserReelMediaFeed(string userId)
        {
            Client.SendRequest($"feed/user/{userId}/reel_media/");
            return Globals.LastResponse;
        }

        public static string getUserStoryFeed(string userId)
        {
            Client.SendRequest($"feed/user/{userId}/story/");
            return Globals.LastResponse;
        }

        //Works for your own story items
        public static string getStoryItemViewers(string storyPk, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest($"media/{storyPk}/list_reel_media_viewer/?max_id=" + maxId);
            return Globals.LastResponse;
        }

        public static string getReelSettings()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest("users/reel_settings/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getArchivedStoriesFeed()
        {
            Client.SendRequest("archive/reel/day_shells/?include_cover=0");
            return Globals.LastResponse;
        }

        public static void markMediaSeen(string itemSourceId, string itemId, string itemTakenAt)
        {
            Internal.markStoryMediaSeen(itemSourceId,itemId,itemTakenAt);
        }
    }
}
