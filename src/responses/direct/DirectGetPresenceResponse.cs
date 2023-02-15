using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.direct
{
    internal class DirectGetPresenceResponse : Response
    {
        public Dictionary<long, UserPresence> user_presence { get; set; }

        public class UserPresence
        {
            public bool is_active { get; set; }
            public long last_activity_at_ms { get; set; }
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
