namespace InstagramPrivateAPI.src.models.user
{
    internal class Profile
    {
        public long pk { get; set; }
        public String username { get; set; }
        public String full_name { get; set; }
        public bool is_private { get; set; }
        public String profile_pic_url { get; set; }
        public String profile_pic_id { get; set; }
        public bool is_verified { get; set; }
        public bool has_anonymous_profile_picture { get; set; }
    }
}
