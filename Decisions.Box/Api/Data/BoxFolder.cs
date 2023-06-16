using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Decisions.Box.Api.Data.Permissions;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFolder : BoxItem
    {
        public const string FieldFolderUploadEmail = "folder_upload_email";
        public const string FieldItemCollection = "item_collection";
        public const string FieldSyncState = "sync_state";
        public const string FieldHasCollaborations = "has_collaborations";
        public const string FieldAllowedInviteeRoles = "allowed_invitee_roles";
        public const string FieldWatermarkInfo = "watermark_info";
        public const string FieldPurgedAt = "purged_at";
        public const string FieldContentCreatedAt = "content_created_at";
        public const string FieldContentModifiedAt = "content_modified_at";
        public const string FieldCanNonOwnersInvite = "can_non_owners_invite";
        public const string FieldIsExternallyOwned = "is_externally_owned";
        public const string FieldAllowedSharedLinkAccessLevels = "allowed_shared_link_access_levels";
        public const string FieldExpiresAt = "expires_at";
        public const string FieldIsCollaborationRestrictedToEnterprise = "is_collaboration_restricted_to_enterprise";
        public const string FieldClassification = "classification";

        [JsonProperty(PropertyName = FieldFolderUploadEmail)]
        public virtual BoxEmail FolderUploadEmail { get; private set; }

        [JsonProperty(PropertyName = FieldItemCollection)]
        public virtual BoxCollection<BoxItem> ItemCollection { get; private set; }

        [JsonProperty(PropertyName = FieldSyncState)]
        public virtual string SyncState { get; private set; }

        [JsonProperty(PropertyName = FieldHasCollaborations)]
        public virtual bool? HasCollaborations { get; private set; }

        [JsonProperty(PropertyName = FieldPermissions)]
        public virtual BoxFolderPermission Permissions { get; protected set; }

        [JsonProperty(PropertyName = FieldAllowedInviteeRoles)]
        public virtual IList<string> AllowedInviteeRoles { get; protected set; }

        [JsonProperty(PropertyName = FieldWatermarkInfo)]
        public virtual BoxWatermarkInfo WatermarkInfo { get; protected set; }

        [JsonProperty(PropertyName = "metadata")]
        public virtual dynamic Metadata { get; protected set; }

        [JsonProperty(PropertyName = FieldPurgedAt)]
        public virtual DateTimeOffset? PurgedAt { get; set; }

        [JsonProperty(PropertyName = FieldContentCreatedAt)]
        public virtual DateTimeOffset? ContentCreatedAt { get; set; }

        [JsonProperty(PropertyName = FieldContentModifiedAt)]
        public virtual DateTimeOffset? ContentModifiedAt { get; set; }

        [JsonProperty(PropertyName = FieldCanNonOwnersInvite)]
        public virtual bool? CanNonOwnersInvite { get; set; }

        [JsonProperty(PropertyName = FieldAllowedSharedLinkAccessLevels)]
        public virtual IList<string> AllowedSharedLinkAccessLevels { get; set; }

        [JsonProperty(PropertyName = FieldIsExternallyOwned)]
        public virtual bool? IsExternallyOwned { get; set; }

        [JsonProperty(PropertyName = FieldExpiresAt)]
        public virtual DateTimeOffset? ExpiresAt { get; protected set; }

        [JsonProperty(PropertyName = FieldIsCollaborationRestrictedToEnterprise)]
        public virtual bool? IsCollaborationRestrictedToEnterprise { get; protected set; }

        [JsonProperty(PropertyName = FieldClassification)]
        public virtual BoxClassification Classification { get; private set; }
    }
}