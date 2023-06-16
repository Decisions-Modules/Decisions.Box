using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxNotificationEmailField
    {
        public const string email = "email";

        [JsonProperty(PropertyName = email)] public virtual string Email { get; set; }
    }
}