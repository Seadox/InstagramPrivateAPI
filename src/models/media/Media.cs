using InstagramPrivateAPI.src.models.media.video;
using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.media
{
    internal class Media
    {
        public int taken_at { get; set; }
        public object pk { get; set; }
        public string id { get; set; }
        public object device_timestamp { get; set; }
        public int media_type { get; set; }
        public string code { get; set; }
        public string client_cache_key { get; set; }
        public int filter_type { get; set; }
        public bool is_unified_video { get; set; }
        public bool should_request_ads { get; set; }
        public User user { get; set; }
        public bool can_viewer_reshare { get; set; }
        public bool caption_is_edited { get; set; }
        public bool like_and_view_counts_disabled { get; set; }
        public string commerciality_status { get; set; }
        public bool is_paid_partnership { get; set; }
        public bool is_visual_reply_commenter_notice_enabled { get; set; }
        public bool comment_likes_enabled { get; set; }
        public bool comment_threading_enabled { get; set; }
        public bool has_more_comments { get; set; }
        public int max_num_visible_preview_comments { get; set; }
        public bool can_view_more_preview_comments { get; set; }
        public int comment_count { get; set; }
        public bool hide_view_all_comment_entrypoint { get; set; }
        public string inline_composer_display_condition { get; set; }
        public int inline_composer_imp_trigger_time { get; set; }
        public string title { get; set; }
        public string product_type { get; set; }
        public bool nearly_complete_copyright_match { get; set; }
        public Thumbnails thumbnails { get; set; }
        public bool igtv_exists_in_viewer_series { get; set; }
        public bool is_post_live { get; set; }
        public ImageVersions2 image_versions2 { get; set; }
        public int original_width { get; set; }
        public int original_height { get; set; }
        public int like_count { get; set; }
        public bool has_liked { get; set; }
        public List<object> top_likers { get; set; }
        public List<object> likers { get; set; }
        public bool photo_of_you { get; set; }
        public bool is_organic_product_tagging_eligible { get; set; }
        public bool can_see_insights_as_brand { get; set; }
        public int is_dash_eligible { get; set; }
        public string video_dash_manifest { get; set; }
        public string video_codec { get; set; }
        public int number_of_qualities { get; set; }
        public List<VideoVersion> video_versions { get; set; }
        public bool has_audio { get; set; }
        public double video_duration { get; set; }
        public object caption { get; set; }
        public bool can_viewer_save { get; set; }
        public string organic_tracking_token { get; set; }
        public int has_shared_to_fb { get; set; }
        public bool is_in_profile_grid { get; set; }
        public bool profile_grid_control_enabled { get; set; }
        public bool video_subtitles_enabled { get; set; }
        public int deleted_reason { get; set; }
        public string integrity_review_decision { get; set; }
        public int? carousel_media_count { get; set; }
        public List<CarouselMedia> carousel_media { get; set; }

    }
}
