using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxGroupRequest
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "provenance")]
        public string Provenance { get; set; }

        [JsonProperty(PropertyName = "external_sync_identifier")]
        public string ExternalSyncIdentifier { get; set; }

        [JsonProperty(PropertyName = "invitability_level")]
        public string InvitabilityLevel { get; set; }

        [JsonProperty(PropertyName = "member_viewability_level")]
        public string MemberViewabilityLevel { get; set; }
    }
}