using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxZipDownloadStatus
    {
        public const string FieldTotalFileCount = "total_file_count";
        public const string FieldDownloadedFileCount = "downloaded_file_count";
        public const string FieldSkippedFileCount = "skipped_file_count";
        public const string FieldSkippedFolderCount = "skipped_folder_count";
        public const string FieldState = "state";

        [JsonProperty(PropertyName = FieldTotalFileCount)]
        public virtual int TotalFileCount { get; set; }

        [JsonProperty(PropertyName = FieldDownloadedFileCount)]
        public virtual int DownloadedlFileCount { get; set; }

        [JsonProperty(PropertyName = FieldSkippedFileCount)]
        public virtual int SkippedFileCount { get; set; }

        [JsonProperty(PropertyName = FieldSkippedFolderCount)]
        public virtual int SkippedFolderCount { get; set; }

        [JsonProperty(PropertyName = FieldState)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxZipDownloadState State { get; set; }

        public virtual List<BoxZipConflict> NameConflicts { get; set; }
    }

    public enum BoxZipDownloadState
    {
        succeeded,
        in_progress,
        failed
    }
}