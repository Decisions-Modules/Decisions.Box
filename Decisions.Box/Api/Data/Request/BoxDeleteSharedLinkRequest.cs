using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxDeleteSharedLinkRequest : BoxRequestEntity
    {
        [JsonProperty(PropertyName = "shared_link", NullValueHandling = NullValueHandling.Include)]
        public BoxSharedLinkRequest SharedLink { get; set; }
    }
}