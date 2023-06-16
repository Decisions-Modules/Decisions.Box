using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxWebhookRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "target")]
        public BoxRequestEntity Target { get; set; }

        [JsonProperty(PropertyName = "triggers")]
        public IList<string> Triggers { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}