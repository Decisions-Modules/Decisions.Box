using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxPermission
    {
        [JsonProperty("can_download")]
        public virtual bool CanDownload { get; set; }

        [JsonProperty("can_preview")]
        public virtual bool CanPreview { get; set; }

        [JsonProperty("can_edit")]
        public virtual bool? CanEdit { get; set; }
    }
}