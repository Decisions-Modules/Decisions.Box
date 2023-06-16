using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRetentionPolicy : BoxEntity
    {
        public const string FieldPolicyName = "policy_name";
        public const string FieldPolicyType = "policy_type";
        public const string FieldRetentionLength = "retention_length";
        public const string FieldDispositionAction = "disposition_action";
        public const string FieldStatus = "status";
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldCanOwnerExtendRetention = "can_owner_extend_retention";
        public const string FieldAreOwnersNotified = "are_owners_notified";
        public const string FieldCustomNotificationRecipients = "custom_notification_recipients";
        public const string FieldRetentionType = "retention_type";
        public const string FieldDescription = "description";

        [JsonProperty(PropertyName = FieldPolicyName)]
        public virtual string PolicyName { get; set; }

        [JsonProperty(PropertyName = FieldPolicyType)]
        public virtual string PolicyType { get; set; }

        [JsonProperty(PropertyName = FieldRetentionLength)]
        // @TODO(mwiller) 2018-01-29: Change this to the correct type (int)
        public virtual string RetentionLength { get; set; }

        [JsonProperty(PropertyName = FieldDispositionAction)]
        public virtual string DispositionAction { get; set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; set; }

        [JsonProperty(PropertyName = FieldCanOwnerExtendRetention)]
        public virtual bool? CanOwnerExtendRetention { get; set; }

        [JsonProperty(PropertyName = FieldAreOwnersNotified)]
        public virtual bool? AreOwnersNotified { get; set; }

        [JsonProperty(PropertyName = FieldCustomNotificationRecipients)]
        public virtual List<BoxUser> CustomNotificationRecipients { get; set; }

        [JsonProperty(PropertyName = FieldRetentionType)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxRetentionType RetentionType { get; set; }

        [JsonProperty(PropertyName = FieldDescription)]
        public virtual string Description { get; set; }
    }

    public enum BoxRetentionType
    {
        modifiable,
        [EnumMember(Value = "non-modifiable")] non_modifiable
    }
}