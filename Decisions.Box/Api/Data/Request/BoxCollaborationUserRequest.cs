using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxCollaborationUserRequest : BoxRequestEntity
    {
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
    }
}