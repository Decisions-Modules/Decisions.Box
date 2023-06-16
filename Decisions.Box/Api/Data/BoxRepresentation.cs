using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRepresentation
    {
        public const string FieldContent = "content";
        public const string FieldInfo = "info";
        public const string FieldProperties = "properties";
        public const string FieldRepresentation = "representation";
        public const string FieldStatus = "status";

        [JsonProperty(PropertyName = FieldContent)]
        public virtual BoxRepresentationContent Content { get; set; }

        [JsonProperty(PropertyName = FieldInfo)]
        public virtual BoxRepresentationInfo Info { get; set; }

        [JsonProperty(PropertyName = FieldProperties)]
        public virtual BoxRepresentationProperties Properties { get; set; }

        [JsonProperty(PropertyName = FieldRepresentation)]
        public virtual string Representation { get; set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual BoxRepresentationStatus Status { get; set; }
    }
}