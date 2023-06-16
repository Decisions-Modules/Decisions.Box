using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxFileUploadSessionRequest
    {
        [JsonProperty(PropertyName = "folder_id")]
        public string FolderId { get; set; }

        [JsonProperty(PropertyName = "file_size")]
        public long FileSize { get; set; }

        [JsonProperty(PropertyName = "file_name")]
        public string FileName { get; set; }
    }
}