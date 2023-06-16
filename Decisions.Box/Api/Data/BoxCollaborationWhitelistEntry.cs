using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxCollaborationWhitelistEntry : BoxEntity
    {
        public const string FieldDomain = "domain";
        public const string FieldDirection = "direction";
        public const string FieldEnterprise = "enterprise";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";

        [JsonProperty(PropertyName = FieldDomain)]
        public virtual string Domain { get; set; }

        [JsonProperty(PropertyName = FieldDirection)]
        public virtual string Direction { get; set; }

        [JsonProperty(PropertyName = FieldEnterprise)]
        public virtual BoxEnterprise Enterprise { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; set; }
    }
}