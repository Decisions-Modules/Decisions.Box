using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxGroup : BoxEntity
    {
        public const string FieldName = "name";
        public const string FieldCreatedAt = "created_at";
        public const string FieldModifiedAt = "modified_at";
        public const string FieldDescription = "description";
        public const string FieldProvenance = "provenance";
        public const string FieldExternalSyncIdentifier = "external_sync_identifier";
        public const string FieldInvitabilityLevel = "invitability_level";
        public const string FieldMemberViewabilityLevel = "member_viewability_level";

        [JsonProperty(PropertyName = FieldName)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedAt)]
        public virtual DateTimeOffset? CreatedAt { get; private set; }

        [JsonProperty(PropertyName = FieldModifiedAt)]
        public virtual DateTimeOffset? ModifiedAt { get; private set; }

        [JsonProperty(PropertyName = FieldDescription)]
        public virtual string Description { get; private set; }

        [JsonProperty(PropertyName = FieldProvenance)]
        public virtual string Provenance { get; private set; }

        [JsonProperty(PropertyName = FieldExternalSyncIdentifier)]
        public virtual string ExternalSyncIdentifier { get; private set; }

        [JsonProperty(PropertyName = FieldInvitabilityLevel)]
        public virtual string InvitabilityLevel { get; private set; }

        [JsonProperty(PropertyName = FieldMemberViewabilityLevel)]
        public virtual string MemberViewabilityLevel { get; private set; }
    }
}