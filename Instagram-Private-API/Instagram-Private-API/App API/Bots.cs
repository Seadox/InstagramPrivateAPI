using System;
using Newtonsoft.Json.Linq;
using Instagram_Private_API.src.Request;
using Instagram_Private_API.src;
using System.Threading;

namespace Instagram_Private_API
{
    class Bots
    {
        private static JObject o;
        public static void UnFollowing()
        {
            o = JObject.Parse(People.GetFollowing(Globals.username_id));

            foreach (var user in o["users"])
            {
                People.Unfollow((string)user["pk"]);
                Console.WriteLine($"[{DateTime.Now}] UnFollow user: {user["username"]}");
                Thread.Sleep(1500);
            }
        }

        public static void LikeAllUserMedia(String username, string max_id = null)
        {
            o = JObject.Parse(Timeline.GetUserFeed(People.GetUserId(username), max_id));

            foreach (var media in o["items"])
            {
                if (!(bool)media["has_liked"])
                {
                    Media.Like((string)media["id"]);
                    Console.WriteLine($"[{DateTime.Now}] Like media: {media["code"]}");
                    Thread.Sleep(1500);
                }
            }

            if ((bool)o["more_available"])
            {
                max_id = o["next_max_id"].ToString();
                LikeAllUserMedia(username, max_id);
            }
        }

        public static void LikeAllMediaTimline(string max_id = null)
        {
            o = JObject.Parse(Timeline.GetTimelineFeed(max_id));

            foreach (var media in o["items"])
            {
                if (!(bool)media["has_liked"])
                {
                    Media.Like((string)media["id"]);
                    Console.WriteLine($"[{DateTime.Now}] Like madia: {media["code"]}");
                    Thread.Sleep(1500);
                }
            }

            if ((bool)o["auto_load_more_enabled"] && (bool)o["more_available"])
            {
                LikeAllMediaTimline((string)o["next_max_id"]);
            }
        }

        public static void UnfollowFollowers()
        {
            o = JObject.Parse(People.GetFollowing(Globals.username_id));
            foreach (var user in o["users"])
            {
                string pk = (string)user["pk"];
                o = JObject.Parse(People.GetFriendship(pk));
                if (!(bool)o["followed_by"])
                {
                    People.Unfollow(pk);
                    Console.WriteLine($"[{DateTime.Now}] UnFollow user: {user["username"]}");
                    Thread.Sleep(1500);
                }
            }
        }

        public static void Followed_by()
        {
            JObject o = JObject.Parse(People.GetFollowing(Globals.username_id));
            foreach (var user in o["users"])
            {
                JObject jObject = JObject.Parse(People.GetFriendship(user["pk"].ToString()));
                if (!(bool)jObject["followed_by"])
                {
                    Console.WriteLine(user["username"]);
                }
            }
        }

        public static void WatchAllStories()
        {
            Story.getReelsTrayFeed();

                var o = JObject.Parse(Globals.LastResponse)["tray"];

                foreach(var tray in o)
                {
                    var user_pk = tray["user"]["pk"];
                    Story.getUserStoryFeed(user_pk.ToString());

                    var items = JObject.Parse(Globals.LastResponse)["reel"]["items"];
                    
                    foreach(var item in items)
                    {
                        string itemSourceId = item["pk"].ToString();
                        string itemId = item["id"].ToString();
                        string itemTakenAt = item["taken_at"].ToString();

                        Story.markMediaSeen(itemSourceId, itemId, itemTakenAt);
                        Console.WriteLine(Globals.LastResponse);

                        Thread.Sleep(1500);
                    }
                }
        }
    }
}
