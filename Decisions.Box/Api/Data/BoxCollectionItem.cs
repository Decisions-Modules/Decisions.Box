using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxCollectionItem : BoxEntity
    {
        private const string FieldName = "name";
        private const string FieldCollectionType = "collection_type";

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = FieldCollectionType)]
        public virtual string CollectionType { get; private set; }
    }
}