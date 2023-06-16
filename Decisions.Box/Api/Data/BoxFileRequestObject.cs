using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFileRequestObject : BoxEntity
    {
        public const string FieldCreatedAt = "created_at";
        public const string FieldCreatedBy = "created_by";
        public const string FieldDescription = "description";
        public const string FieldEtag = "etag";
        public const string FieldExpiresAt = "expires_at";
        public const string FieldFolder = "folder";
        public const string FieldIsDescriptionRequired = "is_description_required";
        public const string FieldIsEmailRequired = "is_email_required";
        public const string FieldStatus = "status";
        public const string FieldTitle = "title";
        public const string FieldUpdatedAt = "updated_at";
        public const string FieldUpdatedBy = "updated_by";
        public const string FieldUrl = "url";

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldDescription)]
        public virtual string Description { get; private set; }

        [JsonProperty(PropertyName = FieldEtag)]
        public virtual string Etag { get; private set; }

        [JsonProperty(PropertyName = FieldExpiresAt)]
        public virtual DateTimeOffset? ExpiresAt { get; private set; }

        [JsonProperty(PropertyName = FieldFolder)]
        public virtual BoxFolder Folder { get; private set; }

        [JsonProperty(PropertyName = FieldIsDescriptionRequired)]
        public virtual bool IsDescriptionRequired { get; private set; }

        [JsonProperty(PropertyName = FieldIsEmailRequired)]
        public virtual bool IsEmailRequired { get; private set; }

        [JsonProperty(PropertyName = FieldStatus)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxFileRequestStatus Status { get; private set; }

        [JsonProperty(PropertyName = FieldTitle)]
        public virtual string Title { get; private set; }

        [JsonProperty(PropertyName = FieldUpdatedAt)]
        public virtual DateTimeOffset? UpdatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldUpdatedBy)]
        public virtual BoxUser UpdatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldUrl)]
        public virtual string Url { get; private set; }
    }

    public enum BoxFileRequestStatus
    {
        active,
        inactive
    }
}