using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.users
{
    internal class UserResponse : Response
    {
        public User user;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
