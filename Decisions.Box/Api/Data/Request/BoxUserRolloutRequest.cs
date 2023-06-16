using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxUserRollOutRequest : BoxUserRequest
    {
        [JsonProperty(PropertyName = "enterprise", NullValueHandling = NullValueHandling.Include)]
        public new string Enterprise { get; set; }
    }
}