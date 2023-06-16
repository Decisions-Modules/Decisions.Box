using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxGroupMembershipRequest
    {
        [JsonProperty(PropertyName = "user")]
        public BoxRequestEntity User { get; set; }

        [JsonProperty(PropertyName = "group")]
        public BoxGroupRequest Group { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
    }
}