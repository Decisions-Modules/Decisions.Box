using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxExpiringEmbedLink
    {
        public const string FieldUrl = "url";

        [JsonProperty(PropertyName = FieldUrl)]
        public virtual Uri Url { get; private set; }
    }
}