using InstagramPrivateAPI.src.models.media.timeline;
using Newtonsoft.Json;
using static InstagramPrivateAPI.src.models.media.timeline.Comment;

namespace InstagramPrivateAPI.src.responses.media
{
    internal class MediaCommentsResponse : Response
    {
        public bool comment_likes_enabled { get; set; }
        public List<Comment> comments { get; set; }
        public int comment_count { get; set; }
        public Caption caption { get; set; }
        public bool caption_is_edited { get; set; }
        public bool has_more_comments { get; set; }
        public bool has_more_headload_comments { get; set; }
        public bool has_comment_spike { get; set; }
        public string media_header_display { get; set; }
        public bool initiate_at_top { get; set; }
        public bool insert_new_comment_to_top { get; set; }
        public bool display_realtime_typing_indicator { get; set; }
        public List<Comment> preview_comments { get; set; }
        public bool can_view_more_preview_comments { get; set; }
        public int scroll_behavior { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
