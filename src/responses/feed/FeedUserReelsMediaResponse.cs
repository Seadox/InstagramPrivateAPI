using InstagramPrivateAPI.src.models.feed;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedUserReelsMediaResponse : Response
    {
        public Reel reel { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
