using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.Box
{
    [DataContract]
    [Writable]
    public class FolderItem
    {
        [DataMember]
        [WritableValue]
        public string type { get; set; }
        [DataMember]
        [WritableValue]
        public string id { get; set; }
        [DataMember]
        [WritableValue]
        public string sequence_id { get; set; }
        [DataMember]
        [WritableValue]
        public string etag { get; set; }
        [DataMember]
        [WritableValue]
        public string name { get; set; }
    }
}