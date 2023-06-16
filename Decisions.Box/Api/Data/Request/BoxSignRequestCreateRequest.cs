using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxSignRequestCreateRequest
    {
        [JsonProperty(PropertyName = "are_reminders_enabled")]
        public bool? AreRemindersEnabled { get; set; }

        [JsonProperty(PropertyName = "are_text_signatures_enabled")]
        public bool? AreTextSignaturesEnabled { get; set; }

        [JsonProperty(PropertyName = "days_valid")]
        public int? DaysValid { get; set; }

        [JsonProperty(PropertyName = "email_message")]
        public string EmailMessage { get; set; }

        [JsonProperty(PropertyName = "email_subject")]
        public string EmailSubject { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }

        [JsonProperty(PropertyName = "is_document_preparation_needed")]
        public bool? IsDocumentPreparationNeeded { get; set; }

        [JsonProperty(PropertyName = "parent_folder")]
        public BoxRequestEntity ParentFolder { get; set; }

        [JsonProperty(PropertyName = "prefill_tags")]
        public List<BoxSignRequestPrefillTag> PrefillTags { get; set; }

        [JsonProperty(PropertyName = "signers")]
        public List<BoxSignRequestSignerCreate> Signers { get; set; }

        [JsonProperty(PropertyName = "source_files")]
        public List<BoxSignRequestCreateSourceFile> SourceFiles { get; set; }

        [JsonProperty(PropertyName = "declined_redirect_url")]
        public Uri DeclinedRedirectUrl { get; set; }

        [JsonProperty(PropertyName = "redirect_url")]
        public Uri RedirectUrl { get; set; }
    }

    public class BoxSignRequestCreateSourceFile
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type => "file";

        [JsonProperty(PropertyName = "file_version")]
        public BoxSignRequestCreateSourceFileVersion FileVersion { get; set; }
    }

    public class BoxSignRequestCreateSourceFileVersion
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type => "file_version";
    }

    public class BoxSignRequestSignerCreate
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "embed_url_external_user_id")]
        public string EmbedUrlExternalUserId { get; set; }

        [JsonProperty(PropertyName = "is_in_person")]
        public bool? IsInPerson { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int? Order { get; set; }

        [JsonProperty(PropertyName = "role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxSignRequestSignerRole? Role { get; set; }

        [JsonProperty(PropertyName = "declined_redirect_url")]
        public Uri DeclinedRedirectUrl { get; set; }

        [JsonProperty(PropertyName = "redirect_url")]
        public Uri RedirectUrl { get; set; }
    }
}