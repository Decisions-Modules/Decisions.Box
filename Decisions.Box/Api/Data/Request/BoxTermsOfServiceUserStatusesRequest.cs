using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxTermsOfServiceUserStatusesRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "tos")]
        public BoxTermsOfService TermsOfService { get; set; }

        [JsonProperty(PropertyName = "user")]
        public BoxUser User { get; set; }

        [JsonProperty(PropertyName = "is_accepted")]
        public bool IsAccepted { get; set; }
    }
}