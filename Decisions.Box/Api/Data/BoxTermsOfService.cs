using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxTermsOfService : BoxEntity
    {
        public const string FieldStatus = "status";
        public const string FieldEnterprise = "enterprise";
        public const string FieldTosType = "tos_type";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldText = "text";

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; set; }

        [JsonProperty(PropertyName = FieldEnterprise)]
        public virtual BoxEnterprise Enterprise { get; set; }

        [JsonProperty(PropertyName = FieldTosType)]
        public virtual string TosType { get; set; }

        [JsonProperty(PropertyName = FieldText)]
        public virtual string Text { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }
    }
}