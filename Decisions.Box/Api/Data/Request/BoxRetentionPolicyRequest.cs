using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxRetentionPolicyRequest
    {
        [JsonProperty(PropertyName = "policy_name")]
        public string PolicyName { get; set; }

        [JsonProperty(PropertyName = "policy_type")]
        public string PolicyType { get; set; }

        [JsonProperty(PropertyName = "retention_length")]
        public int? RetentionLength { get; set; }

        [JsonProperty(PropertyName = "disposition_action")]
        public string DispositionAction { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "can_owner_extend_retention")]
        public bool CanOwnerExtendRetention { get; set; }

        [JsonProperty(PropertyName = "are_owners_notified")]
        public bool AreOwnersNotified { get; set; }

        [JsonProperty(PropertyName = "custom_notification_recipients")]
        public List<BoxRequestEntity> CustomNotificationRecipients { get; set; }

        [JsonProperty(PropertyName = "retention_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxRetentionType RetentionType { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}