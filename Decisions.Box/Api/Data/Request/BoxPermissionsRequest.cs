using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxPermissionsRequest
    {
        [JsonProperty(PropertyName = "can_download")]
        public bool Download { get; set; }

        [JsonProperty(PropertyName = "can_edit")]
        public bool? Edit { get; set; }
    }

    [DataContract]
    public enum BoxPermissionType
    {
        Open,
        Company
    }
}