using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxPreflightCheckRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "size")]
        public long Size { get; set; }
    }
}