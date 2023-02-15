using InstagramPrivateAPI.src.models.direct.item;
using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.direct
{
    internal class IGThread
    {
        public bool has_older { get; set; }
        public bool has_newer { get; set; }
        public bool pending { get; set; }
        public List<ThreadItem> items { get; set; }
        public bool canonical { get; set; }
        public string thread_id { get; set; }
        public string thread_v2_id { get; set; }
        public List<Profile> users { get; set; }
        public long viewer_id { get; set; }
        public long last_activity_at { get; set; }
        public bool muted { get; set; }
        public bool vc_muted { get; set; }
        public string encoded_server_data_info { get; set; }
        public List<object> admin_user_ids { get; set; }
        public bool approval_required_for_new_members { get; set; }
        public bool archived { get; set; }
        public bool thread_has_audio_only_call { get; set; }
        public List<object> pending_user_ids { get; set; }
        public Object last_seen_at { get; set; }
        public int relevancy_score { get; set; }
        public int relevancy_score_expr { get; set; }
        public string oldest_cursor { get; set; }
        public string newest_cursor { get; set; }
        public Profile inviter { get; set; }
        public ThreadItem last_permanent_item { get; set; }
        public bool named { get; set; }
        public string next_cursor { get; set; }
        public string prev_cursor { get; set; }
        public string thread_title { get; set; }
        public List<object> left_users { get; set; }
        public bool spam { get; set; }
        public bool bc_partnership { get; set; }
        public bool mentions_muted { get; set; }
        public string thread_type { get; set; }
        public bool thread_has_drop_in { get; set; }
        public object video_call_id { get; set; }
        public bool shh_mode_enabled { get; set; }
        public object shh_toggler_userid { get; set; }
        public bool shh_replay_enabled { get; set; }
        public bool is_group { get; set; }
        public int input_mode { get; set; }
        public int read_state { get; set; }
        public int assigned_admin_id { get; set; }
        public int folder { get; set; }
        public int last_non_sender_item_at { get; set; }
        public int business_thread_folder { get; set; }
        public object theme_data { get; set; }
        public int thread_label { get; set; }
        public bool marked_as_unread { get; set; }
        public List<ThreadContextItem> thread_context_items { get; set; }
        public bool is_close_friend_thread { get; set; }
        public bool has_groups_xac_ineligible_user { get; set; }
        public object thread_image { get; set; }
        public bool is_xac_thread { get; set; }
        public bool is_translation_enabled { get; set; }
        public int translation_banner_impression_count { get; set; }
        public int system_folder { get; set; }
        public bool is_fanclub_subscriber_thread { get; set; }
        public string joinable_group_link { get; set; }
        public int group_link_joinable_mode { get; set; }
        public object smart_suggestion { get; set; }
        public bool is_creator_subscriber_thread { get; set; }
        public object creator_subscriber_thread_response { get; set; }
        public string rtc_feature_set_str { get; set; }

        public class ThreadContextItem
        {
            public int type { get; set; }
            public string text { get; set; }
        }
    }
}
