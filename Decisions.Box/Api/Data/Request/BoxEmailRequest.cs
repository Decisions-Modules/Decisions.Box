using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxEmailRequest
    {
        [JsonProperty(PropertyName = "access")]
        public string Access { get; set; }
    }
}