using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxMetadataFilterRequest
    {
        [JsonProperty(PropertyName = "templateKey")]
        public string TemplateKey { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        [JsonProperty(PropertyName = "filters")]
        public object Filters { get; set; }
    }
}