using Newtonsoft.Json;

namespace InstagramPrivateAPI.src.responses.live
{
    internal class LiveCreateResponse : Response
    {
        public long broadcast_id { get; set; }
        public string upload_url { get; set; }
        public string fbvp_tcp_upload_url { get; set; }
        public string fbvp_quic_upload_url { get; set; }
        public int max_time_in_seconds { get; set; }
        public int speed_test_ui_timeout { get; set; }
        public int stream_network_speed_test_payload_chunk_size_in_bytes { get; set; }
        public int stream_network_speed_test_payload_size_in_bytes { get; set; }
        public int stream_network_speed_test_payload_timeout_in_seconds { get; set; }
        public int speed_test_minimum_bandwidth_threshold { get; set; }
        public int speed_test_retry_max_count { get; set; }
        public int speed_test_retry_time_delay { get; set; }
        public int disable_speed_test { get; set; }
        public int stream_video_allow_b_frames { get; set; }
        public int stream_video_width { get; set; }
        public int stream_video_bit_rate { get; set; }
        public int stream_video_fps { get; set; }
        public int stream_audio_bit_rate { get; set; }
        public int stream_audio_sample_rate { get; set; }
        public int stream_audio_channels { get; set; }
        public int heartbeat_interval { get; set; }
        public int broadcaster_update_frequency { get; set; }
        public string stream_video_adaptive_bitrate_config { get; set; }
        public int stream_network_connection_retry_count { get; set; }
        public int stream_network_connection_retry_delay_in_seconds { get; set; }
        public int connect_with_1rtt { get; set; }
        public int allow_resolution_change { get; set; }
        public int avc_rtmp_payload { get; set; }
        public int pass_thru_enabled { get; set; }
        public int live_trace_enabled { get; set; }
        public int live_trace_sample_interval_in_seconds { get; set; }
        public int live_trace_sampling_source { get; set; }
        public int server_abr_enabled { get; set; }
        public int is_premium { get; set; }
        public int max_allowed_participants { get; set; }
        public bool should_use_rsys_rtc_infra { get; set; }
        public string badge_setting { get; set; }
        public StreamInitialBitratePrediction stream_initial_bitrate_prediction { get; set; }

        public class StreamInitialBitratePrediction
        {
            public double noresult { get; set; }
        }

        public String getBroadcastUrl() => upload_url.Split(broadcast_id.ToString(), 2)[0];

        public String getBroadcastKey() => broadcast_id + upload_url.Split(broadcast_id.ToString(), 2)[1];
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
