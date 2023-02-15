using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.direct;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Direct
    {
        public DirectInboxResponse getInbox(string cursorId = null)
        {
            dynamic data = new JObject();
            data.persistentBadging = "true";
            data.use_unified_inbox = "true";

            return Request.Send<DirectInboxResponse>("direct_v2/inbox/", data.ToString());
        }

        public DirectInboxResponse getPendingInbox()
        {
            dynamic data = new JObject();
            data.persistentBadging = "true";
            data.use_unified_inbox = "true";

            return Request.Send<DirectInboxResponse>("direct_v2/pending_inbox/", data.ToString());
        }

        public ThreadResponse getThread(string threadId, string cursorId = null)
        {
            dynamic data = new JObject();
            data.use_unified_inbox = "true";

            return Request.Send<ThreadResponse>($"direct_v2/threads/{threadId}/", data.ToString());
        }

        public DirectGetPresenceResponse getPresences() => Request.Send<DirectGetPresenceResponse>("direct_v2/get_presence/");

        public Response SendDirectText(string recipients, string threadIds, string text)
        {
            var fields = new Dictionary<string, string> { { "text", text } };
            if (!string.IsNullOrEmpty(recipients))
                fields.Add("recipient_users", "[[" + recipients + "]]");
            else
                fields.Add("recipient_users", "[]");

            if (!string.IsNullOrEmpty(threadIds))
                fields.Add("thread_ids", "[" + threadIds + "]");

            var o = JsonConvert.SerializeObject(fields);

            return Request.Send<Response>("direct_v2/threads/broadcast/text/", o);
        }
    }
}
