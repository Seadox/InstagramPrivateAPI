namespace InstagramPrivateAPI.src.models.friendships
{
    internal class FriendRequests
    {
        public int request_count { get; set; }
        public bool request_count_overflow { get; set; }
        public int profile_id { get; set; }
        public string profile_image { get; set; }
        public string sub_text { get; set; }
    }
}
