namespace InstagramPrivateAPI.src.models.tags
{
    internal class Info
    {
        public long id { get; set; }
        public string name { get; set; }
        public int media_count { get; set; }
        public int follow_status { get; set; }
        public int following { get; set; }
        public int allow_following { get; set; }
        public bool allow_muting_story { get; set; }
        public object profile_pic_url { get; set; }
        public int non_violating { get; set; }
        public object related_tags { get; set; }
        public string subtitle { get; set; }
        public string social_context { get; set; }
        public List<object> social_context_profile_links { get; set; }
        public List<object> social_context_facepile_users { get; set; }
        public object follow_button_text { get; set; }
        public bool show_follow_drop_down { get; set; }
        public string formatted_media_count { get; set; }
        public object challenge_id { get; set; }
        public object destination_info { get; set; }
        public object description { get; set; }
        public object debug_info { get; set; }
        public object fresh_topic_metadata { get; set; }
        public object promo_banner { get; set; }
        public string status { get; set; }
    }
}
