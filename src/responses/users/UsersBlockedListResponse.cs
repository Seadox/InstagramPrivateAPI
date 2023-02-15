namespace InstagramPrivateAPI.src.responses.users
{
    internal class UsersBlockedListResponse : Response
    {
        public List<BlockedUser> blocked_list { get; set; }

        public class BlockedUser
        {
            public long user_id { get; set; }
            public String username { get; set; }
            public String full_name { get; set; }
            public String profile_pic_url { get; set; }
            public long block_at { get; set; }
            public bool is_auto_block_enabled { get; set; }
        }
    }
}
