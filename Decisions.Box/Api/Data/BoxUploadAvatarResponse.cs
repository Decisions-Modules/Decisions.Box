using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxUploadAvatarResponse
    {
        public const string FieldPicUrls = "pic_urls";

        [JsonProperty(PropertyName = FieldPicUrls)]
        public virtual PicUrls PicUrls { get; private set; }
    }

    [DataContract]
    [Writable]
    public class PicUrls
    {
        public const string FieldPreview = "preview";
        public const string FieldSmall = "small";
        public const string FieldLarge = "large";

        [JsonProperty(PropertyName = FieldPreview)]
        public virtual string Preview { get; private set; }

        [JsonProperty(PropertyName = FieldSmall)]
        public virtual string Small { get; private set; }

        [JsonProperty(PropertyName = FieldLarge)]
        public virtual string Large { get; private set; }
    }
}