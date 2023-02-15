using InstagramPrivateAPI.src.responses.discover;
using InstagramPrivateAPI.src.utils;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Discover
    {
        public DiscoverTopicalExploreResponse getExploreFeed(string maxId = null, bool isPrefetch = false)
        {
            dynamic data = new JObject();
            data.is_prefetch = isPrefetch;
            data.is_from_promote = false;
            data.timezone_offset = DateTimeOffset.Now.Offset.TotalSeconds;
            data.session_id = Signatures.generateUUID(true);

            return Request.Send<DiscoverTopicalExploreResponse>("discover/topical_explore/");
        }
    }
}
