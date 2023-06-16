using System;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxWebLinkRequest : BoxItemRequest
    {
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }
    }
}