using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.friendships
{
    internal class FreindshipsFollowingResponse : Response
    {
        public List<Profile> users { get; set; }
        public bool big_list { get; set; }
        public int page_size { get; set; }
        public bool should_limit_list_of_followers { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
