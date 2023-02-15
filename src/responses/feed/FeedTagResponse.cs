using InstagramPrivateAPI.src.models.feed;
using InstagrampublicAPI.src.models.media.timeline;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedTagResponse : Response
    {
        public List<TimelineMedia> ranked_items { get; set; }
        public List<TimelineMedia> items { get; set; }
        public Reel story { get; set; }
        public int num_results { get; set; }
        public String next_max_id { get; set; }
        public bool more_available { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
