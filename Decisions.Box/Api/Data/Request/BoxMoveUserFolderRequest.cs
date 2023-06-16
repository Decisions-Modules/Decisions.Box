using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxMoveUserFolderRequest
    {
        public const string FieldOwnedBy = "owned_by";

        [JsonProperty(PropertyName = FieldOwnedBy)]
        public BoxUserRequest OwnedBy { get; set; }
    }
}