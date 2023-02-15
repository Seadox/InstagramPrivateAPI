using InstagramPrivateAPI.src.models.live;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveInfoResponse : Response
    {
        public Info info { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
