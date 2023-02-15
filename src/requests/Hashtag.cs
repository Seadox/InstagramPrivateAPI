using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.feed;
using InstagramPrivateAPI.src.responses.tags;
using InstagramPrivateAPI.src.responses.users;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Hashtag
    {
        public TagsInfoResponse getInfo(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag);//for non-English chars

            return Request.Send<TagsInfoResponse>($"tags/{urlhashtag}/info/");
        }

        public FeedTagResponse getFeed(string hashtag, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag);//for non-English chars

            return Request.Send<FeedTagResponse>($"feed/tag/{urlhashtag}?max_id=" + maxId);
        }

        public TagsSearchResponse search(string query)
        {
            dynamic data = new JObject();
            data.q = query;
            data.timezone_offset = DateTimeOffset.Now.Offset.TotalSeconds;
            data.count = "30";
            data.rank_token = Globals.rank_token;

            return Request.Send<TagsSearchResponse>("tags/search/", data.ToString());
        }

        public Response follow(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag); //for non-English chars
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>($"tags/follow/{urlhashtag}/", data.ToString());
        }

        public Response unfollow(string hashtag)
        {
            string urlhashtag = System.Net.WebUtility.HtmlDecode(hashtag); //for non-English chars
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>($"tags/unfollow/{urlhashtag}/", data.ToString());
        }

        public UserFollowingTagsResponse getFollowing(string userId) => Request.Send<UserFollowingTagsResponse>("users/" + userId + "/following_tags_info/");

        public UserFollowingTagsResponse getSelfFollowing() => getFollowing(Globals.username_id);

        public TagsSuggestedResponse getFollowSuggestions() => Request.Send<TagsSuggestedResponse>("tags/suggested/");

    }
}
