using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxWatermarkResponse : BoxEntity
    {
        public const string FieldWatermark = "watermark";

        [JsonProperty(PropertyName = FieldWatermark)]
        public virtual BoxWatermark Watermark { get; private set; }
    }
}