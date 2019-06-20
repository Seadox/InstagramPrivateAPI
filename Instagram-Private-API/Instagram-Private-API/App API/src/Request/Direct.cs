using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Instagram_Private_API.src.Request
{
    class Direct
    {
        public static string getInbox(string cursorId = null)
        {
            dynamic data = new JObject();
            data.persistentBadging = "true";
            data.use_unified_inbox = "true";

            Client.SendRequest("direct_v2/inbox/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getVisualInbox()
        {
            dynamic data = new JObject();
            data.persistentBadging = "true";

            Client.SendRequest("direct_v2/visual_inbox/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getShareInbox()
        {
            Client.SendRequest("direct_share/inbox/?");
            return Globals.LastResponse;
        }

        public static string getPendingInbox()
        {
            dynamic data = new JObject();
            data.persistentBadging = "true";
            data.use_unified_inbox = "true";

            Client.SendRequest("direct_v2/pending_inbox/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getThread(string threadId, string cursorId = null)
        {
            dynamic data = new JObject();
            data.use_unified_inbox = "true";

            Client.SendRequest($"direct_v2/threads/{threadId}/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getPresences()
        {
            Client.SendRequest("direct_v2/get_presence/");
            return Globals.LastResponse;
        }
    }
}
