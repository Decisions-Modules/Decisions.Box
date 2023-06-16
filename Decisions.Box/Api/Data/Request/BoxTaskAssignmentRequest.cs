using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxTaskAssignmentRequest
    {
        [JsonProperty(PropertyName = "task")]
        public BoxTaskRequest Task { get; set; }

        [JsonProperty(PropertyName = "assign_to")]
        public BoxAssignmentRequest AssignTo { get; set; }
    }
}