using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSessionUploadStatus
    {
        public const string FieldSessionExpiryDate = "session_expires_at";
        public const string FieldPartSize = "part_size";
        public const string FieldTotalParts = "total_parts";
        public const string FieldNumberOfPartsProcessed = "num_parts_processed";

        [JsonProperty(PropertyName = FieldSessionExpiryDate)]
        public virtual DateTimeOffset SessionExpiryDate { get; private set; }

        [JsonProperty(PropertyName = FieldPartSize)]
        public virtual long PartSize { get; private set; }

        [JsonProperty(PropertyName = FieldTotalParts)]
        public virtual int TotalParts { get; private set; }

        [JsonProperty(PropertyName = FieldNumberOfPartsProcessed)]
        public virtual int NumberOfPartsProcessed { get; private set; }
    }
}