using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.location
{
    internal class LocationInfoResponse : Response
    {
        public string location_id { get; set; }
        public string facebook_places_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string category { get; set; }
        public int price_range { get; set; }
        public Hours hours { get; set; }
        public object lat { get; set; }
        public object lng { get; set; }
        public string location_address { get; set; }
        public string location_city { get; set; }
        public int location_region { get; set; }
        public string location_zip { get; set; }
        public bool show_location_page_survey { get; set; }
        public int num_guides { get; set; }
        public bool has_menu { get; set; }
        public PageEffectInfo page_effect_info { get; set; }

        public class PageEffectInfo
        {
            public int num_effects { get; set; }
            public object thumbnail_url { get; set; }
            public object effect { get; set; }
        }

        public class Hours : Response
        {
            public string current_status { get; set; }
            public string hours_today { get; set; }
            public List<object> schedule { get; set; }
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
