using System.Collections.Generic;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    [Writable]
    public class BoxMetadataQueryRequest
    {
        public string From { get; set; }

        public string AncestorFolderId { get; set; }

        public string Query { get; set; }

        public IEnumerable<string> Fields { get; set; }

        public Dictionary<string, object> QueryParameters { get; set; }

        public List<BoxMetadataQueryOrderBy> OrderBy { get; set; }

        public int Limit { get; set; } = 100;

        public string Marker { get; set; }

        public bool AutoPaginate { get; set; }
    }
}