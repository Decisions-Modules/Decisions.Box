using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxWebhook : BoxEntity
    {
        public const string FieldTarget = "target";
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldAddress = "address";
        public const string FieldTriggers = "triggers";

        [JsonProperty(PropertyName = FieldTarget)]
        public virtual BoxEntity Target { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldAddress)]
        public virtual string Address { get; private set; }

        [JsonProperty(PropertyName = FieldTriggers)]
        public virtual IList<string> Triggers { get; protected set; }
    }
}