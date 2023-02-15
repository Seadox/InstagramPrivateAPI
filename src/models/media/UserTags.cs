using InstagramPrivateAPI.src.models.user;

namespace InstagramPrivateAPI.src.models.media
{
    internal class UserTags
    {
        public class UserTag
        {
            public Profile user;
            public double[] position;
            public long start_time_in_video_sec;
            public long duration_in_video_in_sec;
        }
    }
}
