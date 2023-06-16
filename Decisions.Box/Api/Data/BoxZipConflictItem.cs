using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxZipConflictItem
    {
        public const string FieldId = "id";
        public const string FieldType = "type";
        public const string FieldOriginalName = "original_name";
        public const string FieldDownloadName = "download_name";

        [JsonProperty(PropertyName = FieldId)]
        public virtual string Id { get; private set; }

        [JsonProperty(PropertyName = FieldType)]
        public virtual string Type { get; private set; }

        [JsonProperty(PropertyName = FieldOriginalName)]
        public virtual string OriginalName { get; private set; }

        [JsonProperty(PropertyName = FieldDownloadName)]
        public virtual string DownloadName { get; private set; }
    }
}