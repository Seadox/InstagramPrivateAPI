using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveStartResponse : Response
    {
        public String media_id { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
