using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveBroadcastThumbnailsResponse : Response
    {
        public List<String> thumbnails { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
