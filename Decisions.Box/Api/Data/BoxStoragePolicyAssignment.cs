using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxStoragePolicyAssignment : BoxEntity
    {
        public const string FieldStoragePolicy = "storage_policy";
        public const string FieldAssignedTo = "assigned_to";

        [JsonProperty(PropertyName = FieldStoragePolicy)]
        public virtual BoxEntity BoxStoragePolicy { get; set; }

        [JsonProperty(PropertyName = FieldAssignedTo)]
        public virtual BoxEntity AssignedTo { get; set; }
    }
}