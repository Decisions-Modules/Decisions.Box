using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSharedLink
    {
        public const string FieldUrl = "url";
        public const string FieldDownloadUrl = "download_url";
        public const string FieldVanityUrl = "vanity_url";
        public const string FieldIsPasswordEnabled = "is_password_enabled";
        public const string FieldUnsharedAt = "unshared_at";
        public const string FieldDownloadCount = "download_count";
        public const string FieldPreviewCount = "preview_count";
        public const string FieldAccess = "access";
        public const string FieldPermissions = "permissions";
        public const string FieldVanityName = "vanity_name";
        public const string FieldEffectiveAccess = "effective_access";

        [JsonProperty(PropertyName = FieldUrl)]
        public virtual string Url { get; private set; }

        [JsonProperty(PropertyName = FieldDownloadUrl)]
        public virtual string DownloadUrl { get; private set; }

        [JsonProperty(PropertyName = FieldVanityUrl)]
        public virtual string VanityUrl { get; private set; }

        [JsonProperty(PropertyName = FieldIsPasswordEnabled)]
        public virtual bool IsPasswordEnabled { get; private set; }

        [JsonProperty(PropertyName = FieldUnsharedAt)]
        public virtual DateTimeOffset? UnsharedAt { get; private set; }

        [JsonProperty(PropertyName = FieldDownloadCount)]
        public virtual int DownloadCount { get; private set; }

        [JsonProperty(PropertyName = FieldPreviewCount)]
        public virtual int PreviewCount { get; private set; }

        [JsonProperty(PropertyName = FieldAccess)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSharedLinkAccessType? Access { get; private set; }

        [JsonProperty(PropertyName = FieldPermissions)]
        public virtual BoxPermission Permissions { get; private set; }

        [JsonProperty(PropertyName = FieldVanityName)]
        public virtual string VanityName { get; private set; }

        [JsonProperty(PropertyName = FieldEffectiveAccess)]
        public virtual string EffectiveAccess { get; private set; }
    }
}