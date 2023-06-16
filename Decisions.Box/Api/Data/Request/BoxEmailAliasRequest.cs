using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxEmailAliasRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}