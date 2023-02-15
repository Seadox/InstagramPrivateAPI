using InstagramPrivateAPI.src.models.direct.item;

namespace InstagramPrivateAPI.src.models.direct
{
    internal class DirectStory
    {
        public List<ThreadRavenMediaItem> items { get; set; }
        public long last_activity_at { get; set; }
        public bool has_newer { get; set; }
        public String next_cursor { get; set; }
    }
}
