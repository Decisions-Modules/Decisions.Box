using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxTrackingCode
    {
        public const string FieldType = "type";
        public const string FieldName = "name";
        public const string FieldValue = "value";

        public BoxTrackingCode(string name, string value)
        {
            //Per description below, this should always be tracking_code
            Type = "tracking_code";
            Name = name;
            Value = value;
        }

        [JsonProperty(PropertyName = FieldType)]
        public virtual string Type { get; private set; }

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = FieldValue)]
        public virtual string Value { get; private set; }
    }
}