using InstagramPrivateAPI.src.models.media.reel;
using InstagramPrivateAPI.src.models.user;
using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.users
{
    internal class UserReelSettingsResponse : Response
    {
        public string message_prefs { get; set; }
        public BlockedReels blocked_reels { get; set; }
        public Besties besties { get; set; }
        public bool persist_stories_to_private_profile { get; set; }
        public string reel_auto_archive { get; set; }
        public bool allow_story_reshare { get; set; }
        public bool save_to_camera_roll { get; set; }
        public bool save_recent_stories_captures { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
