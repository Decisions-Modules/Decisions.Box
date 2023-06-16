using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxSignRequestPrefillTag
    {
        public const string FieldCheckboxValue = "checkbox_value";
        public const string FieldDateValue = "date_value";
        public const string FieldDocumentTagId = "document_tag_id";
        public const string FieldTextValue = "text_value";

        // For serialization
        public BoxSignRequestPrefillTag()
        {
        }

        public BoxSignRequestPrefillTag(string documentTagId, bool checkboxValue)
        {
            DocumentTagId = documentTagId;
            CheckboxValue = checkboxValue;
        }

        public BoxSignRequestPrefillTag(string documentTagId, DateTimeOffset dateValue)
        {
            DocumentTagId = documentTagId;
            DateValue = dateValue;
        }

        public BoxSignRequestPrefillTag(string documentTagId, string textValue)
        {
            DocumentTagId = documentTagId;
            TextValue = textValue;
        }

        [JsonProperty(PropertyName = FieldCheckboxValue)]
        public virtual bool? CheckboxValue { get; private set; }

        [JsonProperty(PropertyName = FieldDateValue)]
        public virtual DateTimeOffset? DateValue { get; private set; }

        [JsonProperty(PropertyName = FieldDocumentTagId)]
        public virtual string DocumentTagId { get; private set; }

        [JsonProperty(PropertyName = FieldTextValue)]
        public virtual string TextValue { get; private set; }
    }
}