using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxEmail
    {
        public const string FieldAccess = "access";
        public const string FieldEmail = "email";

        [JsonProperty(PropertyName = FieldAccess)]
        public virtual string Acesss { get; private set; }

        [JsonProperty(PropertyName = FieldEmail)]
        public virtual string Address { get; private set; }
    }
}