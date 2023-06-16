using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxComment : BoxEntity
    {
        public const string FieldIsReplyComment = "is_reply_comment";
        public const string FieldMessage = "message";
        public const string FieldTaggedMessage = "tagged_message";
        public const string FieldItem = "item";
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";

        [JsonProperty(PropertyName = FieldIsReplyComment)]
        public virtual bool IsReplyComment { get; set; }

        [JsonProperty(PropertyName = FieldMessage)]
        public virtual string Message { get; set; }

        [JsonProperty(PropertyName = FieldTaggedMessage)]
        public virtual string TaggedMessage { get; set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; set; }

        [JsonProperty(PropertyName = FieldItem)]
        public virtual BoxEntity Item { get; set; }
    }
}