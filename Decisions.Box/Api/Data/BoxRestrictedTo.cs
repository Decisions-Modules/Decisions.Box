using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRestrictedTo
    {
        private const string FieldScope = "scope";
        private const string FieldObject = "object";

        [JsonProperty(PropertyName = FieldScope)]
        public virtual string Scope { get; set; }

        [JsonProperty(PropertyName = FieldObject)]
        public virtual BoxItem RestrictedEntity { get; set; }
    }
}