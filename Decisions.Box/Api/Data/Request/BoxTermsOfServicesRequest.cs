using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxTermsOfServicesRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "tos_type")]
        public string TosType { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}