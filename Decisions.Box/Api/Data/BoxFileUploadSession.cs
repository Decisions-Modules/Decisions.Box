using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFileUploadSession : BoxEntity
    {
        public const string FieldSessionExpiresAt = "session_expires_at";
        public const string FieldPartSize = "part_size";
        public const string FieldSessionEndpoints = "session_endpoints";
        public const string FieldTotalParts = "total_parts";
        public const string FieldNumPartsProcessed = "num_parts_processed";

        [JsonProperty(PropertyName = FieldSessionExpiresAt)]
        public virtual string SessionExpiresAt { get; private set; }

        [JsonProperty(PropertyName = FieldPartSize)]
        public virtual string PartSize { get; private set; }

        [JsonProperty(PropertyName = FieldSessionEndpoints)]
        public virtual BoxSessionEndpoint SessionEndpoints { get; private set; }

        [JsonProperty(PropertyName = FieldTotalParts)]
        public virtual int TotalParts { get; private set; }

        [JsonProperty(PropertyName = FieldNumPartsProcessed)]
        public virtual int NumPartsProcessed { get; private set; }
    }
}