using InstagrampublicAPI.src.models.media.timeline;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.media
{
    internal class MediaInfoResponse : Response
    {
        public List<TimelineMedia> items { get; set; }
        public int num_results { get; set; }
        public bool more_available { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
