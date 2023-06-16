using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFolderLockOperations
    {
        public const string FieldDelete = "delete";
        public const string FieldMove = "move";

        [JsonProperty(PropertyName = FieldDelete)]
        public virtual bool Delete { get; private set; }

        [JsonProperty(PropertyName = FieldMove)]
        public virtual bool Move { get; private set; }
    }
}