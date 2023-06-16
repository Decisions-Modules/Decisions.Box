using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSortOrder
    {
        [JsonProperty(PropertyName = "by")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSortBy By { get; private set; }

        [JsonProperty(PropertyName = "sort")] public virtual string Sort { get; private set; }

        [JsonProperty(PropertyName = "direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSortDirection Direction { get; private set; }
    }
}