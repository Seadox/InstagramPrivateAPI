using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.media.reel
{
    internal class BlockedReels
    {
        public object sections { get; set; }
        public object global_blacklist_sample { get; set; }
        public List<Profile> users { get; set; }
        public bool big_list { get; set; }
        public object next_max_id { get; set; }
        public int page_size { get; set; }
    }
}
