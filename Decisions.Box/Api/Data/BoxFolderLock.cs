using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFolderLock : BoxEntity
    {
        public const string FieldCreatedAt = "created_at";
        public const string FieldCreatedBy = "created_by";
        public const string FieldFolder = "folder";
        public const string FieldLockType = "lock_type";
        public const string FieldLockedOperations = "locked_operations";

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldFolder)]
        public virtual BoxFolder Folder { get; private set; }

        [JsonProperty(PropertyName = FieldLockType)]
        public virtual string LockType { get; private set; }

        [JsonProperty(PropertyName = FieldLockedOperations)]
        public virtual BoxFolderLockOperations LockedOperations { get; private set; }
    }
}