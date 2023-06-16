using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Permissions
{
    [DataContract]
    [Writable]
    public class BoxItemPermission
    {
        [JsonProperty(PropertyName = "can_download")]
        public bool CanDownload { get; private set; }
        
        [JsonProperty(PropertyName = "can_upload")]
        public bool CanUpload { get; private set; }
        
        [JsonProperty(PropertyName = "can_comment")]
        public bool CanComment { get; private set; }
        
        [JsonProperty(PropertyName = "can_rename")]
        public bool CanRename { get; private set; }
        
        [JsonProperty(PropertyName = "can_delete")]
        public bool CanDelete { get; private set; }
        
        [JsonProperty(PropertyName = "can_share")]
        public bool CanShare { get; private set; }
        
        [JsonProperty(PropertyName = "can_set_share_access")]
        public bool CanSetShareAccess { get; private set; }
    }
}