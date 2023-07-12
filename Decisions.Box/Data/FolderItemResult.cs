using System.Runtime.Serialization;

namespace Decisions.Box
{
    [DataContract]
    public class FolderItemResult
    {
        [DataMember]
        public int total_count { get; set; }

        [DataMember]
        public FolderItem[] entries { get; set; }

        [DataMember]
        public int offset { get; set; }

        [DataMember]
        public int limit { get; set; }

        [DataMember]
        public string error_message { get; set; }
    }
}