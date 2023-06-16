using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxNotificationEmail : BoxNotificationEmailField
    {
        public const string isConfirmed = "is_confirmed";

        [JsonProperty(PropertyName = isConfirmed)]
        public virtual bool? IsConfirmed { get; private set; }
    }
}