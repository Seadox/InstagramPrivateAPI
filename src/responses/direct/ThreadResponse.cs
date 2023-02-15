using InstagramPrivateAPI.src.models.direct;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.direct
{
    internal class ThreadResponse : Response
    {
        public IGThread thread { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
