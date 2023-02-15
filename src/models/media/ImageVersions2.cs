namespace InstagramPrivateAPI.src.models.media
{
    internal class ImageVersions2
    {
        public List<Candidate> candidates { get; set; }
    }
    public class Candidate
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public string scans_profile { get; set; }
        public List<int> estimated_scans_sizes { get; set; }
    }
}
