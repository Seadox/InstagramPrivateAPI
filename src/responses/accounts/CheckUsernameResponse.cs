using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.accounts
{
    internal class CheckUsernameResponse : Response
    {
        public class Suggestion
        {
            public string username { get; set; }
            public string prototype { get; set; }
        }

        public class SuggestionsWithMetadata
        {
            public List<Suggestion> suggestions { get; set; }
        }

        public class UsernameSuggestions
        {
            public SuggestionsWithMetadata suggestions_with_metadata { get; set; }
        }
        public string username { get; set; }
        public bool available { get; set; }
        public bool existing_user_password { get; set; }
        public string error { get; set; }
        public UsernameSuggestions username_suggestions { get; set; }
        public string status { get; set; }
        public string error_type { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
