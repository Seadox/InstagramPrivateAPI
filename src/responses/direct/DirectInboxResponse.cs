using InstagramPrivateAPI.src.models.direct;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.direct
{
    internal class DirectInboxResponse : Response
    {
        public User viewer { get; set; }
        public Inbox inbox { get; set; }
        public int seq_id { get; set; }
        public object mixed_pending_inbox_sequence_id { get; set; }
        public long snapshot_at_ms { get; set; }
        public int pending_requests_total { get; set; }
        public bool has_pending_top_requests { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
