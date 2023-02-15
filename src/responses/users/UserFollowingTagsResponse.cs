using InstagramPrivateAPI.src.models.tags;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.users
{
    internal class UserFollowingTagsResponse : Response
    {
        public List<Tag> tags { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
