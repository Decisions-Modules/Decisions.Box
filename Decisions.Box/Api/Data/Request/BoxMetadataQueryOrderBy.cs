using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxMetadataQueryOrderBy
    {
        [JsonProperty(PropertyName = "field_key")]
        public string FieldKey { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public BoxSortDirection Direction { get; set; }
    }
}