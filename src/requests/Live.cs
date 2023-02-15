using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.live;
using InstagramPrivateAPI.src.utils;
using Newtonsoft.Json.Linq;
using static InstagramPrivateAPI.src.responses.live.LiveBroadcastLikeResponse;

namespace InstagramPrivateAPI.src.requests
{
    internal class Live
    {
        public LiveInfoResponse getInfo(string broadcastId) => Request.Send<LiveInfoResponse>("live/" + broadcastId + "/info/");

        public LiveBroadcastGetViewerListResponse getViewerList(string broadcastId) => Request.Send<LiveBroadcastGetViewerListResponse>("live/" + broadcastId + "/get_viewer_list/");

        public LiveBroadcastGetViewerListResponse getFinalViewerList(string broadcastId) => Request.Send<LiveBroadcastGetViewerListResponse>("live/" + broadcastId + "/get_final_viewer_list/");

        public LiveBroadcastHeartbeatResponse getHeartbeatAndViewerCount(string broadcastId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<LiveBroadcastHeartbeatResponse>("live/" + broadcastId + "/heartbeat_and_get_viewer_count/", data.ToString());
        }

        public Response showQuestion(string broadcastId, string questionId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("live/" + broadcastId + "/question/" + questionId + "/activate");
        }

        public Response hideQuestion(string broadcastId, string questionId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("live/" + broadcastId + "/question/" + questionId + "/deactivate", data.ToString());
        }

        public Response getQuestions() => Request.Send<Response>("live/get_questions");

        public Response getLiveBroadcastQuestions(string broadcastId) => Request.Send<Response>("live/" + broadcastId + "/questions/?sources=story_and_live");

        public Response pinComment(string broadcastId, string commentId)
        {
            dynamic data = new JObject();
            data.offset_to_video_start = 0;
            data.comment_id = commentId;
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("live/" + broadcastId + "/pin_comment/", data.ToString());
        }

        public Response unpinComment(string broadcastId, string commentId)
        {
            dynamic data = new JObject();
            data.offset_to_video_start = 0;
            data.comment_id = commentId;
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("live/" + broadcastId + "/unpin_comment/", data.ToString());
        }

        public LiveBroadcastGetCommentResponse getComments(string broadcastId, string lastCommentTs = "0", string commentsRequested = "3")
        {
            dynamic data = new JObject();
            data.last_comment_ts = lastCommentTs;
            data.num_comments_requested = commentsRequested;

            return Request.Send<LiveBroadcastGetCommentResponse>("live/" + broadcastId + "/get_comment/");
        }

        public string enableComments(string broadcastId)
        {
            dynamic data = new JObject();
            data._uid = Globals.username_id;
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;
            Request.Send("live/" + broadcastId + "unmute_comment/", data.ToString());
            return Globals.LastResponse;
        }

        public string disableComments(string broadcastId)
        {
            dynamic data = new JObject();
            data._uid = Globals.username_id;
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;
            Request.Send("live/" + broadcastId + "/mute_comment/", data.ToString());
            return Globals.LastResponse;
        }

        public LiveCreateResponse create(string previewWidth = "720", string previewHeight = "1184", string broadcastMessage = "")
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;
            data.preview_height = previewHeight;
            data.preview_width = previewWidth;
            data.broadcast_message = broadcastMessage;
            data.broadcast_type = "RTMP";
            data.internal_only = "0";

            return Request.Send<LiveCreateResponse>("live/create/", data.ToString());
        }

        public LiveStartResponse start(string broadcastId, bool sendNotifications = true)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;
            data.should_send_notifications = Convert.ToInt32(sendNotifications);

            return Request.Send<LiveStartResponse>($"live/{broadcastId}/start/", data.ToString());
        }

        public Response end(string broadcastId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("live/" + broadcastId + "/end_broadcast/", data.ToString());
        }

        public LiveBroadcastLikeResponse like(string broadcastId, string likeCount = "1")
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;
            data.user_like_count = likeCount;

            return Request.Send<LiveBroadcastLikeResponse>($"live/{broadcastId}/like/", data.ToString());
        }

        public LiveJoinRequestsResponse getJoinRequests(string broadcastId) => Request.Send<LiveJoinRequestsResponse>($"live/{broadcastId}/get_join_requests/");
        public LiveQuastionStatusResponse quastionStatus(string broadcastId, bool status)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;
            data.allow_question_submission = status;

            return Request.Send<LiveQuastionStatusResponse>($"live/{broadcastId}/question_status/", data.ToString());
        }

        public LiveBroadcastGetLikeCountResponse getLikeCount(string broadcastId) => Request.Send<LiveBroadcastGetLikeCountResponse>($"live/{broadcastId}/get_like_count/");

        public LiveBroadcastCommentResponse comment(string broadcastId, string message)
        {
            dynamic data = new JObject();
            data.idempotence_token = Signatures.generateUUID(false);
            data.comment_text = message;

            return Request.Send<LiveBroadcastCommentResponse>($"live/{broadcastId}/comment/", data.ToString());
        }

        public LiveBroadcastThumbnailsResponse GetPostLiveThumbnails(string broadcastId) => Request.Send<LiveBroadcastThumbnailsResponse>($"live/{broadcastId}/get_post_live_thumbnails/");
    }
}
