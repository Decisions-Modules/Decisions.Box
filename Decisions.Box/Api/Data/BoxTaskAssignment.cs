using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxTaskAssignment : BoxEntity
    {
        public const string FieldItem = "item";
        public const string FieldAssignedTo = "assigned_to";
        public const string FieldMessage = "message";
        public const string FieldCompletedAt = "completed_at";
        public const string FieldAssignedAt = "assigned_at";
        public const string FieldRemindedAt = "reminded_at";
        public const string FieldResolutionState = "resolution_state";
        public const string FieldStatus = "status";
        public const string FieldAssignedBy = "assigned_by";

        [JsonProperty(PropertyName = FieldItem)]
        public virtual BoxItem Item { get; private set; }

        [JsonProperty(PropertyName = FieldAssignedTo)]
        public virtual BoxUser AssignedTo { get; private set; }

        [JsonProperty(PropertyName = FieldMessage)]
        public virtual string Message { get; private set; }

        [JsonProperty(PropertyName = FieldCompletedAt)]
        public virtual DateTimeOffset? CompletedAt { get; private set; }

        [JsonProperty(PropertyName = FieldAssignedAt)]
        public virtual DateTimeOffset? AssignedAt { get; private set; }

        [JsonProperty(PropertyName = FieldRemindedAt)]
        public virtual DateTimeOffset? RemindedAt { get; private set; }

        public virtual ResolutionStateType? ResolutionState
        {
            get
            {
                return (ResolutionStateType)Enum.Parse(typeof(ResolutionStateType), LocalizedStatus, ignoreCase: true);
            }
        }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; private set; }

        [JsonProperty(PropertyName = FieldResolutionState)]
        public virtual string LocalizedStatus { get; private set; }

        [JsonProperty(PropertyName = FieldAssignedBy)]
        public virtual BoxUser AssignedBy { get; private set; }
    }
}