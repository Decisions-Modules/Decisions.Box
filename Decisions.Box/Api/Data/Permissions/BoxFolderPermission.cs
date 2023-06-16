using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Permissions
{
    [DataContract]
    [Writable]
    public class BoxFolderPermission : BoxItemPermission
    {
        [JsonProperty(PropertyName = "can_invite_collaborator")]
        public bool CanInviteCollaborator { get; private set; }
    }
}