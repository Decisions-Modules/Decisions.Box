using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxFileRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "content_created_at")]
        public DateTimeOffset? ContentCreatedAt { get; set; }

        [JsonProperty(PropertyName = "content_modified_at")]
        public DateTimeOffset? ContentModifiedAt { get; set; }

        [JsonProperty(PropertyName = "disposition_at")]
        public DateTimeOffset? DispositionAt { get; set; }
    }
}