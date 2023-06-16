using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSignRequestSignFiles
    {
        public const string FieldFiles = "files";
        public const string FieldIsReadyForDownload = "is_ready_for_download";

        [JsonProperty(PropertyName = FieldFiles)]
        public virtual List<BoxFile> Files { get; private set; }

        [JsonProperty(PropertyName = FieldIsReadyForDownload)]
        public virtual bool IsReadyForDownload { get; private set; }
    }
}