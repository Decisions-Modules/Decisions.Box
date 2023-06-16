using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxLegalHoldPolicyAssignmentRequest
    {
        [JsonProperty(PropertyName = "policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty(PropertyName = "assign_to")]
        public BoxRequestEntity AssignTo { get; set; }
    }
}