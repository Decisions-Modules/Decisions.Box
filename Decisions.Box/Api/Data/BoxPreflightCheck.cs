using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxPreflightCheck
    {
        public const string FieldUploadUrl = "upload_url";
        public const string FieldUploadToken = "upload_token";

        [JsonProperty(PropertyName = FieldUploadUrl)]
        public virtual string UploadUrl { get; private set; }

        public virtual Uri UploadUri
        {
            get { return new Uri(UploadUrl); }
        }

        [JsonProperty(PropertyName = FieldUploadToken)]
        public virtual string UploadToken { get; private set; }

        public virtual bool Success { get; set; }
    }
}