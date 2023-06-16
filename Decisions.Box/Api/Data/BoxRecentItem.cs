using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRecentItem : BoxEntity
    {
        [JsonProperty(PropertyName = "interaction_type")]
        public virtual string InteractionType { get; private set; }

        [JsonProperty(PropertyName = "interacted_at")]
        public virtual DateTimeOffset InteractedAt { get; private set; }

        [JsonProperty(PropertyName = "interaction_shared_link")]
        public virtual string InteractionSharedLink { get; protected set; }

        [JsonProperty(PropertyName = "item")]
        public virtual BoxItem Item { get; protected set; }
    }
}