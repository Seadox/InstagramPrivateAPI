using InstagramPrivateAPI.src.models.media.reel;
using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.feed
{
    internal class Reel
    {
        public long id { get; set; }
        public int latest_reel_media { get; set; }
        public int expiring_at { get; set; }
        public int seen { get; set; }
        public bool can_reply { get; set; }
        public bool can_gif_quick_reply { get; set; }
        public bool can_reshare { get; set; }
        public bool can_react_with_avatar { get; set; }
        public string reel_type { get; set; }
        public object ad_expiry_timestamp_in_millis { get; set; }
        public object is_cta_sticker_available { get; set; }
        public User user { get; set; }
        public List<ReelMedia> items { get; set; }
        public int prefetch_count { get; set; }
        public bool has_besties_media { get; set; }
        public int media_count { get; set; }
        public List<long> media_ids { get; set; }
        public bool has_fan_club_media { get; set; }
    }
}
