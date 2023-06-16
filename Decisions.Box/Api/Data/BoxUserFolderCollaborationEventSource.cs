using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxUserFolderCollaborationEventSource : BoxEntity
    {
        public const string FieldFolderId = "folder_id";
        public const string FieldFolderName = "folder_name";
        public const string FieldUserId = "user_id";
        public const string FieldUserName = "user_name";
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

        [JsonProperty(PropertyName = FieldUserId)]
        public string UserId { get; private set; }

        [JsonProperty(PropertyName = FieldUserName)]
        public string UserName { get; private set; }

        [JsonProperty(PropertyName = FieldParent)]
        public BoxFolder Parent { get; private set; }
    }
}