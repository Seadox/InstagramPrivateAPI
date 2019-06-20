using Newtonsoft.Json.Linq;
using System;

namespace Instagram_Private_API.src.Request
{
    class Live
    {
        public static string create(string previewWidth = "720", string previewHeight = "1184", string broadcastMessage = "")
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;
            data.preview_height = previewHeight;
            data.preview_width = previewWidth;
            data.broadcast_message = broadcastMessage;
            data.broadcast_type = "RTMP";
            data.internal_only = "0";

            Client.SendRequest("live/create/", data.ToString());
            return Globals.LastResponse;
        }

        public static string start(string broadcastId, bool sendNotifications = true)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._csrftoken = Globals.csrftoken;
            data.should_send_notifications = Convert.ToInt32(sendNotifications);
            Client.SendRequest($"live/{broadcastId}/start/", data.ToString());
            return Globals.LastResponse;
        }

        public static string addToPostLive(string broadcastId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest($"live/{broadcastId}/add_to_post_live/");
            return Globals.LastResponse;
        }

        public static string like(string broadcastId, string likeCount = "1")
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;
            data.user_like_count = likeCount;

            Client.SendRequest($"live/{broadcastId}/like/", data.ToString());
            return Globals.LastResponse;
        }
    }
}
