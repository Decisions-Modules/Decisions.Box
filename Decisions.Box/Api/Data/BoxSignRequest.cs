using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSignRequest : BoxEntity
    {
        public const string FieldAreRemindersEnabled = "are_reminders_enabled";
        public const string FieldTextSignaturesEnabled = "are_text_signatures_enabled";
        public const string FieldAutoExpireAt = "auto_expire_at";
        public const string FieldDaysValid = "days_valid";
        public const string FieldEmailMessage = "email_message";
        public const string FieldEmailSubject = "email_subject";
        public const string FieldExternalId = "external_id";
        public const string FieldIsDocumentPreparationNeeded = "is_document_preparation_needed";
        public const string FieldParentFolder = "parent_folder";
        public const string FieldPrefillTags = "prefill_tags";
        public const string FieldPrepareUrl = "prepare_url";
        public const string FieldSignFiles = "sign_files";
        public const string FieldSigners = "signers";
        public const string FieldSigningLog = "signing_log";
        public const string FieldSourceFiles = "source_files";
        public const string FieldStatus = "status";
        public const string FieldDeclinedRedirectUrl = "declined_redirect_url";
        public const string FieldRedirectUrl = "redirect_url";

        [JsonProperty(PropertyName = FieldAreRemindersEnabled)]
        public virtual bool AreRemindersEnabled { get; private set; }

        [JsonProperty(PropertyName = FieldTextSignaturesEnabled)]
        public virtual bool AreTextSignaturesEnabled { get; private set; }

        [JsonProperty(PropertyName = FieldAutoExpireAt)]
        public virtual DateTimeOffset? AutoExpireAt { get; private set; }

        [JsonProperty(PropertyName = FieldDaysValid)]
        public virtual int? DaysValid { get; private set; }

        [JsonProperty(PropertyName = FieldEmailMessage)]
        public virtual string EmailMessage { get; private set; }

        [JsonProperty(PropertyName = FieldEmailSubject)]
        public virtual string EmailSubject { get; private set; }

        [JsonProperty(PropertyName = FieldExternalId)]
        public virtual string ExternalId { get; private set; }

        [JsonProperty(PropertyName = FieldIsDocumentPreparationNeeded)]
        public virtual bool IsDocumentPreparationNeeded { get; private set; }

        [JsonProperty(PropertyName = FieldParentFolder)]
        public virtual BoxFolder ParentFolder { get; private set; }

        [JsonProperty(PropertyName = FieldPrefillTags)]
        public virtual List<BoxSignRequestPrefillTag> PrefillTags { get; private set; }

        [JsonProperty(PropertyName = FieldPrepareUrl)]
        public virtual Uri PrepareUrl { get; private set; }

        [JsonProperty(PropertyName = FieldSignFiles)]
        public virtual BoxSignRequestSignFiles SignFiles { get; private set; }

        [JsonProperty(PropertyName = FieldSigners)]
        public virtual List<BoxSignRequestSigner> Signers { get; private set; }

        [JsonProperty(PropertyName = FieldSigningLog)]
        public virtual BoxFile SigningLog { get; private set; }

        [JsonProperty(PropertyName = FieldSourceFiles)]
        public virtual List<BoxFile> SourceFiles { get; private set; }

        [JsonProperty(PropertyName = FieldStatus)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSignRequestStatus Status { get; private set; }

        [JsonProperty(PropertyName = FieldDeclinedRedirectUrl)]
        public virtual Uri DeclinedRedirectUrl { get; private set; }

        [JsonProperty(PropertyName = FieldRedirectUrl)]
        public virtual Uri RedirectUrl { get; private set; }
    }

    public enum BoxSignRequestStatus
    {
        converting,
        created,
        sent,
        viewed,
        signed,
        cancelled,
        declined,
        error_converting,
        error_sending,
        expired,
        downloaded,

        [EnumMember(Value = "signed and downloaded")]
        signed_and_downloaded
    }
}