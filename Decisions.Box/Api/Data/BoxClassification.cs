using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxClassification
    {
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = "definition")]
        public virtual string Definition { get; set; }

        [JsonProperty(PropertyName = "color")]
        public virtual string Color { get; private set; }
    }
}