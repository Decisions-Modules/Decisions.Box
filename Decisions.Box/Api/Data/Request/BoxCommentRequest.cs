using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxCommentRequest
    {
        [JsonProperty(PropertyName = "item")]
        public BoxRequestEntity Item { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "tagged_message")]
        public string TaggedMessage { get; set; }
    }
}