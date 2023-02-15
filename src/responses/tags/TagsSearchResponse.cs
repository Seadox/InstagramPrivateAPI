using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.tags
{
    internal class TagsSearchResponse : Response
    {
        public String rank_token { get; set; }
        public String page_token { get; set; }
        public String status { get; set; }
        public bool has_more { get; set; }
        public List<SearchTagTag> results { get; set; }

        public class SearchTagTag
        {
            public long id { get; set; }
            public String name { get; set; }
            public String formatted_media_count { get; set; }
            public String search_result_subtitle { get; set; }
            public String profile_pic_url { get; set; }
            public int media_count { get; set; }
            public bool use_default_avatar { get; set; }
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
