using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.live
{
    internal class Broadcast
    {
        public String id { get; set; }
        public String dash_playback_url { get; set; }
        public String dash_abr_playback_url { get; set; }
        public String dash_live_predictive_playback_url { get; set; }
        public String broadcast_status { get; set; }
        public int viewer_count { get; set; }
        public String cover_frame_url { get; set; }
        public User broadcast_owner { get; set; }
        public long published_time { get; set; }
        public String media_id { get; set; }
        public String broadcast_message { get; set; }
    }
}
