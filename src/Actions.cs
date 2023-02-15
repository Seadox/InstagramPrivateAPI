using System.Net;

namespace InstagramPrivateAPI.src
{
    internal class Actions
    {
        private Client client;
        public Actions(Client c)
        {
            client = c;
        }
        public void UnFollowAll()
        {
            var following = client.people.GetFollowing(Globals.username_id);

            foreach (var user in following.users)
            {
                client.people.Unfollow(user.pk.ToString());
                Console.WriteLine($"[{DateTime.Now}] UnFollow user: {user.username}");
                Thread.Sleep(new Random().Next(15, 30) * 100);//1500-3000
            }
        }

        public void LikeAllUserMedia(String username, string max_id = null)
        {
            var timeline = client.timeline.GetUserFeed(client.people.GetUserId(username), max_id);

            foreach (var media in timeline.items)
            {
                if (!media.has_liked)
                {
                    client.media.Like(media.id);
                    Console.WriteLine($"[{DateTime.Now}] Like media: {media.code}");
                    Thread.Sleep(1500);
                }
            }

            if ((bool)timeline.more_available)
            {
                max_id = timeline.next_max_id.ToString();
                LikeAllUserMedia(username, max_id);
            }
        }
        public void LikeAllMediaTimline(string max_id = null)
        {
            var timeline = client.timeline.GetTimelineFeed(max_id);

            foreach (var media in timeline.items)
            {
                if (!(bool)media.has_liked)
                {
                    client.media.Like(media.id);
                    Console.WriteLine($"[{DateTime.Now}] Like madia: {media.code}");
                    Thread.Sleep(1500);
                }
            }

            if (timeline.auto_load_more_enabled && timeline.more_available)
                LikeAllMediaTimline(timeline.next_max_id);
        }
        public void UnfollowFollowers()
        {
            var following = client.people.GetFollowing(Globals.username_id);
            foreach (var user in following.users)
            {
                string pk = user.pk.ToString();
                var freindShip = client.people.GetFriendship(pk);
                if (!freindShip.friendship.followed_by)
                {
                    client.people.Unfollow(pk);
                    Console.WriteLine($"[{DateTime.Now}] UnFollow user: {user.username}");
                    Thread.Sleep(1500);
                }
            }
        }
        public void Followed_by()
        {
            var followers = client.people.GetFollowers(Globals.username_id);
            var following = client.people.GetFollowing(Globals.username_id);

            Dictionary<int, string> map = new Dictionary<int, string>();

            int counter = 0;
            foreach (var user in followers.users)
                map.Add(counter++, user.pk.ToString());

            foreach (var user in following.users)
            {
                if (!map.ContainsValue(user.pk.ToString()))
                    Console.WriteLine(user.username);
            }
        }
        public void WatchAllStories()
        {
            var reels = client.story.getReelsTrayFeed().tray;

            foreach (var tray in reels)
            {
                var user_pk = tray.user.pk;
                var items = client.story.getUserStoryFeed(user_pk.ToString()).reel.items;

                foreach (var item in items)
                {
                    string itemSourceId = item.pk.ToString();
                    string itemId = item.id.ToString();
                    string itemTakenAt = item.taken_at.ToString();

                    client.story.markMediaSeen(itemSourceId, itemId, itemTakenAt);
                    //Thread.Sleep(1500);
                }
            }
        }
        public void DownloadUserMedia(string folder, string username, string max_id = null)
        {
            var feed = client.timeline.GetUserFeed(client.people.GetUserId(username));

            string file_name = null;
            string file_format = null;
            string url = null;
            string code = null;

            foreach (var item in feed.items)
            {
                int media_type = item.media_type;
                switch (media_type)
                {
                    //Pic
                    case 1:
                        code = item.code.ToString();
                        url = item.image_versions2.candidates[0].url.ToString();
                        file_format = item.image_versions2.candidates[0].url.ToString().Split('.')[6].Split('?')[0];
                        file_name = item.image_versions2.candidates[0].url.ToString().Split('.')[5].Split('/')[1].Split('.')[0];
                        break;
                    //Video
                    case 2:
                        code = item.code.ToString();
                        url = item.video_versions[0].url.ToString();
                        file_format = item.video_versions[0].url.ToString().Split('.')[6].Split('?')[0];
                        file_name = item.video_versions[0].url.ToString().Split('.')[5].Split('/')[1];
                        break;
                    //album
                    case 8:
                        code = item.code.ToString();

                        foreach (var media in item.carousel_media)
                        {
                            //Video
                            if (media.media_type == 2)
                            {
                                url = media.video_versions[0].url.ToString();
                                file_format = media.video_versions[0].url.ToString().Split('.')[6].Split('?')[0];
                                file_name = media.video_versions[0].url.ToString().Split('.')[5].Split('/')[1];
                            }
                            //Pic
                            else if (media.media_type == 1)
                            {
                                url = media.image_versions2.candidates[0].url.ToString();
                                file_format = media.image_versions2.candidates[0].url.ToString().Split('.')[6].Split('?')[0];
                                file_name = media.image_versions2.candidates[0].url.ToString().Split('.')[5].Split('/')[1].Split('.')[0];
                            }
                            new WebClient().DownloadFile(url.ToString(), folder + file_name + "." + file_format);
                        }

                        break;
                }

                new WebClient().DownloadFile(url.ToString(), folder + file_name + "." + file_format);
                Console.WriteLine("Downloaded: " + code);

            }

            if (feed.more_available)
                DownloadUserMedia(folder, username, feed.next_max_id);

            Console.WriteLine("Finished");
        }
        public void DownloadUserStory(string folder, string username)
        {
            var storyFeed = client.story.getUserStoryFeed(client.people.GetUserId(username));

            var items = storyFeed.reel.items;

            foreach (var item in items)
            {
                string file_name = null;
                string file_format = null;
                string url = null;
                string code = item.code;

                //Image
                if (item.media_type == 1)
                {
                    url = item.image_versions2.candidates[0].url.ToString();
                    file_format = item.image_versions2.candidates[0].url.ToString().Split('.')[6].Split('?')[0];
                    file_name = item.image_versions2.candidates[0].url.ToString().Split('.')[5].Split('/')[2];
                }
                //Video
                else if (item.media_type == 2)
                {
                    url = item.video_versions[0].url.ToString();
                    file_format = item.video_versions[0].url.ToString().Split('.')[5].Split('?')[0];
                    file_name = item.image_versions2.candidates[0].url.ToString().Split('.')[5].Split('/')[1];
                }
                new WebClient().DownloadFile(url.ToString(), folder + file_name + "." + file_format);
                Console.WriteLine("Downloaded: " + code);
            }
        }
        public void GetUserStory(string user_pk)
        {
            var story = client.story.getUserStoryFeed(user_pk);

            foreach (var item in story.reel.items)
            {
                //Image
                if (item.media_type == 1)
                {
                    DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    time = time.AddSeconds(item.taken_at).ToLocalTime();
                    Console.WriteLine($"Image:[{time}]\n" + item.image_versions2.candidates[0].url + "\n");
                }
                //Video
                else if (item.media_type == 2)
                {
                    DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    time = time.AddSeconds((int)item.taken_at).ToLocalTime();
                    Console.WriteLine($"Video [{time}]:\n" + item.video_versions[0].url + "\n");
                }
            }
        }
    }
}
