using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Permissions
{
    [DataContract]
    [Writable]
    public class BoxFilePermission : BoxItemPermission
    {
        [JsonProperty(PropertyName = "can_preview")]
        public bool CanPreview { get; private set; }
    }
}