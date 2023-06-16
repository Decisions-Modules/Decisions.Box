using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxApplyWatermarkRequest
    {
        [JsonProperty(PropertyName = "watermark")]
        public BoxWatermarkRequest Watermark { get; set; }
    }
}