using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Decisions.Box
{
    [DataContract]
    public class FolderItem
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string sequence_id { get; set; }
        [DataMember]
        public string etag { get; set; }
        [DataMember]
        public string name { get; set; }

    }
}
