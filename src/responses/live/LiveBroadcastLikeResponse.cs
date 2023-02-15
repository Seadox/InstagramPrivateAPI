using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveBroadcastLikeResponse : Response
    {
        public String likes;
        public String burst_likes;

        public class LiveBroadcastGetLikeCountResponse : LiveBroadcastLikeResponse
        {
            public int likes { get; set; }
            public int burst_likes { get; set; }
            public List<Liker> likers { get; set; }
            public int like_ts { get; set; }

            public class Liker
            {
                public String user_id;
                public String profile_pic_url;
                public int count;
            }
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
