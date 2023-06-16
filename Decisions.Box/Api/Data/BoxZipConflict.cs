using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxZipConflict
    {
        [JsonProperty(PropertyName = "items")]
        public virtual List<BoxZipConflictItem> items { get; private set; }
    }
}