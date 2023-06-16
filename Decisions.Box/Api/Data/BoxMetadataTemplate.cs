using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxMetadataTemplate : BoxEntity
    {
        public const string FieldTemplateKey = "templateKey";
        public const string FieldScope = "scope";
        public const string FieldDisplayName = "displayName";
        public const string FieldFields = "fields";
        public const string FieldHidden = "hidden";
        public const string FieldCopyInstanceOnItemCopy = "copyInstanceOnItemCopy";

        [JsonProperty(PropertyName = FieldTemplateKey)]
        public virtual string TemplateKey { get; set; }

        [JsonProperty(PropertyName = FieldScope)]
        public virtual string Scope { get; set; }

        [JsonProperty(PropertyName = FieldDisplayName)]
        public virtual string DisplayName { get; set; }

        [JsonProperty(PropertyName = FieldFields)]
        public virtual List<BoxMetadataTemplateField> Fields { get; set; }

        [JsonProperty(PropertyName = FieldHidden)]
        public virtual bool? Hidden { get; set; }

        [JsonProperty(PropertyName = FieldCopyInstanceOnItemCopy)]
        public virtual bool? CopyInstanceOnItemCopy { get; set; }
    }

    public class BoxMetadataTemplateField
    {
        public const string FieldId = "id";
        public const string FieldType = "type";
        public const string FieldKey = "key";
        public const string FieldDisplayName = "displayName";
        public const string FieldOptions = "options";
        public const string FieldHidden = "hidden";

        [JsonProperty(PropertyName = FieldId)]
        public virtual string Id { get; set; }

        [JsonProperty(PropertyName = FieldType)]
        public virtual string Type { get; set; }

        [JsonProperty(PropertyName = FieldKey)]
        public virtual string Key { get; set; }

        [JsonProperty(PropertyName = FieldDisplayName)]
        public virtual string DisplayName { get; set; }

        [JsonProperty(PropertyName = FieldHidden)]
        public virtual bool? Hidden { get; set; }

        [JsonProperty(PropertyName = FieldOptions)]
        public virtual List<BoxMetadataTemplateFieldOption> Options { get; set; }
    }

    public class BoxMetadataTemplateFieldOption
    {
        public const string FieldKey = "key";

        [JsonProperty(PropertyName = FieldKey)]
        public virtual string Key { get; set; }
    }
}