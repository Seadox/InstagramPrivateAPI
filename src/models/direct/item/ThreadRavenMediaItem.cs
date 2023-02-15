using InstagramPrivateAPI.src.models.media.thread;

namespace InstagramPrivateAPI.src.models.direct.item
{
    internal class ThreadRavenMediaItem : ThreadItem
    {
        public ThreadVisualMedia visual_media { get; set; }

        public class ThreadVisualMedia
        {
            public long url_expire_at_secs { get; set; }
            public int playback_duration_secs { get; set; }
            public ThreadMedia media { get; set; }
            public List<String> seen_user_ids { get; set; }
            public String view_mode { get; set; }
            public int seen_count { get; set; }
        }
    }
}
