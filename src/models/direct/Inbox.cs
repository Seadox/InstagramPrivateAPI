namespace InstagramPrivateAPI.src.models.direct
{
    internal class Inbox
    {
        public List<IGThread> threads { get; set; }
        public bool has_older { get; set; }
        public int unseen_count { get; set; }
        public long unseen_count_ts { get; set; }
        public String oldest_cursor { get; set; }
        public Cursor prev_cursor { get; set; }
        public Cursor next_cursor { get; set; }
        public bool blended_inbox_enabled { get; set; }

        public class Cursor
        {
            public String cursor_timestamp_seconds { get; set; }
            public String cursor_thread_v2_id { get; set; }
        }
    }
}
