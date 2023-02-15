using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveBroadcastHeartbeatResponse : Response
    {
        public int viewer_count { get; set; }
        public String broadcast_status { get; set; }
        public String[] cobroadcaster_ids { get; set; }
        public int offset_to_video_start { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
