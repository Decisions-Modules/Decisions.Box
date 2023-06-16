using System.Runtime.Serialization;

namespace Decisions.Box
{
    [DataContract]
    public class FolderItem
    {
        [DataMember] public string type { get; set; }
        [DataMember] public string id { get; set; }
        [DataMember] public string sequence_id { get; set; }
        [DataMember] public string etag { get; set; }
        [DataMember] public string name { get; set; }
    }
}