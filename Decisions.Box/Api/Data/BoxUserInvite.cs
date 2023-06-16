using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxUserInvite : BoxEntity
    {
        public const string FieldEnterprise = "enterprise";
        public const string FieldActionableBy = "actionable_by";
        public const string FieldInvitedTo = "invited_to";
        public const string FieldInvitedBy = "invited_by";
        public const string FieldStatus = "status";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";

        [JsonProperty(PropertyName = FieldActionableBy)]
        public virtual BoxUser ActionableBy { get; private set; }

        [JsonProperty(PropertyName = FieldInvitedTo)]
        public virtual BoxEnterprise InvitedTo { get; private set; }

        [JsonProperty(PropertyName = FieldInvitedBy)]
        public virtual BoxUser InvitedBy { get; private set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }
    }
}