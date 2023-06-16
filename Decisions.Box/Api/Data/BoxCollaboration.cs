using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxCollaboration : BoxEntity
    {
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldExpiresAt = "expires_at";
        public const string FieldStatus = "status";
        public const string FieldAccessibleBy = "accessible_by";
        public const string FieldRole = "role";
        public const string FieldAcknowledgedAt = "acknowledged_at";
        public const string FieldItem = "item";
        public const string FieldCanViewPath = "can_view_path";
        public const string FieldInviteEmail = "invite_email";

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; set; }

        [JsonProperty(PropertyName = FieldExpiresAt)]
        public virtual DateTimeOffset? ExpiresAt { get; set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; set; }

        [JsonProperty(PropertyName = FieldAccessibleBy)]
        public virtual BoxEntity AccessibleBy { get; set; }

        [JsonProperty(PropertyName = FieldRole)]
        public virtual string Role { get; set; }

        [JsonProperty(PropertyName = FieldAcknowledgedAt)]
        public virtual DateTimeOffset? AcknowledgedAt { get; set; }

        [JsonProperty(PropertyName = FieldItem)]
        public virtual BoxItem Item { get; set; }

        [JsonProperty(PropertyName = FieldCanViewPath)]
        public virtual bool? CanViewPath { get; set; }

        [JsonProperty(PropertyName = FieldInviteEmail)]
        public virtual string InviteEmail { get; set; }
    }
}