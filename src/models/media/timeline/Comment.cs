using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.media.timeline
{
    internal class Comment
    {
        public string content_type { get; set; }
        public User user { get; set; }
        public long pk { get; set; }
        public string text { get; set; }
        public int type { get; set; }
        public int created_at { get; set; }
        public int created_at_utc { get; set; }
        public long media_id { get; set; }
        public string status { get; set; }
        public bool share_enabled { get; set; }

        public class Caption : Comment
        {

        }
    }
}
