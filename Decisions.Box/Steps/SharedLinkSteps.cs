using System.Threading.Tasks;
using Box.V2;
using Box.V2.Models;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Box.Steps;

[AutoRegisterMethodsOnClass(true, "Integration/Box/Shared Links")]
public class SharedLinkSteps
{
    public string CreateSharedLink(string fileId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();

        var sharedLinkParams = new BoxSharedLinkRequest()
        {
            Access = BoxSharedLinkAccessType.open,
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
}