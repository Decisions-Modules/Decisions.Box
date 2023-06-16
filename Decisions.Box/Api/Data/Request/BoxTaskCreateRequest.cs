using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxTaskCreateRequest
    {
        [JsonProperty(PropertyName = "item")]
        public BoxRequestEntity Item { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action
        {
            get { return "review"; }
        }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "due_at")]
        public DateTimeOffset? DueAt { get; set; }

        [JsonProperty(PropertyName = "completion_rule")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxCompletionRule? CompletionRule { get; set; }
    }
}