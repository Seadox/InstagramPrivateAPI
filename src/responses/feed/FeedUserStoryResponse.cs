using InstagramPrivateAPI.src.models.feed;
using InstagramPrivateAPI.src.models.live;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.feed
{
    internal class FeedUserStoryResponse : Response
    {
        public Broadcast broadcast { get; set; }
        public Reel reel { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
