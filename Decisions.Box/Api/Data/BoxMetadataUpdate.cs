using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxMetadataUpdate
    {
        public const string FieldOp = "op";
        public const string FieldPath = "path";
        public const string FieldValue = "value";
        public const string FieldFrom = "from";

        [JsonProperty(PropertyName = FieldOp)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual MetadataUpdateOp? Op { get; set; }

        [JsonProperty(PropertyName = FieldPath)]
        public virtual string Path { get; set; }

        [JsonProperty(PropertyName = FieldValue)]
        public virtual object Value { get; set; }

        [JsonProperty(PropertyName = FieldFrom)]
        public virtual string From { get; set; }
    }
}