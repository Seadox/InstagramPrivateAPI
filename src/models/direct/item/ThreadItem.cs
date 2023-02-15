namespace InstagramPrivateAPI.src.models.direct.item
{
    internal class ThreadItem
    {
        public String item_id { get; set; }
        public long user_id { get; set; }
        public long timestamp { get; set; }
        public String item_type { get; set; }
        public String client_context { get; set; }
        public bool show_forward_attribution { get; set; }
    }
}
