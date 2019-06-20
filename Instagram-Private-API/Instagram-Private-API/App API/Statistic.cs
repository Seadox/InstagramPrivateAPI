using Instagram_Private_API.src.Request;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Instagram_Private_API.App_API
{
    class Statistic
    {
        public static double LikeAverage(string userId)
        {
            JObject o = JObject.Parse(Timeline.GetUserFeed(userId));
            var media_count = o["items"].Count();
            double averge = 0;

            foreach(var media in o["items"])
            {            
                int like_count = (int)media["like_count"];

                averge = averge + like_count;

            }
            return averge/media_count;
        }

        public static double CommentsAverage(string userId)
        {
            JObject o = JObject.Parse(Timeline.GetUserFeed(userId));
            var media_count = o["items"].Count();
            double averge = 0;

            foreach (var media in o["items"])
            {
                int commet_count = (int)media["comment_count"];

                averge = averge + commet_count;

            }
            return averge / media_count;
        }


    }
}
