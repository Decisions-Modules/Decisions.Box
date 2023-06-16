using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxRepresentationStatus
    {
        public const string FieldState = "state";

        [JsonProperty(PropertyName = FieldState)]
        public virtual string State { get; private set; }
    }
}