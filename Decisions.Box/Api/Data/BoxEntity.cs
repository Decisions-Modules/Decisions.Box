using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxEntity
    {
        // Marked private as Type and ID are always returned with every response regardless of included Fields
        private const string FieldType = "type";
        private const string FieldId = "id";

        [JsonProperty(PropertyName = FieldId)]
        public virtual string Id { get; protected set; }

        [JsonProperty(PropertyName = FieldType)]
        public virtual string Type { get; protected set; }
    }
}