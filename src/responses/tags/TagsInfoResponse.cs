using InstagramPrivateAPI.src.models.tags;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.tags
{
    internal class TagsInfoResponse : Response
    {
        public Info info { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
