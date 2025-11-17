using System;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Models;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Box.Steps;

[AutoRegisterMethodsOnClass(true, "Integration/Box/Shared Links")]
public class SharedLinkSteps
{
    public string CreateSharedLink(string fileId, SharedLinkAccessType accessType = SharedLinkAccessType.Open)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();

        var sharedLinkParams = new BoxSharedLinkRequest()
        {
            Access = ToBoxAccessType(accessType),
            Permissions = new BoxPermissionsRequest
            {
                Download = true,
                Edit = true
            }
        };
        
        Task<string> t = Task.Run(async () =>
        {
            var file = await client.FilesManager.CreateSharedLinkAsync(fileId, sharedLinkParams);
            return file.SharedLink.Url;
        });
        t.Wait();

        return t.Result;
    }

    private static BoxSharedLinkAccessType ToBoxAccessType(SharedLinkAccessType accessType)
    {
        switch (accessType)
        {
            case SharedLinkAccessType.Open:
                return BoxSharedLinkAccessType.open;
            case SharedLinkAccessType.Company:
                return BoxSharedLinkAccessType.company;
            case SharedLinkAccessType.Collaborators:
                return BoxSharedLinkAccessType.collaborators;
            default:
                throw new ArgumentOutOfRangeException(nameof(accessType), accessType, "Unsupported Shared Link Access Type");
        }
    }
}
public enum SharedLinkAccessType
{
    Open,
    Company,
    Collaborators
}