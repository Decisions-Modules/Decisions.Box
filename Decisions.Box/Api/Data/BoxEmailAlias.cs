using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxEmailAlias : BoxEntity
    {
        public const string FieldIsConfirmed = "is_confirmed";
        public const string FieldEmail = "email";

        [JsonProperty(PropertyName = FieldIsConfirmed)]
        public virtual bool IsConfirmed { get; private set; }

        [JsonProperty(PropertyName = FieldEmail)]
        public virtual string Email { get; private set; }
    }
}