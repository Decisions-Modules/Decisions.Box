using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxUserRequest : BoxRequestEntity
    {
        [JsonProperty(PropertyName = "enterprise")]
        public string Enterprise { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "is_sync_enabled")]
        public bool? IsSyncEnabled { get; set; }

        [JsonProperty(PropertyName = "job_title")]
        public string JobTitle { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "space_amount")]
        public double? SpaceAmount { get; set; }

        [JsonProperty(PropertyName = "tracking_codes")]
        public IList<BoxTrackingCode> TrackingCodes { get; set; }

        [JsonProperty(PropertyName = "can_see_managed_users")]
        public bool? CanSeeManagedUsers { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "is_exempt_from_device_limits")]
        public bool? IsExemptFromDeviceLimits { get; set; }

        [JsonProperty(PropertyName = "is_exempt_from_login_verification")]
        public bool? IsExemptFromLoginVerification { get; set; }

        [JsonProperty(PropertyName = "is_password_reset_required")]
        public bool? IsPasswordResetRequired { get; set; }

        [JsonProperty(PropertyName = "is_platform_access_only")]
        public bool? IsPlatformAccessOnly { get; set; }

        [JsonProperty(PropertyName = "external_app_user_id")]
        public string ExternalAppUserId { get; set; }

        [JsonProperty(PropertyName = "is_external_collab_restricted")]
        public bool? IsExternalCollabRestricted { get; set; }

        [JsonProperty(PropertyName = "notification_email")]
        public BoxNotificationEmailField NotificationEmail { get; set; }
    }
}