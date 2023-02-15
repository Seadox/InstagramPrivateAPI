using InstagramPrivateAPI.src.models.discover;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.discover
{
    internal class DiscoverTopicalExploreResponse : Response
    {
        public List<SectionalItem> sectional_items;
        public String rank_token;
        public List<Cluster> clusters;
        public String next_max_id;
        public bool more_available;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
