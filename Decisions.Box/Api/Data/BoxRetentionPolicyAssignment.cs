using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRetentionPolicyAssignment : BoxEntity
    {
        public const string FieldRetentionPolicy = "retention_policy";
        public const string FieldAssignedTo = "assigned_to";
        public const string FieldAssignedBy = "assigned_by";
        public const string FieldAssignedAt = "assigned_at";
        public const string FieldFilterFields = "filter_fields";
        public const string FieldStartDateField = "start_date_field";

        [JsonProperty(PropertyName = FieldRetentionPolicy)]
        public virtual BoxRetentionPolicy RetentionPolicy { get; set; }

        [JsonProperty(PropertyName = FieldAssignedTo)]
        public virtual BoxEntity AssignedTo { get; set; }

        [JsonProperty(PropertyName = FieldAssignedBy)]
        public virtual BoxUser AssignedBy { get; set; }

        [JsonProperty(PropertyName = FieldAssignedAt)]
        public virtual DateTimeOffset? AssignedAt { get; set; }

        [JsonProperty(PropertyName = FieldFilterFields)]
        public virtual List<BoxMetadataFieldFilter> FilterFields { get; set; }

        [JsonProperty(PropertyName = FieldStartDateField)]
        public virtual string StartDateField { get; set; }
    }
}