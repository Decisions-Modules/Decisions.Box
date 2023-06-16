using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxEnterpriseEvent
    {
        public const string FieldSource = "source";
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldEventId = "event_id";
        public const string FieldEventType = "event_type";
        public const string FieldIPAddress = "ip_address";
        public const string FieldType = "type";
        public const string FieldSessionId = "session_id";
        public const string FieldAdditionalDetails = "additional_details";
        public const string FieldActionBy = "action_by";


        [JsonProperty(PropertyName = FieldSource)]
        public virtual BoxEntity Source { get; set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldEventId)]
        public virtual string EventId { get; private set; }

        [JsonProperty(PropertyName = FieldEventType)]
        public virtual string EventType { get; private set; }

        [JsonProperty(PropertyName = FieldIPAddress)]
        public virtual string IPAddress { get; private set; }

        [JsonProperty(PropertyName = FieldType)]
        public virtual string Type { get; private set; }

        [JsonProperty(PropertyName = FieldSessionId)]
        public virtual string SessionId { get; private set; }

        [JsonProperty(PropertyName = FieldAdditionalDetails)]
        public virtual Dictionary<string, object> AdditionalDetails { get; private set; }

        [JsonProperty(PropertyName = FieldActionBy)]
        public virtual BoxUser ActionBy { get; private set; }
    }

    public class BoxLongPollInfo
    {
        public const string FieldType = "type";
        public const string FieldURL = "url";
        public const string FieldTTL = "ttl";
        public const string FieldMaxRetries = "max_retries";
        public const string FieldRetryTimeout = "retry_timeout";

        [JsonProperty(PropertyName = FieldType)]
        public virtual string Type { get; set; }

        [JsonProperty(PropertyName = FieldURL)]
        public virtual Uri Url { get; set; }

        [JsonProperty(PropertyName = FieldTTL)]
        public virtual string TTL { get; set; }

        [JsonProperty(PropertyName = FieldMaxRetries)]
        public virtual string MaxRetries { get; set; }

        [JsonProperty(PropertyName = FieldRetryTimeout)]
        public virtual int RetryTimeout { get; set; }
    }

    public class BoxLongPollMessage
    {
        public const string FieldMessage = "message";

        [JsonProperty(PropertyName = FieldMessage)]
        public virtual string Message { get; set; }
    }
}