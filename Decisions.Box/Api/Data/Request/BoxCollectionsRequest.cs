using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxCollectionsRequest
    {
        [JsonProperty(PropertyName = "collections")]
        public List<BoxRequestEntity> Collections { get; set; }
    }
}