using InstagramPrivateAPI.src.models.friendships;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.users
{
    internal class UsersSearchResponse : Response
    {
        private int num_results { get; set; }
        private List<User> users { get; set; }
        private bool has_more { get; set; }
        private String rank_token { get; set; }
        private String page_token { get; set; }

        public class User : Profile
        {
            Friendship friendship_status { get; set; }
            String social_context { get; set; }
            String search_social_context { get; set; }
            int mutual_followers_count { get; set; }
            int latest_reel_media { get; set; }
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
