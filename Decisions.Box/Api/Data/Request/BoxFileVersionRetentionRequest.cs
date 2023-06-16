using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxFileVersionRetentionRequest
    {
        public BoxFileVersionRetentionRequest()
        {
            Limit = 100;
        }

        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "file_version_id")]
        public string FileVersionId { get; set; }

        [JsonProperty(PropertyName = "policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty(PropertyName = "disposition_action")]
        public string DispositionAction { get; set; }

        [JsonProperty(PropertyName = "disposition_before")]
        public DateTimeOffset? DispositionBefore { get; set; }

        [JsonProperty(PropertyName = "disposition_after")]
        public DateTimeOffset? DispositionAfter { get; set; }

        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "marker")]
        public string Marker { get; set; }
    }
}