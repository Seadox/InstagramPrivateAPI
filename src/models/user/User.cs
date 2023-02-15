using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.models.user
{
    internal class User : Profile
    {
        public bool is_business { get; set; }
        public int media_count { get; set; }
        public int follower_count { get; set; }
        public int following_count { get; set; }
        public String biography { get; set; }
        public String external_url { get; set; }
        public List<ProfilePic> hd_profile_pic_versions { get; set; }
        public ProfilePic hd_profile_pic_url_info { get; set; }
        public int account_type { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public class ProfilePic
        {
            public String url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }
    }
}
