using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxItem : BoxEntity
    {
        public const string FieldSequence = "sequence_id";
        public const string FieldEtag = "etag";
        public const string FieldName = "name";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldTrashedAt = "trashed_at";
        public const string FieldDescription = "description";
        public const string FieldSize = "size";
        public const string FieldPathCollection = "path_collection";
        public const string FieldCreatedBy = "created_by";
        public const string FieldModifiedBy = "modified_by";
        public const string FieldOwnedBy = "owned_by";
        public const string FieldSharedLink = "shared_link";
        public const string FieldParent = "parent";
        public const string FieldItemStatus = "item_status";
        public const string FieldPermissions = "permissions";
        public const string FieldTags = "tags";

        [JsonProperty(PropertyName = FieldSequence)]
        public virtual string SequenceId { get; private set; }

        [JsonProperty(PropertyName = FieldEtag)]
        public virtual string ETag { get; private set; }

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = FieldDescription)]
        public virtual string Description { get; private set; }

        [JsonProperty(PropertyName = FieldSize)]
        public virtual long? Size { get; private set; }

        [JsonProperty(PropertyName = FieldPathCollection)]
        public virtual BoxCollection<BoxFolder> PathCollection { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }

        [JsonProperty(PropertyName = FieldTrashedAt)]
        public virtual DateTimeOffset? TrashedAt { get; set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedBy)]
        public virtual BoxUser ModifiedBy { get; private set; }

        [JsonProperty(PropertyName = FieldOwnedBy)]
        public virtual BoxUser OwnedBy { get; private set; }

        [JsonProperty(PropertyName = FieldParent)]
        public virtual BoxFolder Parent { get; private set; }

        [JsonProperty(PropertyName = FieldItemStatus)]
        public virtual string ItemStatus { get; private set; }

        [JsonProperty(PropertyName = FieldSharedLink)]
        public virtual BoxSharedLink SharedLink { get; private set; }

        [JsonProperty(PropertyName = FieldTags)]
        public virtual string[] Tags { get; private set; }
    }
}