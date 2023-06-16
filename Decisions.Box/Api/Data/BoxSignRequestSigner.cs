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
    public class BoxSignRequestSigner
    {
        public const string FieldEmail = "email";
        public const string FieldEmbedUrl = "embed_url";
        public const string FieldEmbedUrlExternalUserId = "embed_url_external_user_id";
        public const string FieldHasViewedDocument = "has_viewed_document";
        public const string FieldInputs = "inputs";
        public const string FieldIsInPerson = "is_in_person";
        public const string FieldOrder = "order";
        public const string FieldRole = "role";
        public const string FieldSignerDecision = "signer_decision";
        public const string FieldDeclinedRedirectUrl = "declined_redirect_url";
        public const string FieldRedirectUrl = "redirect_url";

        [JsonProperty(PropertyName = FieldEmail)]
        public virtual string Email { get; private set; }

        [JsonProperty(PropertyName = FieldEmbedUrl)]
        public virtual string EmbedUrl { get; private set; }

        [JsonProperty(PropertyName = FieldEmbedUrlExternalUserId)]
        public virtual string EmbedUrlExternalUserId { get; private set; }

        [JsonProperty(PropertyName = FieldHasViewedDocument)]
        public virtual bool HasViewedDocument { get; private set; }

        [JsonProperty(PropertyName = FieldInputs)]
        public virtual List<BoxSignRequestSignerInput> Inputs { get; private set; }

        [JsonProperty(PropertyName = FieldIsInPerson)]
        public virtual bool IsInPerson { get; private set; }

        [JsonProperty(PropertyName = FieldOrder)]
        public virtual int Order { get; private set; }

        [JsonProperty(PropertyName = FieldRole)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSignRequestSignerRole Role { get; private set; }

        [JsonProperty(PropertyName = FieldSignerDecision)]
        public virtual BoxSignRequestSignerDecision SignerDecision { get; private set; }

        [JsonProperty(PropertyName = FieldDeclinedRedirectUrl)]
        public virtual Uri DeclinedRedirectUrl { get; private set; }

        [JsonProperty(PropertyName = FieldRedirectUrl)]
        public virtual Uri RedirectUrl { get; private set; }
    }

    public enum BoxSignRequestSignerRole
    {
        signer,
        approver,
        final_copy_reader
    }

    public class BoxSignRequestSignerInput
    {
        public const string FieldType = "type";
        public const string FieldCheckboxValue = "checkbox_value";
        public const string FieldContentType = "content_type";
        public const string FieldDateValue = "date_value";
        public const string FieldDocumentTagId = "document_tag_id";
        public const string FieldPageIndex = "page_index";
        public const string FieldTextValue = "text_value";

        [JsonProperty(PropertyName = FieldType)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSignRequestSingerInputType Type { get; private set; }

        [JsonProperty(PropertyName = FieldCheckboxValue)]
        public virtual bool? CheckboxValue { get; private set; }

        [JsonProperty(PropertyName = FieldContentType)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSignRequestSingerInputContentType ContentType { get; private set; }

        [JsonProperty(PropertyName = FieldDateValue)]
        public virtual DateTimeOffset? DateValue { get; private set; }

        [JsonProperty(PropertyName = FieldDocumentTagId)]
        public virtual string DocumentTagId { get; private set; }

        [JsonProperty(PropertyName = FieldPageIndex)]
        public virtual int PageIndex { get; private set; }

        [JsonProperty(PropertyName = FieldTextValue)]
        public virtual string TextValue { get; private set; }
    }

    public enum BoxSignRequestSingerInputType
    {
        signature,
        date,
        text,
        checkbox
    }

    public enum BoxSignRequestSingerInputContentType
    {
        initial,
        stamp,
        signature,
        company,
        title,
        email,
        full_name,
        first_name,
        last_name,
        text,
        date,
        checkbox
    }

    public class BoxSignRequestSignerDecision
    {
        public const string FieldType = "type";
        public const string FieldFinalizedAt = "finalized_at";

        [JsonProperty(PropertyName = FieldType)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxSignRequestSingerDecisionType Type { get; private set; }

        [JsonProperty(PropertyName = FieldFinalizedAt)]
        public virtual DateTimeOffset? FinalizedAt { get; private set; }
    }

    public enum BoxSignRequestSingerDecisionType
    {
        signed,
        declined,
    }
}