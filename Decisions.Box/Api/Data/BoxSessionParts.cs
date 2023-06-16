using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSessionParts
    {
        [JsonProperty(PropertyName = "parts")]
        public virtual IEnumerable<BoxSessionPartInfo> Parts { get; set; }
    }

    public class BoxUploadPartResponse
    {
        [JsonProperty(PropertyName = "part")]
        public virtual BoxSessionPartInfo Part { get; set; }
    }

    public class BoxSessionPartInfo
    {
        [JsonProperty(PropertyName = "part_id")]
        public virtual string PartId { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public virtual long Offset { get; set; }

        [JsonProperty(PropertyName = "size")]
        public virtual long Size { get; set; }

        [JsonProperty(PropertyName = "sha1")]
        public virtual string Sha1 { get; set; }
    }
}