using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRepresentationProperties
    {
        public const string FieldDimensions = "dimensions";
        public const string FieldPaged = "paged";
        public const string FieldThumb = "thumb";

        [JsonProperty(PropertyName = FieldDimensions)]
        public virtual string Dimensions { get; private set; }

        [JsonProperty(PropertyName = FieldPaged)]
        public virtual bool Paged { get; private set; }

        [JsonProperty(PropertyName = FieldThumb)]
        public virtual bool Thumb { get; private set; }
    }
}