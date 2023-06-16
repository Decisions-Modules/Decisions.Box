using System.IO;
using System.Net;
using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxFilePreview
    {
        public virtual Stream PreviewStream { get; set; }

        public virtual HttpStatusCode ReturnedStatusCode { get; set; }

        public virtual int TotalPages { get; set; }

        public virtual int CurrentPage { get; set; }
    }
}