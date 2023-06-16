using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxGroupEventSource : BoxEntity
    {
        public const string FieldGroupId = "group_id";
        public const string FieldGroupName = "group_name";

        [JsonProperty(PropertyName = FieldGroupId)]
        public override string Id { get; protected set; }

        public override string Type
        {
            get { return "group"; }
            protected set { return; }
        }

        [JsonProperty(PropertyName = FieldGroupName)]
        public string Name { get; private set; }
    }
}