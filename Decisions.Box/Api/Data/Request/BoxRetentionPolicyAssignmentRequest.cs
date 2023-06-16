using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxRetentionPolicyAssignmentRequest
    {
        [JsonProperty(PropertyName = "policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty(PropertyName = "assign_to")]
        public BoxRequestEntity AssignTo { get; set; }

        [JsonProperty(PropertyName = "filter_fields")]
        public List<object> FilterFields { get; set; }

        [JsonProperty(PropertyName = "start_date_field")]
        public string StartDateField { get; set; }
    }
}