using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveJoinRequestsResponse : Response
    {
        public List<Profile> users { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
