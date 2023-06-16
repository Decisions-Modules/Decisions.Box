using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxMetadataQueryItem
    {
        [JsonProperty(PropertyName = "item")]
        public virtual BoxItem Item { get; private set; }

        [JsonProperty(PropertyName = "metadata")]
        public virtual Dictionary<string, object> Metadata { get; private set; }
    }
}