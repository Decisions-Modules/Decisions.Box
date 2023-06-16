using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxCollaborationRequest : BoxRequestEntity
    {
        [JsonProperty(PropertyName = "item")]
        public BoxRequestEntity Item { get; set; }

        [JsonProperty(PropertyName = "accessible_by")]
        public BoxCollaborationUserRequest AccessibleBy { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "can_view_path")]
        public bool? CanViewPath { get; set; }

        [JsonProperty(PropertyName = "expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }
    }

    public static class BoxCollaborationRoles
    {
        public const string Editor = "editor";
        public const string Viewer = "viewer";
        public const string Previewer = "previewer";
        public const string Uploader = "uploader";
        public const string PreviewerUploader = "previewer uploader";
        public const string ViewerUploader = "viewer uploader";
        public const string CoOwner = "co-owner";
        public const string Owner = "owner";
    }
}