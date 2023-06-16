using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxFileLockRequest
    {
        [JsonProperty(PropertyName = "lock")]
        public BoxFileLock Lock { get; set; }
    }
}