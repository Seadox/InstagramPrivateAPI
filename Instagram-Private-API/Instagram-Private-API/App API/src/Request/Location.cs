using Newtonsoft.Json.Linq;

namespace Instagram_Private_API.src.Request
{
    class Location
    {
        public static string search(string latitude, string longitude)
        {
            dynamic data = new JObject();
            data.rank_token = Globals.rank_token;
            data.latitude = latitude;
            data.longitude = longitude;

            Client.SendRequest("location_search/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getFeed(string locationId, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest($"feed/location/{locationId}/&max_id" + maxId);
            return Globals.LastResponse;
        }
    }
}
