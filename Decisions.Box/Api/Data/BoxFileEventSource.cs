using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFileEventSource : BoxEntity
    {
        public const string FieldItemType = "item_type";
        public const string FieldItemId = "item_id";
        public const string FieldItemName = "item_name";
        public const string FieldItemParent = "parent";

        [JsonProperty(PropertyName = FieldItemType)]
        public override string Type { get; protected set; }

        [JsonProperty(PropertyName = FieldItemId)]
        public override string Id { get; protected set; }

        [JsonProperty(PropertyName = FieldItemName)]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = FieldItemParent)]
        public BoxFolder Parent { get; private set; }
    }
}