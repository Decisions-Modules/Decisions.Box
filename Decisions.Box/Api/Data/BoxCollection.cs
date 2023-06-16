using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public abstract class BoxCollection
    {
        public const string FieldTotalCount = "total_count";
        public const string FieldEntries = "entries";
        public const string FieldOffset = "offset";
        public const string FieldLimit = "limit";
        public const string FieldOrder = "order";
        public const string FieldNextMarker = "next_marker";
    }

    [DataContract]
    [Writable]
    public abstract class BoxCollectionMarkerBased
    {
        public const string FieldEntries = "entries";
        public const string FieldMarker = "next_marker";
        public const string FieldLimit = "limit";
        public const string FieldOrder = "order";
    }

    [DataContract]
    [Writable]
    public abstract class BoxEventCollection
    {
        public const string FieldChunkSize = "chunk_size";
        public const string FieldNextStreamPosition = "next_stream_position";
        public const string FieldEntries = "entries";
    }

    [DataContract]
    [Writable]
    public abstract class BoxLongPollInfoCollection
    {
        public const string FieldChunkSize = "chunk_size";
        public const string FieldEntries = "entries";
    }

    [DataContract]
    [Writable]
    public abstract class BoxWebhookCollection
    {
        public const string FieldLimit = "limit";
        public const string FieldNextMarker = "next_marker";
        public const string FieldEntries = "entries";
    }

    [DataContract]
    [Writable]
    public abstract class BoxRepresentationCollection
    {
        public const string FieldEntries = "entries";
    }

    [DataContract]
    [Writable]
    public abstract class BoxTermsOfServiceCollection
    {
        public const string FieldEntries = "entries";
        public const string FieldTotalCount = "total_count";
    }

    [DataContract]
    [Writable]
    public abstract class BoxTermsOfServiceUserStatusesCollection
    {
        public const string FieldEntries = "entries";
        public const string FieldTotalCount = "total_count";
    }

    [DataContract]
    [Writable]
    public abstract class BoxMetadataTemplateCollection
    {
        public const string FieldEntries = "entries";
    }

    [DataContract]
    [Writable]
    public abstract class BoxEnterpriseMetadataTemplateCollection
    {
        public const string FieldEntries = "entries";
        public const string FieldTotalCount = "total_count";
    }

    [DataContract]
    [Writable]
    public class BoxCollection<T> : BoxCollection where T : class, new()
    {
        [JsonProperty(PropertyName = FieldTotalCount)]
        public virtual int TotalCount { get; set; }

        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; set; }

        [JsonProperty(PropertyName = FieldOffset)]
        public virtual int Offset { get; set; }

        [JsonProperty(PropertyName = FieldLimit)]
        public virtual int Limit { get; set; }

        [JsonProperty(PropertyName = FieldOrder)]
        public virtual List<BoxSortOrder> Order { get; set; }
    }

    [DataContract]
    [Writable]
    public class BoxCollectionMarkerBased<T> : BoxCollectionMarkerBased where T : class, new()
    {
        [JsonProperty(PropertyName = FieldLimit)]
        public virtual int Limit { get; set; }

        [JsonProperty(PropertyName = FieldMarker)]
        public virtual string NextMarker { get; set; }

        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; set; }

        [JsonProperty(PropertyName = FieldOrder)]
        public virtual List<BoxSortOrder> Order { get; set; }
    }

    [DataContract]
    [Writable]
    public class BoxCollectionMarkerBasedV2<T> : BoxCollectionMarkerBased where T : class, new()
    {
        [JsonProperty(PropertyName = FieldLimit)]
        public virtual int Limit { get; set; }

        [JsonProperty(PropertyName = FieldMarker)]
        public virtual string NextMarker { get; set; }

        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; set; }

        [JsonProperty(PropertyName = FieldOrder)]

        public virtual BoxSortOrder Order { get; set; }
    }

    [DataContract]
    [Writable]
    public class BoxEventCollection<T> : BoxEventCollection where T : BoxEnterpriseEvent
    {
        [JsonProperty(PropertyName = FieldChunkSize)]
        public virtual int ChunkSize { get; set; }

        [JsonProperty(PropertyName = FieldNextStreamPosition)]
        public virtual string NextStreamPosition { get; set; }

        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; set; }
    }

    [DataContract]
    [Writable]
    public class BoxLongPollInfoCollection<T> : BoxLongPollInfoCollection where T : BoxLongPollInfo
    {
        [JsonProperty(PropertyName = FieldChunkSize)]
        public virtual int ChunkSize { get; private set; }

        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; private set; }
    }

    [DataContract]
    [Writable]
    public class BoxMetadataTemplateCollection<T> : BoxMetadataTemplateCollection where T : Dictionary<string, object>
    {
        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; private set; }
    }

    [DataContract]
    [Writable]
    public class BoxRepresentationCollection<T> : BoxRepresentationCollection where T : BoxRepresentation
    {
        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; private set; }
    }

    [DataContract]
    [Writable]
    public class BoxTermsOfServiceCollection<T> : BoxTermsOfServiceCollection where T : BoxTermsOfService
    {
        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; private set; }

        [JsonProperty(PropertyName = FieldTotalCount)]
        public virtual int TotalCount { get; private set; }
    }

    [DataContract]
    [Writable]
    public class BoxTermsOfServiceUserStatusesCollection<T> : BoxTermsOfServiceUserStatusesCollection
        where T : BoxTermsOfServiceUserStatuses
    {
        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; private set; }

        [JsonProperty(PropertyName = FieldTotalCount)]
        public virtual int TotalCount { get; private set; }
    }

    [DataContract]
    [Writable]
    public class BoxEnterpriseMetadataTemplateCollection<T> : BoxEnterpriseMetadataTemplateCollection
        where T : BoxMetadataTemplate
    {
        [JsonProperty(PropertyName = FieldEntries)]
        public virtual List<T> Entries { get; private set; }

        [JsonProperty(PropertyName = FieldTotalCount)]
        public virtual int TotalCount { get; private set; }
    }
}