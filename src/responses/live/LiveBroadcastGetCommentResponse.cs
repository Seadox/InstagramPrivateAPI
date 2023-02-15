using InstagramPrivateAPI.src.models.media.timeline;
using Newtonsoft.Json;
using static InstagramPrivateAPI.src.models.media.timeline.Comment;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveBroadcastGetCommentResponse : Response
    {
        public bool comment_likes_enabled { get; set; }
        public List<Comment> comments { get; set; }
        public int comment_count { get; set; }
        public Caption caption { get; set; }
        public bool caption_is_edited { get; set; }
        public bool has_more_comments { get; set; }
        public bool has_more_headload_comments { get; set; }
        public string media_header_display { get; set; }
        public bool can_view_more_preview_comments { get; set; }
        public int live_seconds_per_comment { get; set; }
        public string is_first_fetch { get; set; }
        public List<object> visible_comments { get; set; }
        public List<object> system_comments { get; set; }
        public int comment_muted { get; set; }
        public bool is_viewer_comment_allowed { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
