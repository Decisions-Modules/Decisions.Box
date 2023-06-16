using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Decisions.Box.Converters;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxZip
    {
        public const string FieldDownloadUrl = "download_url";
        public const string FieldStatusUrl = "status_url";
        public const string FieldExpiresAt = "expires_at";
        public const string FieldNameConflicts = "name_conflicts";

        [JsonProperty(PropertyName = FieldDownloadUrl)]
        public virtual Uri DownloadUrl { get; private set; }

        [JsonProperty(PropertyName = FieldStatusUrl)]
        public virtual Uri StatusUrl { get; private set; }

        [JsonProperty(PropertyName = FieldExpiresAt)]
        public virtual DateTimeOffset ExpiresAt { get; private set; }

        [JsonProperty(PropertyName = FieldNameConflicts)]
        [JsonConverter(typeof(BoxZipConflictConverter))]
        public virtual List<BoxZipConflict> NameConflicts { get; private set; }
    }
}