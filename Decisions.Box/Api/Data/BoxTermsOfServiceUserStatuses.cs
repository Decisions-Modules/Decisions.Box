using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxTermsOfServiceUserStatuses : BoxEntity
    {
        public const string FieldTos = "tos";
        public const string FieldUser = "user";
        public const string FieldIsAccepted = "is_accepted";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";

        [JsonProperty(PropertyName = FieldTos)]
        public virtual BoxEntity TermsOfService { get; set; }

        [JsonProperty(PropertyName = FieldUser)]
        public virtual BoxUser User { get; set; }

        [JsonProperty(PropertyName = FieldIsAccepted)]
        public virtual bool IsAccepted { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }
    }
}