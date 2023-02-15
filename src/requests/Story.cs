using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.feed;
using InstagramPrivateAPI.src.responses.media;
using InstagramPrivateAPI.src.responses.users;

namespace InstagramPrivateAPI.src.requests
{
    internal class Story
    {
        public FeedReelsTrayResponse getReelsTrayFeed() => Request.Send<FeedReelsTrayResponse>("feed/reels_tray/");

        public FeedUserReelsMediaResponse getUserReelMediaFeed(string userId) => Request.Send<FeedUserReelsMediaResponse>($"feed/user/{userId}/reel_media/");

        public FeedUserStoryResponse getUserStoryFeed(string userId) => Request.Send<FeedUserStoryResponse>($"feed/user/{userId}/story/");

        //Works for your own story items
        public MediaListReelMediaViewerResponse getStoryItemViewers(string storyPk, string maxId = null) => Request.Send<MediaListReelMediaViewerResponse>($"media/{storyPk}/list_reel_media_viewer/?max_id=" + (maxId != null ? maxId : ""));

        public UserReelSettingsResponse getReelSettings() => Request.Send<UserReelSettingsResponse>("users/reel_settings/");

        public Response getArchivedStoriesFeed() => Request.Send<Response>("archive/reel/day_shells/?include_cover=0");

        public Response markMediaSeen(string itemSourceId, string itemId, string itemTakenAt) => Internal.markStoryMediaSeen(itemSourceId, itemId, itemTakenAt);
    }
}
