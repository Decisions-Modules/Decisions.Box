using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFileVersionRetention : BoxEntity
    {
        public const string FieldFileVersion = "file_version";
        public const string FieldFile = "file";
        public const string FieldAppliedAt = "applied_at";
        public const string FieldDispositionAt = "disposition_at";
        public const string FieldWinningRetentionPolicy = "winning_retention_policy";

        [JsonProperty(PropertyName = FieldFileVersion)]
        public virtual BoxFileVersion FileVersion { get; set; }

        [JsonProperty(PropertyName = FieldFile)]
        public virtual BoxFile File { get; set; }

        [JsonProperty(PropertyName = FieldAppliedAt)]
        public virtual DateTimeOffset? AppliedAt { get; set; }

        [JsonProperty(PropertyName = FieldDispositionAt)]
        public virtual DateTimeOffset? DispositionAt { get; set; }

        [JsonProperty(PropertyName = FieldWinningRetentionPolicy)]
        public virtual BoxRetentionPolicy WinningRetentionPolicy { get; set; }
    }
}