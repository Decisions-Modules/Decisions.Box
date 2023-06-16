using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;


namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxUserInviteRequest : BoxRequestEntity
    {
        [JsonProperty(PropertyName = "enterprise")]
        public BoxRequestEntity Enterprise { get; set; }

        [JsonProperty(PropertyName = "actionable_by")]
        public BoxActionableByRequest ActionableBy { get; set; }
    }
}