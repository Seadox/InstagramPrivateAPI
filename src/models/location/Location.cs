namespace InstagramPrivateAPI.src.models.location
{
    internal class Location
    {
        public object pk { get; set; }
        public string short_name { get; set; }
        public long external_id { get; set; }
        public object facebook_places_id { get; set; }
        public string external_source { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public bool has_viewer_saved { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
        public bool is_eligible_for_guides { get; set; }
    }
}
