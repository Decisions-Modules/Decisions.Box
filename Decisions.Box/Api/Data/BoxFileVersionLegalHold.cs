using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFileVersionLegalHold : BoxEntity
    {
        public const string FieldFileVersion = "file_version";
        public const string FieldFile = "file";
        public const string FieldDeletedAt = "deleted_at";
        public const string FieldLegalHoldPolicyAssignments = "legal_hold_policy_assignments";

        [JsonProperty(PropertyName = FieldFileVersion)]
        public virtual BoxFileVersion FileVersion { get; set; }

        [JsonProperty(PropertyName = FieldFile)]
        public virtual BoxFile File { get; set; }

        [JsonProperty(PropertyName = FieldDeletedAt)]
        public virtual DateTimeOffset? DeletedAt { get; set; }

        [JsonProperty(PropertyName = FieldLegalHoldPolicyAssignments)]
        public virtual BoxEntity[] LegalHoldPolicyAssignments { get; set; }
    }
}