using Newtonsoft.Json.Linq;

namespace Instagram_Private_API.src.Request
{
    class People
    {
        public static string GetInfoByName(string username)
        {
            Client.SendRequest("users/" + username + "/usernameinfo/");
            return Globals.LastResponse;
        }

        public static string GetInfoById(string userId)
        {
            Client.SendRequest("users/" + userId + "/info/");
            return Globals.LastResponse;
        }

        public static string GetSelfInfo()
        {
            GetInfoById(Globals.username_id);
            return Globals.LastResponse;
        }

        public static string GetRecentActivityInbox()
        {
            Client.SendRequest("news/inbox/?activity_module=all&show_su=true");
            return Globals.LastResponse;
        }

        public static string GetFollowingRecentActivity(string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest("news/?max_id=" + maxId);

            return Globals.LastResponse;
        }

        public static string GetFriendship(string userId)
        {
            Client.SendRequest("friendships/show/" + userId);
            return Globals.LastResponse;
        }

        public static string RemoveFollower(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.user_id = userId;

            Client.SendRequest("friendships/remove_follower/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetFollowing(string userId, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest("friendships/" + userId + "/following/?rank_token=" + Globals.rank_token + "&max_id=" + maxId);

            return Globals.LastResponse;
        }

        public static string GetFollowers(string userId, string maxId = null)
        {
            maxId = maxId != null ? maxId : "";
            Client.SendRequest("friendships/" + userId + "/followers/?rank_token=" + Globals.rank_token + "&max_id=" + maxId);

            return Globals.LastResponse;
        }

        // query = username or name
        public static string Search(string query)
        {
            Client.SendRequest("users/search/?rank_token=" + Globals.rank_token + "query" + query);
            return Globals.LastResponse;
        }

        public static string Follow(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/create/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string Unfollow(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/destroy/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string TurnOnUserNotification(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/favorite/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string TurnOffUserNotification(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/unfavorite/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string Block(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/block/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string Unblock(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.user_id = userId;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/unblock/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetBlockedList()
        {
            Client.SendRequest("users/blocked_list/");
            return Globals.LastResponse;
        }

        public static string BlockStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.source = "profile";
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/block_friend_reel/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string UnblockStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.source = "profile";
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/unblock_friend_reel/" + userId + "/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetBlockedStoryList()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("friendships/blocked_reels/", data.ToString());
            return Globals.LastResponse;
        }

        public static string muteFriendStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest($"friendships/mute_friend_reel/{userId}/", data.ToString());
            return Globals.LastResponse;
        }

        public static string unmuteFriendStory(string userId)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest($"friendships/unmute_friend_reel/{userId}/", data.ToString());
            return Globals.LastResponse;
        }

        public static string GetUserId(string username)
        {
            JObject info = JObject.Parse(GetInfoByName(username));
            return info["user"]["pk"].ToString();
        }
    }
}
