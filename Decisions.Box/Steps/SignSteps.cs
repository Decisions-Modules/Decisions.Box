using System.Collections.Generic;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Models;
using Box.V2.Models.Request;
using Decisions.Box.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Box.Steps;

[AutoRegisterMethodsOnClass(true, "Integration/Box/Sign")]
public class SignSteps
{
    public string CreateSignRequest(string parentFolderId, string documentId, string signerEmail)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();
        var sourceFiles = new List<BoxSignRequestCreateSourceFile>
        {
            new BoxSignRequestCreateSourceFile() { Id = documentId }
        };

        var signers = new List<BoxSignRequestSignerCreate>
        {
            new BoxSignRequestSignerCreate() { Email = signerEmail }
        };

        var parentFolder = new BoxRequestEntity()
        {
            Id = parentFolderId,
            Type = BoxType.folder
        };

        var request = new BoxSignRequestCreateRequest
        {
            SourceFiles = sourceFiles,
            Signers = signers,
            ParentFolder = parentFolder
        };

        Task<string> t = Task.Run(async () =>
        {
            BoxSignRequest signRequest = await client.SignRequestsManager.CreateSignRequestAsync(request);
            return signRequest.Id;
        });
        t.Wait();
        
        return t.Result;
    }

    public SignRequest[] ListSignRequests()
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();
        Task<SignRequest[]> t = Task.Run(async () =>
        {
            BoxCollectionMarkerBased<BoxSignRequest> signRequests = await client.SignRequestsManager.GetSignRequestsAsync();
            var requests = new List<SignRequest>();
            foreach (var item in signRequests.Entries)
            {
                requests.Add(new SignRequest()
                {
                    Id = item.SourceFiles[0].Id,
                    SignerEmail = item.Signers[0].Email,
                    Status = item.Status.ToString(),
                });
            }

            return requests.ToArray();
        });
        t.Wait();
        
        return t.Result;
    }

    public void ResendSignRequest(string requestId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();
        Task t = Task.Run(async () =>
        {
            await client.SignRequestsManager.ResendSignRequestAsync(requestId);
        });
        t.Wait();
    }

    public void CancelSignRequest(string requestId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();
        Task t = Task.Run(async () =>
        {
            BoxSignRequest cancelledSignRequest = await client.SignRequestsManager.CancelSignRequestAsync(requestId);
        });
        t.Wait();
    }
}