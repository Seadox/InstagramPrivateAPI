namespace InstagramPrivateAPI.src.models.user
{
    internal class Besties
    {
        public object sections { get; set; }
        public object global_blacklist_sample { get; set; }
        public List<Profile> users { get; set; }
        public bool big_list { get; set; }
        public object next_max_id { get; set; }
        public int page_size { get; set; }
    }
}
