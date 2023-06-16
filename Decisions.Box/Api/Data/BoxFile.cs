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
    public class BoxFile : BoxItem
    {
        public const string FieldSha1 = "sha1";
        public const string FieldPurgedAt = "purged_at";
        public const string FieldContentCreatedAt = "content_created_at";
        public const string FieldContentModifiedAt = "content_modified_at";
        public const string FieldVersionNumber = "version_number";
        public const string FieldExtension = "extension";
        public const string FieldCommentCount = "comment_count";
        public const string FieldLock = "lock";
        public const string FieldExpiringEmbedLink = "expiring_embed_link";
        public const string FieldWatermarkInfo = "watermark_info";
        public const string FieldFileVersion = "file_version";
        public const string FieldRepresentations = "representations";
        public const string FieldExpiresAt = "expires_at";
        public const string FieldAllowedInviteeRoles = "allowed_invitee_roles";
        public const string FieldHasCollaborations = "has_collaborations";
        public const string FieldIsExternallyOwned = "is_externally_owned";
        public const string FieldUploaderDisplayName = "uploader_display_name";
        public const string FieldClassification = "classification";
        public const string FieldDispositionAt = "disposition_at";

        [JsonProperty(PropertyName = FieldSha1)]
        public virtual string Sha1 { get; private set; }

        [JsonProperty(PropertyName = FieldFileVersion)]
        public virtual BoxFileVersion FileVersion { get; private set; }

        [JsonProperty(PropertyName = FieldPurgedAt)]
        public virtual DateTimeOffset? PurgedAt { get; private set; }

        [JsonProperty(PropertyName = FieldContentCreatedAt)]
        public virtual DateTimeOffset? ContentCreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldContentModifiedAt)]
        public virtual DateTimeOffset? ContentModifiedAt { get; private set; }

        [JsonProperty(PropertyName = FieldVersionNumber)]
        public virtual string VersionNumber { get; private set; }

        [JsonProperty(PropertyName = FieldExtension)]
        public virtual string Extension { get; private set; }

        [JsonProperty(PropertyName = FieldCommentCount)]
        public virtual int CommentCount { get; private set; }

        [JsonProperty(PropertyName = FieldPermissions)]
        public virtual BoxFilePermission Permissions { get; protected set; }

        [JsonProperty(PropertyName = FieldLock)]
        public virtual BoxFileLock Lock { get; protected set; }

        [JsonProperty(PropertyName = FieldExpiringEmbedLink)]
        public virtual BoxExpiringEmbedLink ExpiringEmbedLink { get; protected set; }

        [JsonProperty(PropertyName = FieldWatermarkInfo)]
        public virtual BoxWatermarkInfo WatermarkInfo { get; protected set; }

        [JsonProperty(PropertyName = "metadata")]
        public virtual dynamic Metadata { get; protected set; }

        [JsonProperty(PropertyName = FieldRepresentations)]
        public virtual BoxRepresentationCollection<BoxRepresentation> Representations { get; protected set; }

        [JsonProperty(PropertyName = FieldExpiresAt)]
        public virtual DateTimeOffset? ExpiresAt { get; protected set; }

        [JsonProperty(PropertyName = FieldAllowedInviteeRoles)]
        public virtual List<string> AllowedInviteeRoles { get; protected set; }

        [JsonProperty(PropertyName = FieldHasCollaborations)]
        public virtual bool? HasCollaborations { get; protected set; }

        [JsonProperty(PropertyName = FieldIsExternallyOwned)]
        public virtual bool? IsExternallyOwned { get; protected set; }

        [JsonProperty(PropertyName = FieldUploaderDisplayName)]
        public virtual string UploaderDisplayName { get; private set; }

        [JsonProperty(PropertyName = FieldClassification)]
        public virtual BoxClassification Classification { get; private set; }

        [JsonProperty(PropertyName = FieldDispositionAt)]
        public virtual DateTimeOffset? DispositionAt { get; private set; }
    }
}