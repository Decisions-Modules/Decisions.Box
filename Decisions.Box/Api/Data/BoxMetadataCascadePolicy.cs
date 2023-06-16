using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxMetadataCascadePolicy : BoxEntity
    {
        public const string FieldOwnerEnterprise = "owner_enterprise";
        public const string FieldParent = "parent";
        public const string FieldScope = "scope";
        public const string FieldTemplateKey = "templateKey";

        [JsonProperty(PropertyName = FieldOwnerEnterprise)]
        public virtual BoxEntity OwnerEnterprise { get; private set; }

        [JsonProperty(PropertyName = FieldParent)]
        public virtual BoxEntity Parent { get; private set; }

        [JsonProperty(PropertyName = FieldScope)]
        public virtual string Scope { get; private set; }

        [JsonProperty(PropertyName = FieldTemplateKey)]
        public virtual string TemplateKey { get; private set; }
    }
}