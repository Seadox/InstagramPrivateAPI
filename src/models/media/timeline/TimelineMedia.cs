using InstagramPrivateAPI.src.models.location;
using InstagramPrivateAPI.src.models.media.timeline;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;
using static InstagramPrivateAPI.src.models.media.timeline.Comment;

namespace InstagrampublicAPI.src.models.media.timeline
{
    internal class TimelineMedia
    {
        public int type { get; set; }
        public string landing_site_type { get; set; }
        public string title { get; set; }
        public string view_all_text { get; set; }
        public string landing_site_title { get; set; }
        public string netego_type { get; set; }
        public bool is_unit_dismissable { get; set; }
        public string ranking_algorithm { get; set; }
        public string multiple_profile_navigation { get; set; }
        public string upsell_fb_pos { get; set; }
        public string auto_dvance { get; set; }
        public string cards_size { get; set; }
        public string id { get; set; }
        public string tracking_token { get; set; }
        public object global_position { get; set; }
        public int? taken_at { get; set; }
        public long? pk { get; set; }
        public long? device_timestamp { get; set; }
        public int? media_type { get; set; }
        public string code { get; set; }
        public string client_cache_key { get; set; }
        public int? filter_type { get; set; }
        public int? carousel_media_count { get; set; }
        public bool? can_see_insights_as_brand { get; set; }
        public bool? is_unified_video { get; set; }
        public bool? should_request_ads { get; set; }
        public Profile user { get; set; }
        public bool? can_viewer_reshare { get; set; }
        public bool? caption_is_edited { get; set; }
        public bool? like_and_view_counts_disabled { get; set; }
        public string commerciality_status { get; set; }
        public bool? is_paid_partnership { get; set; }
        public bool? is_visual_reply_commenter_notice_enabled { get; set; }
        public bool? comment_likes_enabled { get; set; }
        public bool? comment_threading_enabled { get; set; }
        public bool? has_more_comments { get; set; }
        public long? next_max_id { get; set; }
        public int? max_num_visible_preview_comments { get; set; }
        public List<Comment> preview_comments { get; set; }
        public bool? can_view_more_preview_comments { get; set; }
        public int? comment_count { get; set; }
        public bool? hide_view_all_comment_entrypoint { get; set; }
        public string inline_composer_display_condition { get; set; }
        public int? inline_composer_imp_trigger_time { get; set; }
        public int? like_count { get; set; }
        public bool? has_liked { get; set; }
        public List<object> top_likers { get; set; }
        public bool? photo_of_you { get; set; }
        public bool? is_organic_product_tagging_eligible { get; set; }
        public Caption caption { get; set; }
        public bool? can_viewer_save { get; set; }
        public string organic_tracking_token { get; set; }
        public int? has_shared_to_fb { get; set; }
        public string product_type { get; set; }
        public bool? is_in_profile_grid { get; set; }
        public bool? profile_grid_control_enabled { get; set; }
        public int? deleted_reason { get; set; }
        public string integrity_review_decision { get; set; }
        public object music_metadata { get; set; }
        public string main_feed_carousel_starting_media_id { get; set; }
        public bool? main_feed_carousel_has_unseen_cover_media { get; set; }
        public string inventory_source { get; set; }
        public bool? is_seen { get; set; }
        public bool? is_eof { get; set; }
        public double? ranking_weight { get; set; }
        public Location location { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
