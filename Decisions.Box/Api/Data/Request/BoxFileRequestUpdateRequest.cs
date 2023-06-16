using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxFileRequestUpdateRequest
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }

        [JsonProperty(PropertyName = "is_description_required")]
        public bool? IsDescriptionRequired { get; set; }

        [JsonProperty(PropertyName = "is_email_required")]
        public bool? IsEmailRequired { get; set; }

        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxFileRequestStatus? Status { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}