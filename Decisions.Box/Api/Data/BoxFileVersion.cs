using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFileVersion : BoxEntity
    {
        public const string FieldSha1 = "sha1";
        public const string FieldName = "name";
        public const string FieldSize = "size";
        public const string FieldUploaderDisplayName = "uploader_display_name";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldModifiedBy = "modified_by";
        public const string FieldTrashedAt = "trashed_at";
        public const string FieldTrashedBy = "trashed_by";
        public const string FieldPurgedAt = "purged_at";
        public const string FieldRestoredAt = "restored_at";
        public const string FieldRestoredBy = "restored_by";
        public const string FieldVersionNumber = "version_number";

        [JsonProperty(PropertyName = FieldSha1)]
        public virtual string Sha1 { get; private set; }

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = FieldSize)]
        public virtual long? Size { get; private set; }

        [JsonProperty(PropertyName = FieldUploaderDisplayName)]
        public virtual string UploaderDisplayName { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedBy)]
        public virtual BoxUser ModifiedBy { get; private set; }

        [JsonProperty(PropertyName = FieldTrashedAt)]
        public virtual DateTimeOffset? TrashedAt { get; private set; }

        [JsonProperty(PropertyName = FieldTrashedBy)]
        public virtual BoxUser TrashedBy { get; private set; }

        [JsonProperty(PropertyName = FieldPurgedAt)]
        public virtual DateTimeOffset? PurgedAt { get; private set; }

        [JsonProperty(PropertyName = FieldRestoredAt)]
        public virtual DateTimeOffset? RestoredAt { get; private set; }

        [JsonProperty(PropertyName = FieldRestoredBy)]
        public virtual BoxUser RestoredBy { get; private set; }

        [JsonProperty(PropertyName = FieldVersionNumber)]
        public virtual string VersionNumber { get; private set; }
    }
}