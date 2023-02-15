using InstagramPrivateAPI.src.models.feed;
using InstagramPrivateAPI.src.responses.feed;
using InstagramPrivateAPI.src.responses.location;
using System.Globalization;

namespace InstagramPrivateAPI.src.requests
{
    internal class Location
    {
        public LocationSearchResponse search(double latitude, double longitude, string query = null)
        {
            string data = $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&rank_token={Globals.rank_token}&timestamp={(int)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds}";

            return Request.Send<LocationSearchResponse>("location_search/" + data);
        }

        public LocationInfoResponse info(string location_id) => Request.Send<LocationInfoResponse>("locations/" + location_id + "/location_info");

        public FeedLocationResponse getFeed(string location_id) => Request.Send<FeedLocationResponse>("feed/location/" + location_id);

        public Reel getStoryFeed(string location_id) => getFeed(location_id).story;
    }
}
