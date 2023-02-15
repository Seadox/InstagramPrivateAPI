using InstagramPrivateAPI.src.responses;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace InstagramPrivateAPI.src.requests
{
    internal class Map
    {
        public Response search(double latitude, double longitude)
        {
            string data = $"?map_center_lat={latitude.ToString(CultureInfo.InvariantCulture)}&map_center_lng={longitude.ToString(CultureInfo.InvariantCulture)}&rank_token={Globals.rank_token}&timestamp={(int)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds}";

            return Request.Send<Response>("map/search/" + data);
        }

        public Response Story(double latitude, double longitude)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<Response>("map/location_stories/", data.ToString());
        }


    }
}
