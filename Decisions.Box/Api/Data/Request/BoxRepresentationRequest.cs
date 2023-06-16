using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxRepresentationRequest
    {
        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "x-rep-hints")]
        public string XRepHints { get; set; }

        [JsonProperty(PropertyName = "set_content_disposition_type")]
        public string SetContentDispositionType { get; set; }

        [JsonProperty(PropertyName = "set_content_diposition_filename")]
        public string SetContentDispositionFilename { get; set; }

        [JsonProperty(PropertyName = "handle_retry")]
        public bool HandleRetry { get; set; }
    }
}