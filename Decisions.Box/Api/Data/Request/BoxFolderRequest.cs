using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxFolderRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "folder_upload_email")]
        public BoxEmailRequest FolderUploadEmail { get; set; }

        [JsonProperty(PropertyName = "owned_by")]
        public BoxRequestEntity OwnedBy { get; private set; }

        [JsonProperty(PropertyName = "sync_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxSyncStateType? SyncState { get; set; }

        [JsonProperty(PropertyName = "can_non_owners_invite")]
        public bool? CanNonOwnersInvite { get; set; }

        [JsonProperty(PropertyName = "is_collaboration_restricted_to_enterprise")]
        public bool? CollaborationRestricted { get; set; }
    }
}