using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxLegalHoldPolicy : BoxEntity
    {
        public const string FieldPolicyName = "policy_name";
        public const string FieldDescription = "description";
        public const string FieldStatus = "status";
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldDeletedAt = "deleted_at";
        public const string FieldFilterStartedAt = "filter_started_at";
        public const string FieldFilterEndedAt = "filter_ended_at";
        public const string FieldIsOngoing = "is_ongoing";
        public const string FieldAssignmentCounts = "assignment_counts";

        [JsonProperty(PropertyName = FieldPolicyName)]
        public virtual string PolicyName { get; private set; }

        [JsonProperty(PropertyName = FieldDescription)]
        public virtual string Description { get; private set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }

        [JsonProperty(PropertyName = FieldDeletedAt)]
        public virtual DateTimeOffset? DeletedAt { get; private set; }

        [JsonProperty(PropertyName = FieldFilterStartedAt)]
        public virtual DateTimeOffset? FilterStartedAt { get; private set; }

        [JsonProperty(PropertyName = FieldFilterEndedAt)]
        public virtual DateTimeOffset? FilterEndedAt { get; private set; }

        [JsonProperty(PropertyName = FieldAssignmentCounts)]
        public virtual BoxAssignmentCounts AssignmentCounts { get; private set; }

        [JsonProperty(PropertyName = FieldIsOngoing)]
        public virtual bool IsOngoing { get; private set; }
    }
}