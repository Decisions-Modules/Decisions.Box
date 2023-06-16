using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxAssignmentCounts
    {
        [JsonProperty(PropertyName = "user")]
        public virtual int User { get; private set; }

        [JsonProperty(PropertyName = "folder")]
        public virtual int Folder { get; private set; }

        [JsonProperty(PropertyName = "file")]
        public virtual int File { get; private set; }

        [JsonProperty(PropertyName = "file_version")]
        public virtual int Version { get; private set; }
    }
}