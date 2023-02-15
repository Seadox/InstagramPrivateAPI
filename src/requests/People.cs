using InstagramPrivateAPI.src.responses.friendships;
using InstagramPrivateAPI.src.responses.news;
using InstagramPrivateAPI.src.responses.users;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class People
    {
        public UserResponse GetInfoByName(string username) => Request.Send<UserResponse>("users/" + username + "/usernameinfo/");

        public UserResponse GetInfoById(string userId) => Request.Send<UserResponse>("users/" + userId + "/info/");

        public UserResponse GetFullInfoById(string userId) => Request.Send<UserResponse>("users/" + userId + "/full_detail_info/");

        public UserResponse GetSelfInfo() => GetInfoById(Globals.username_id);

        public NewsInboxResponse GetRecentActivityInbox() => Request.Send<NewsInboxResponse>("news/inbox/?activity_module=all&show_su=true");

        public FreindshipsShowResponse GetFriendship(string userId) => Request.Send<FreindshipsShowResponse>("friendships/show/" + userId);

        public FreindshipStatusResponse RemoveFollower(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.user_id = userId;

            return Request.Send<FreindshipStatusResponse>("friendships/remove_follower/" + userId + "/", data.ToString());
        }

        public FreindshipsFollowingResponse GetFollowing(string userId, string maxId = null) => Request.Send<FreindshipsFollowingResponse>("friendships/" + userId + "/following/?rank_token=" + Globals.rank_token + "&max_id=" + (maxId != null ? maxId : ""));

        public FreindshipsFollowersResponse GetFollowers(string userId, string maxId = null) => Request.Send<FreindshipsFollowersResponse>("friendships/" + userId + "/followers/?rank_token=" + Globals.rank_token + "&max_id=" + (maxId != null ? maxId : ""));

        // query = username or name
        public UsersSearchResponse Search(string query) => Request.Send<UsersSearchResponse>("users/search/?rank_token=" + Globals.rank_token + "query" + query);

        public FreindshipStatusResponse Follow(string userId, string mediaId = null)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.csrftoken;
            data.radio_type = "wifi-none";
            data.device_id = Globals.device_id;

            if (mediaId != null)
                data.media_id_attribution = mediaId;


            return Request.Send<FreindshipStatusResponse>("friendships/create/" + userId + "/", data.ToString());
        }

        public FreindshipStatusResponse Unfollow(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.csrftoken;
            data.radio_type = "wifi-none";
            data.device_id = Globals.device_id;

            return Request.Send<FreindshipStatusResponse>("friendships/destroy/" + userId + "/", data.ToString());
        }

        public FreindshipStatusResponse TurnOnUserNotification(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>("friendships/favorite/" + userId + "/", data.ToString());
        }

        public FreindshipStatusResponse TurnOffUserNotification(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>("friendships/unfavorite/" + userId + "/", data.ToString());
        }

        public FreindshipStatusResponse Block(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>("friendships/block/" + userId + "/", data.ToString());
        }

        public FreindshipStatusResponse Unblock(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>("friendships/unblock/" + userId + "/", data.ToString());
        }

        public UsersBlockedListResponse GetBlockedList() => Request.Send<UsersBlockedListResponse>("users/blocked_list/");

        public FreindshipStatusResponse BlockStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.source = "profile";
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>("friendships/block_friend_reel/" + userId + "/", data.ToString());
        }

        public FreindshipStatusResponse UnblockStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.source = "profile";
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>("friendships/unblock_friend_reel/" + userId + "/", data.ToString());
        }

        public UserResponse GetBlockedStoryList()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<UserResponse>("friendships/blocked_reels/", data.ToString());
        }

        public FreindshipStatusResponse muteFriendStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>($"friendships/mute_friend_reel/{userId}/", data.ToString());
        }

        public FreindshipStatusResponse unmuteFriendStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<FreindshipStatusResponse>($"friendships/unmute_friend_reel/{userId}/", data.ToString());
        }

        public string GetUserId(string username) => GetInfoByName(username).user.pk.ToString();
    }
}
