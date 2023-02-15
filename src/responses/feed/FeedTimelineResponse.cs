using InstagrampublicAPI.src.models.media.timeline;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedTimelineResponse : Response
    {
        public int num_results { get; set; }
        public bool more_available { get; set; }
        public bool auto_load_more_enabled { get; set; }
        public bool is_direct_v2_enabled { get; set; }
        public string next_max_id { get; set; }
        public string view_state_version { get; set; }
        public bool client_feed_changelist_applied { get; set; }
        public string request_id { get; set; }
        public int pull_to_refresh_window_ms { get; set; }
        public int preload_distance { get; set; }
        public string feed_pill_text { get; set; }
        public int hide_like_and_view_counts { get; set; }
        public int max_num_possible_ad_insertions { get; set; }
        public long last_head_load_ms { get; set; }
        public List<TimelineMedia> items { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
