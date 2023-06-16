using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRepresentationContent
    {
        public const string FieldUrlTemplate = "url_template";

        [JsonProperty(PropertyName = FieldUrlTemplate)]
        public virtual string UrlTemplate { get; private set; }
    }
}