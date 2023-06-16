using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSessionEndpoint
    {
        public const string FieldListParts = "list_parts";
        public const string FieldCommit = "commit";
        public const string FieldLogEvent = "log_event";
        public const string FieldUploadPart = "upload_part";
        public const string FieldAbort = "abort";
        public const string FieldStatus = "status";

        [JsonProperty(PropertyName = FieldListParts)]
        public virtual string ListParts { get; private set; }

        [JsonProperty(PropertyName = FieldCommit)]
        public virtual string Commit { get; private set; }

        [JsonProperty(PropertyName = FieldLogEvent)]
        public virtual string LogEvent { get; private set; }

        [JsonProperty(PropertyName = FieldUploadPart)]
        public virtual string UploadPart { get; private set; }

        [JsonProperty(PropertyName = FieldAbort)]
        public virtual string Abort { get; private set; }

        [JsonProperty(PropertyName = FieldStatus)]
        public virtual string Status { get; private set; }
    }
}