using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxGroupMembership : BoxEntity
    {
        public const string FieldRole = "role";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldUser = "user";
        public const string FieldGroup = "group";

        [JsonProperty(PropertyName = FieldRole)]
        public virtual string Role { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; set; }

        [JsonProperty(PropertyName = FieldUser)]
        public virtual BoxUser User { get; set; }

        [JsonProperty(PropertyName = FieldGroup)]
        public virtual BoxGroup Group { get; set; }
    }
}