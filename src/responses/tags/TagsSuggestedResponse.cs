using InstagramPrivateAPI.src.models.tags;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.tags
{
    internal class TagsSuggestedResponse : Response
    {
        public List<Tag> tags { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
