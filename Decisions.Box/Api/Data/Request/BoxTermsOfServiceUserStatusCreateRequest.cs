using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxTermsOfServiceUserStatusCreateRequest
    {
        [JsonProperty(PropertyName = "tos")]
        public BoxRequestEntity TermsOfService { get; set; }

        [JsonProperty(PropertyName = "user")]
        public BoxRequestEntity User { get; set; }

        [JsonProperty(PropertyName = "is_accepted")]
        public bool IsAccepted { get; set; }
    }
}