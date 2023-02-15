using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.feed;
using InstagramPrivateAPI.src.responses.media;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Media
    {
        public MediaInfoResponse GetInfo(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;

            return Request.Send<MediaInfoResponse>("media/" + mediaId + "/info/", data.ToString());
        }

        public Response Delete(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;

            return Request.Send<Response>("media/" + mediaId + "/delete/", data.ToString());
        }

        public MediaInfoResponse Edit(string mediaId, string text)
        {
            dynamic data = new JObject();
            data.caption_text = text;

            return Request.Send<MediaInfoResponse>("media/" + mediaId + "/edit_media/", data.ToString());
        }

        public Response Like(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;
            data.radio_type = "wifi-none";
            data.container_module = "feed_timeline";
            data.is_carousel_bumped_post = false;
            data.device_id = Globals.device_id;


            return Request.Send<Response>("media/" + mediaId + "/like/", data.ToString());
        }

        public Response Unlike(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;

            return Request.Send<Response>("media/" + mediaId + "/unlike/", data.ToString());
        }

        public FeedUsersResponse GetLikers(string mediaId) => Request.Send<FeedUsersResponse>("media/" + mediaId + "/likers/");

        public MediaCommentResponse comment(string mediaId, string commentText)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.comment_text = commentText;

            return Request.Send<MediaCommentResponse>("media/" + mediaId + "/comment/", data.ToString());
        }

        public MediaCommentsResponse GetComments(string mediaId, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            return Request.Send<MediaCommentsResponse>("media/" + mediaId + "/comments/?max_id=" + maxId);
        }

        public Response DeletComment(string mediaId, string commentId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("media/" + mediaId + "/comment/" + commentId + "/delete/", data.ToString());
        }

        public Response LikeComment(string commentId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("media/" + commentId + "/comment_like/", data.ToString());
        }

        public Response UnlikeComment(string commentId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("media/" + commentId + "/comment_unlike/", data.ToString());
        }

        public Response Save(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("media/" + mediaId + "/save/", data.ToString());
        }

        public Response UnSave(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("media/" + mediaId + "/unsave/", data.ToString());
        }

        public Response GetBlockedMedia()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("media/blocked/", data.ToString());
        }

        public string GetID(string url)
        {
            string[] urlexplode = url.Split(new[] { "/" }, StringSplitOptions.None);
            string code = urlexplode[4];
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_".ToCharArray();

            long n = 0;
            for (int i = 0; i < code.Length; i++)
            {
                var c = code[i];
                n = n * 64 + Array.IndexOf(alphabet, c);

                if (i == 10) break;
            }
            return n.ToString();
        }
    }
}
