using InstagramPrivateAPI.src.models.location;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.location
{
    internal class LocationSearchResponse : Response
    {
        public List<Venue> venues { get; set; }
        public string request_id { get; set; }
        public string rank_token { get; set; }
        public string status { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);

        public class Venue : Location
        {
        }
    }
}
