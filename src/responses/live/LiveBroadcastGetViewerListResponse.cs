using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveBroadcastGetViewerListResponse : Response
    {
        public List<Profile> users { get; set; }
        public int total_unique_viewer_count { get; set; }
        public string total_unique_viewer_count_formatted { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
