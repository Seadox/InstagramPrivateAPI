using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.live
{
    internal class Info
    {
        public long id { get; set; }
        public string dash_playback_url { get; set; }
        public string dash_abr_playback_url { get; set; }
        public string broadcast_status { get; set; }
        public double viewer_count { get; set; }
        public bool internal_only { get; set; }
        public List<object> cobroadcasters { get; set; }
        public int is_player_live_trace_enabled { get; set; }
        public bool is_gaming_content { get; set; }
        public bool is_live_comment_mention_enabled { get; set; }
        public bool is_live_comment_replies_enabled { get; set; }
        public bool is_viewer_comment_allowed { get; set; }
        public Profile broadcast_owner { get; set; }
        public int published_time { get; set; }
        public bool hide_from_feed_unit { get; set; }
        public double video_duration { get; set; }
        public string media_id { get; set; }
        public long live_post_id { get; set; }
        public string broadcast_message { get; set; }
        public string organic_tracking_token { get; set; }
        public Dimensions dimensions { get; set; }
        public int visibility { get; set; }
        public int response_timestamp { get; set; }
        public class Dimensions
        {
            public int height { get; set; }
            public int width { get; set; }
        }
    }
}
