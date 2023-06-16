using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxSharedLinkRequest
    {
        [JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Include)]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxSharedLinkAccessType? Access { get; set; }

        private bool _isUnsharedAtSet = false;
        private DateTimeOffset? _unsharedAt;

        [JsonProperty(PropertyName = "unshared_at", NullValueHandling = NullValueHandling.Include)]
        public DateTimeOffset? UnsharedAt
        {
            get { return _unsharedAt; }

            set
            {
                _unsharedAt = value;
                _isUnsharedAtSet = true;
            }
        }

        public bool ShouldSerializeUnsharedAt()
        {
            return _isUnsharedAtSet;
        }

        [JsonProperty(PropertyName = "permissions")]
        public BoxPermissionsRequest Permissions { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "vanity_name")]
        public string VanityName { get; set; }
    }
}