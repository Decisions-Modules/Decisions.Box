using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxUser : BoxEntity
    {
        public const string FieldName = "name";
        public const string FieldLogin = "login";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldRole = "role";
        public const string FieldLanguage = "language";
        public const string FieldSpaceAmount = "space_amount";
        public const string FieldSpaceUsed = "space_used";
        public const string FieldMaxUploadSize = "max_upload_size";
        public const string FieldTrackingCodes = "tracking_codes";
        public const string FieldCanSeeManagedUsers = "can_see_managed_users";
        public const string FieldIsSyncEnabled = "is_sync_enabled";
        public const string FieldStatus = "status";
        public const string FieldJobTitle = "job_title";
        public const string FieldPhone = "phone";
        public const string FieldAddress = "address";
        public const string FieldAvatarUrl = "avatar_url";
        public const string FieldIsExemptFromDeviceLimits = "is_exempt_from_device_limits";
        public const string FieldIsExemptFromLoginVerification = "is_exempt_from_login_verification";
        public const string FieldEnterprise = "enterprise";
        public const string FieldIsPlatformAccessOnly = "is_platform_access_only";
        public const string FieldTimezone = "timezone";
        public const string FieldIsExternalCollabRestricted = "is_external_collab_restricted";
        public const string FieldMyTags = "my_tags";
        public const string FieldHostname = "hostname";
        public const string FieldExternalAppUserId = "external_app_user_id";
        public const string FieldNotificationEmail = "notification_email";

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = FieldLogin)]
        public virtual string Login { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }

        [JsonProperty(PropertyName = FieldRole)]
        public virtual string Role { get; private set; }

        [JsonProperty(PropertyName = FieldLanguage)]
        public virtual string Language { get; private set; }

        [JsonProperty(PropertyName = FieldSpaceAmount)]
        public virtual long? SpaceAmount { get; private set; }

        [JsonProperty(PropertyName = FieldSpaceUsed)]
        public virtual long? SpaceUsed { get; private set; }

        [JsonProperty(PropertyName = FieldMaxUploadSize)]
        public virtual long? MaxUploadSize { get; private set; }

        [JsonProperty(PropertyName = FieldTrackingCodes)]
        public virtual IList<BoxTrackingCode> TrackingCodes { get; private set; }

        [JsonProperty(PropertyName = FieldCanSeeManagedUsers)]
        public virtual bool? CanSeeManagedUsers { get; private set; }

        [JsonProperty(PropertyName = FieldIsSyncEnabled)]
        public virtual bool? IsSyncEnabled { get; private set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; private set; }

        [JsonProperty(PropertyName = FieldJobTitle)]
        public virtual string JobTitle { get; private set; }

        [JsonProperty(PropertyName = FieldPhone)]
        public virtual string Phone { get; private set; }

        [JsonProperty(PropertyName = FieldAddress)]
        public virtual string Address { get; private set; }

        [JsonProperty(PropertyName = FieldAvatarUrl)]
        public virtual string AvatarUrl { get; private set; }

        [JsonProperty(PropertyName = FieldIsExemptFromDeviceLimits)]
        public virtual bool IsExemptFromDeviceLimits { get; private set; }

        [JsonProperty(PropertyName = FieldIsExemptFromLoginVerification)]
        public virtual bool IsExemptFromLoginVerification { get; private set; }

        [JsonProperty(PropertyName = FieldEnterprise)]
        public virtual BoxEnterprise Enterprise { get; private set; }

        [JsonProperty(PropertyName = FieldIsPlatformAccessOnly)]
        public virtual bool? IsPlatformAccessOnly { get; private set; }

        [JsonProperty(PropertyName = FieldTimezone)]
        public virtual string Timezone { get; private set; }

        [JsonProperty(PropertyName = FieldIsExternalCollabRestricted)]
        public virtual bool? IsExternalCollabRestricted { get; private set; }

        [JsonProperty(PropertyName = FieldMyTags)]
        public virtual string[] Tags { get; private set; }

        [JsonProperty(PropertyName = FieldHostname)]
        public virtual string Hostname { get; private set; }

        [JsonProperty(PropertyName = FieldExternalAppUserId)]
        public virtual string ExternalAppUserId { get; private set; }

        [JsonProperty(PropertyName = FieldNotificationEmail)]
        public virtual BoxNotificationEmail NotificationEmail { get; set; }
    }
}