namespace InstagramPrivateAPI.src.models.media
{
    internal class Thumbnails
    {
        public double video_length { get; set; }
        public int thumbnail_width { get; set; }
        public int thumbnail_height { get; set; }
        public double thumbnail_duration { get; set; }
        public List<string> sprite_urls { get; set; }
        public int thumbnails_per_row { get; set; }
        public int total_thumbnail_num_per_sprite { get; set; }
        public int max_thumbnails_per_sprite { get; set; }
        public int sprite_width { get; set; }
        public int sprite_height { get; set; }
        public int rendered_width { get; set; }
        public int file_size_kb { get; set; }
    }
}
