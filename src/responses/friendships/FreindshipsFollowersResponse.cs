using InstagramPrivateAPI.src.models.friendships;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.friendships
{
    internal class FreindshipsFollowersResponse : Response
    {
        public List<Profile> users { get; set; }
        public bool big_list { get; set; }
        public int page_size { get; set; }
        public List<object> groups { get; set; }
        public bool more_groups_available { get; set; }
        public FriendRequests friend_requests { get; set; }
        public bool should_limit_list_of_followers { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
