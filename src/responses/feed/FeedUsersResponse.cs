using InstagramPrivateAPI.src.models.media;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedUsersResponse : Response
    {
        public List<Media> items { get; set; }
        public int num_results { get; set; }
        public bool more_available { get; set; }
        public string next_max_id { get; set; }
        public User user { get; set; }
        public bool auto_load_more_enabled { get; set; }

        public bool isMore_available() => next_max_id != null;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
