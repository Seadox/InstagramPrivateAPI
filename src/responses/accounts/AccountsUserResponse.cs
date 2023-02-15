using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.accounts
{
    internal class AccountsUserResponse
    {
        public User user;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
