using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxLegalHoldPolicyAssignment : BoxEntity
    {
        public const string FieldLegalHoldPolicy = "legal_hold_policy";
        public const string FieldAssignedTo = "assigned_to";
        public const string FieldAssignedBy = "assigned_by";
        public const string FieldAssignedAt = "assigned_at";
        public const string FieldDeletedAt = "deleted_at";

        [JsonProperty(PropertyName = FieldLegalHoldPolicy)]
        public virtual BoxLegalHoldPolicy LegalHoldPolicy { get; private set; }

        [JsonProperty(PropertyName = FieldAssignedTo)]
        public virtual BoxEntity AssignedTo { get; private set; }

        [JsonProperty(PropertyName = FieldAssignedBy)]
        public virtual BoxUser AssignedBy { get; private set; }

        [JsonProperty(PropertyName = FieldAssignedAt)]
        public virtual DateTimeOffset AssignedAt { get; private set; }

        [JsonProperty(PropertyName = FieldDeletedAt)]
        public virtual DateTimeOffset? DeletedAt { get; private set; }
    }
}