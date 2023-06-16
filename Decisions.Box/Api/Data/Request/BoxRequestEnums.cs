using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.Box.Api.Data.Request
{
    [DataContract]
    public enum BoxCollaborationRole
    {
        Editor,
        Viewer,
        Previewer,
        Uploader,
        PreviewerUploader,
        ViewerUploader,
        CoOwner
    }

    [DataContract]
    [Writable]
    public static class BoxRequestEnums
    {
        public static string ToString(BoxCollaborationRole value)
        {
            switch (value)
            {
                case BoxCollaborationRole.Editor:
                    return "editor";
                case BoxCollaborationRole.Viewer:
                    return "viewer";
                case BoxCollaborationRole.Previewer:
                    return "previewer";
                case BoxCollaborationRole.Uploader:
                    return "uploader";
                case BoxCollaborationRole.PreviewerUploader:
                    return "previewer uploader";
                case BoxCollaborationRole.ViewerUploader:
                    return "viewer uploader";
                case BoxCollaborationRole.CoOwner:
                    return "co-owner";
                default:
                    return null;
            }
        }
    }
}