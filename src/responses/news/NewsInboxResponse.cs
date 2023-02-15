using InstagramPrivateAPI.src.models.news;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.news
{
    internal class NewsInboxResponse : Response
    {
        public NewsCounts counts;
        public List<NewsStory> new_stories;
        public List<NewsStory> old_stories;

        public class NewsCounts
        {
            public int likes { get; set; }
            public int comments { get; set; }
            private int shopping_notification { get; set; }
            public int usertags { get; set; }
            public int relationships { get; set; }
            public int campaign_notification { get; set; }
            public int comment_likes { get; set; }
            public int photos_of_you { get; set; }
            public int requests { get; set; }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
