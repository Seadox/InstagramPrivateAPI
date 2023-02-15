using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveQuastionStatusResponse : Response
    {
        public bool is_question_submission_allowed { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
