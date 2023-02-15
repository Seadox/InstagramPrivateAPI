using InstagramPrivateAPI.src.models.media.reel;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.media
{
    internal class MediaListReelMediaViewerResponse : Response
    {
        public List<Profile> users { get; set; }
        public String next_max_id { get; set; }
        public int user_count { get; set; }
        public int total_viewer_count { get; set; }
        public ReelMedia updated_media { get; set; }

        public bool isMore_available() => next_max_id != null;
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
