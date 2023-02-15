using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses
{
    internal class Response
    {
        public string status { get; set; }
        private int statusCode { get; set; }
        private string statusCmessageode { get; set; }
        private bool spam { get; set; }
        //private bool lock { get; set; }
        private string feedback_title { get; set; }
        private string feedback_message { get; set; }
        private string error_type { get; set; }
        private string checkpoint_url { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
