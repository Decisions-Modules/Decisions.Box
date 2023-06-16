using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxWatermarkInfo
    {
        public const string FieldIsWatermarked = "is_watermarked";

        [JsonProperty(PropertyName = FieldIsWatermarked)]
        public virtual bool IsWatermarked { get; private set; }
    }
}