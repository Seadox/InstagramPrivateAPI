namespace InstagramPrivateAPI.src.models.friendships
{
    internal class Friendship
    {
        public bool following { get; set; }
        public bool followed_by { get; set; }
        public bool blocking { get; set; }
        public bool muting { get; set; }
        public bool is_private { get; set; }
        public bool incoming_request { get; set; }
        public bool outgoing_request { get; set; }
        public bool is_blocking_reel { get; set; }
        public bool is_muting_reel { get; set; }
        public bool is_bestie { get; set; }
        public bool is_restricted { get; set; }
        public bool is_feed_favorite { get; set; }
    }
}
