using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxMetadataFieldFilter
    {
        public const string FieldField = "field";
        public const string FieldValue = "value";

        [JsonProperty(PropertyName = FieldField)]
        public virtual string Field { get; private set; }

        [JsonProperty(PropertyName = FieldValue)]
        public virtual string Value { get; private set; }
    }
}