using InstagramPrivateAPI.src.models.feed;
using InstagramPrivateAPI.src.models.live;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedReelsTrayResponse : Response
    {
        public List<Reel> tray { get; set; }
        public List<Broadcast> broadcasts { get; set; }
        public int sticker_version { get; set; }
        public int face_filter_nux_version { get; set; }
        public bool stories_viewer_gestures_nux_eligible { get; set; }
        public int response_timestamp { get; set; }
        public string story_ranking_token { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
