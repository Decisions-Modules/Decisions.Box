using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxApplication : BoxEntity
    {
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = "api_key")]
        public virtual string ApiKey { get; private set; }
    }
}