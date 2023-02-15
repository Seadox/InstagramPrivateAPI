using InstagramPrivateAPI.src.models.media.video;

namespace InstagramPrivateAPI.src.models.media
{
    internal class CarouselMedia
    {
        public string id { get; set; }
        public int media_type { get; set; }
        public ImageVersions2 image_versions2 { get; set; }
        public int original_width { get; set; }
        public int original_height { get; set; }
        public List<VideoVersion> video_versions { get; set; }
        public double video_duration { get; set; }
        public int is_dash_eligible { get; set; }
        public string video_dash_manifest { get; set; }
        public string video_codec { get; set; }
        public int number_of_qualities { get; set; }
        public object pk { get; set; }
        public string carousel_parent_id { get; set; }
        public string commerciality_status { get; set; }
    }
}
