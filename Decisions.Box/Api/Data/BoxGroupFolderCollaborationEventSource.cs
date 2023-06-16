using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxGroupFolderCollaborationEventSource : BoxEntity
    {
        public const string FieldFolderId = "folder_id";
        public const string FieldFolderName = "folder_name";
        public const string FieldGroupId = "group_id";
        public const string FieldGroupName = "group_name";
        public const string FieldParent = "parent";

        [JsonProperty(PropertyName = FieldFolderId)]
        public override string Id { get; protected set; }

        public override string Type
        {
            get { return "folder"; }
            protected set { return; }
        }

        [JsonProperty(PropertyName = FieldFolderName)]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = FieldGroupId)]
        public string GroupId { get; private set; }

        [JsonProperty(PropertyName = FieldGroupName)]
        public string GroupName { get; private set; }

        [JsonProperty(PropertyName = FieldParent)]
        public BoxFolder Parent { get; private set; }
    }
}