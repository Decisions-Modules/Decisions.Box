using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxWatermarkRequest
    {
        public const string DefaultImprintString = "default";

        [JsonProperty(PropertyName = "imprint")]
        public string Imprint { get; set; } = DefaultImprintString;
    }
}