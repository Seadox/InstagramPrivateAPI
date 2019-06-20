using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;

namespace Instagram_Private_API.src.Request
{
    class Internal
    {
        public static string uploadPhoto(string file_location)
        {
            int timestamp = (int)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
            string upload_id = timestamp.ToString();

            var requestContent = new MultipartFormDataContent(upload_id)
                {
                    {new StringContent(upload_id), "\"upload_id\""},
                    {new StringContent(Globals.uuid), "\"_uuid\""},
                    {new StringContent(Globals.csrftoken), "\"_csrftoken\""},
                    {
                        new StringContent("{\"lib_name\":\"jt\",\"lib_version\":\"1.3.0\",\"quality\":\"87\"}"),
                        "\"image_compression\""
                    }
                };

            var imageContent = new ByteArrayContent(File.ReadAllBytes(file_location));


            requestContent.Add(imageContent, "photo", $"pending_media_{upload_id}.jpg");


            var client = new HttpClient();
            using (var message = client.PostAsync(Constants.API_URLS[0] + "upload/photo/", requestContent))
            {
                Console.WriteLine(message);

            }


            Console.WriteLine(Globals.LastResponse);
            configure(upload_id, imageContent.ToString(), "");
            return Globals.LastResponse;
        }

        public static string configure(string upload_id, string photo, string caption)
        {
            var data = new JObject
                {
                    {"_uuid", Globals.uuid},
                    {"_uid", Globals.username_id},
                    {"_csrftoken", Globals.csrftoken},
                    {"media_folder", "Instagram"},
                    {"source_type", "4"},
                    {"caption", caption},
                    {"upload_id", upload_id},
                    {
                        "device", new JObject
                        {
                            {"manufacturer", Device_Settings.manufacturer},
                            {"model", Device_Settings.model},
                            {"android_version", Device_Settings.android_version},
                            {"android_release", Device_Settings.android_release}
                        }
                    },
                    {
                        "edits", new JObject
                        {
                            {"crop_original_size", new JArray {1080, 1080}},
                            {"crop_center", new JArray {0.0, -0.0}},
                            {"crop_zoom", 1.0}
                        }
                    },
                    {
                        "extra", new JObject
                        {
                            {"source_width", 1080},
                            {"source_height", 1080}
                        }
                    }
                };
            Client.SendRequest("media/configure/?", data.ToString());
            Console.WriteLine(Globals.LastResponse);
            return Globals.LastResponse;
        }

        public static string markStoryMediaSeen(string itemSourceId, string itemId, string itemTakenAt)
        {
            Int32 maxSeenAt = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int seenAt = maxSeenAt - 3;

            string reelId = itemId + "_" + itemSourceId;

            JObject data = new JObject(
                    new JProperty("_uuid", Globals.uuid),
                    new JProperty("_uid", Globals.username_id),
                    new JProperty("_csrftoken", Globals.csrftoken),
                    new JProperty("live_vods", new JArray()),
                    new JProperty("reels", new JObject(new JProperty(reelId, new JArray(itemTakenAt + "_" + seenAt)))),
                    new JProperty("reel", 1),
                    new JProperty("live_vod", 0)
                    );

            Client.SendRequest("media/seen/", data.ToString(), true, 1);

            return Globals.LastResponse;
        }
    }
}
