using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxItemRequest : BoxRequestEntity
    {
        [JsonProperty(PropertyName = "parent")]
        public BoxRequestEntity Parent { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "shared_link")]
        public BoxSharedLinkRequest SharedLink { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }
    }
}