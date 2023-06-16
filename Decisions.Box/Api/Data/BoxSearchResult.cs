using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSearchResult
    {
        [JsonProperty(PropertyName = "type")]
        public virtual string Type { get; private set; }

        [JsonProperty(PropertyName = "accessible_via_shared_link")]
        public virtual Uri AccessibleViaSharedLink { get; private set; }

        [JsonProperty(PropertyName = "item")]
        public virtual BoxItem Item { get; private set; }
    }
}