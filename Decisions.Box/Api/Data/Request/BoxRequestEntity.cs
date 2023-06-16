using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxRequestEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxType? Type { get; set; }
    }
}

[DataContract]
public enum BoxType
{
    file,
    discussion,
    comment,
    folder,
    retention_policy,
    enterprise,
    user,
    group,
    web_link,
    file_version,
    metadata_template,
    terms_of_service
}