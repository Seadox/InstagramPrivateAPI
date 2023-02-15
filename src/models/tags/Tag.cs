namespace InstagramPrivateAPI.src.models.tags
{
    internal class Tag
    {
        public object id { get; set; }
        public string name { get; set; }
        public int media_count { get; set; }
        public object follow_status { get; set; }
        public object following { get; set; }
        public object allow_following { get; set; }
        public object allow_muting_story { get; set; }
        public string profile_pic_url { get; set; }
        public object non_violating { get; set; }
        public object related_tags { get; set; }
        public object subtitle { get; set; }
        public object social_context { get; set; }
        public object social_context_profile_links { get; set; }
        public object social_context_facepile_users { get; set; }
        public object follow_button_text { get; set; }
        public object show_follow_drop_down { get; set; }
        public string formatted_media_count { get; set; }
        public object challenge_id { get; set; }
        public object destination_info { get; set; }
        public object description { get; set; }
        public object debug_info { get; set; }
        public object fresh_topic_metadata { get; set; }
        public object promo_banner { get; set; }
    }
}
