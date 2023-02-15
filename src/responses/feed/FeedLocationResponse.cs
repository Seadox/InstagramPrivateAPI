using InstagramPrivateAPI.src.models.feed;
using InstagramPrivateAPI.src.models.location;
using InstagrampublicAPI.src.models.media.timeline;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedLocationResponse : Response
    {
        public List<TimelineMedia> ranked_items { get; set; }
        public List<TimelineMedia> items { get; set; }
        public int num_results { get; set; }
        public string next_max_id { get; set; }
        public bool more_available { get; set; }
        public bool auto_load_more_enabled { get; set; }
        public Reel story { get; set; }
        public int media_count { get; set; }
        public Location location { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
