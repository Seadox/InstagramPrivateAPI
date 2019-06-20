using Newtonsoft.Json.Linq;
using System;

namespace Instagram_Private_API.src.Request
{
    class Media
    {
        public static string GetInfo(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;
            Client.SendRequest("media/" + mediaId + "/info/", data.ToString());
            return Globals.LastResponse;
        }

        public static string Delete(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;
            Client.SendRequest("media/" + mediaId + "/delete/", data.ToString());
            return Globals.LastResponse;
        }

        public static void Edit(string mediaId, string text)
        {
            dynamic data = new JObject();
            data.caption_text = text;

            Client.SendRequest("media/" + mediaId + "/edit_media/", data.ToString());
        }

        public static string Like(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;

            Client.SendRequest("media/" + mediaId + "/like/", data.ToString());
            return Globals.LastResponse;
        }

        public static string Unlike(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.media_id = mediaId;

            Client.SendRequest("media/" + mediaId + "/unlike/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetLikedFeed(string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest("feed/liked/&max_id" + maxId);
            return Globals.LastResponse;
        }

        public static string GetLikers(string mediaId)
        {
            Client.SendRequest("media/" + mediaId + "/likers/");
            return Globals.LastResponse;
        }

        public static string comment(string mediaId, string commentText)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.comment_text = commentText;

            Client.SendRequest("media/" + mediaId + "/comment/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetComments(string mediaId, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest("media/" + mediaId + "/comments/?max_id=" + maxId);
            return Globals.LastResponse;
        }

        public static string DeletComment(string mediaId, string commentId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("media/" + mediaId + "/comment/" + commentId + "/delete/", data.ToString());
            return Globals.LastResponse;
        }

        public static string LikeComment(string commentId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("media/" + commentId + "/comment_like/", data.ToString());
            return Globals.LastResponse;
        }

        public static string UnlikeComment(string commentId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("media/" + commentId + "/comment_unlike/", data.ToString());
            return Globals.LastResponse;
        }

        public static string Save(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("media/" + mediaId + "/save/", data.ToString());
            return Globals.LastResponse;
        }

        public static string UnSave(string mediaId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("media/" + mediaId + "/unsave/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetSavedFeed(string maxId = null)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            maxId = maxId != null ? maxId : "";
            Client.SendRequest("feed/saved/?max_id=" + maxId, data.ToString());
            return Globals.LastResponse;
        }

        public static string GetBlockedMedia()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("media/blocked/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetID(string url)
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
