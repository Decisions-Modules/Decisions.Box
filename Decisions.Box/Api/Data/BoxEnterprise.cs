using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxEnterprise : BoxEntity
    {
        public const string FieldName = "name";

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }
    }
}