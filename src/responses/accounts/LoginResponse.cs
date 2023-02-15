using InstagramPrivateAPI.src.models.user;
using InstagramPrivateAPI.src.responses.challenge;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.accounts
{
    internal class LoginResponse : Response
    {
        public User logged_in_user { get; set; }
        public Challenge challenge { get; set; }
        public TwoFactorInfo two_factor_info { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public class TwoFactorInfo
        {
            public string two_factor_identifier { get; set; }
        }
    }
}
