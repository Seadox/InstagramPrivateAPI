using InstagramPrivateAPI.src.models.media.timeline;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.media
{
    internal class MediaCommentResponse : Response
    {
        public Comment comment { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
