using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxLegalHoldPolicyRequest
    {
        public const string FieldPolicyName = "policy_name";
        public const string FieldDescription = "description";
        public const string FieldFilterStartedAt = "filter_started_at";
        public const string FieldFilterEndedAt = "filter_ended_at";
        public const string FieldIsOngoing = "is_ongoing";
        public const string FieldReleaseNotes = "release_notes";

        [JsonProperty(PropertyName = FieldPolicyName)]
        public string PolicyName { get; set; }

        [JsonProperty(PropertyName = FieldDescription)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = FieldFilterStartedAt)]
        public DateTimeOffset? FilterStartedAt { get; set; }

        [JsonProperty(PropertyName = FieldFilterEndedAt)]
        public DateTimeOffset? FilterEndedAt { get; set; }

        [JsonProperty(PropertyName = FieldIsOngoing)]
        public bool? isOngoing { get; set; }

        [JsonProperty(PropertyName = FieldReleaseNotes)]
        public string ReleaseNotes { get; set; }
    }
}