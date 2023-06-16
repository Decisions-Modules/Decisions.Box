using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxDevicePin : BoxEntity
    {
        public const string FieldOwnedBy = "owned_by";
        public const string FieldProductName = "product_name";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";

        [JsonProperty(PropertyName = FieldOwnedBy)]
        public virtual BoxUser OwnedBy { get; private set; }

        [JsonProperty(PropertyName = FieldProductName)]
        public virtual string ProductName { get; set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }
    }
}