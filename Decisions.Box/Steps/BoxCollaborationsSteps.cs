using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Collaboration")]
    public class BoxCollaborationsSteps
    {
        [AutoRegisterMethod("Add Collaboration")]
        public BoxCollaboration AddCollaborationStep([TokenPicker] string tokenId, BoxCollaborationRequest collaborationRequest)
        {
            var url = $"{StringConstants.BaseUrl}collaborations/";
            var requestBody = JsonConvert.SerializeObject(collaborationRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollaboration>(response);
        }

        [AutoRegisterMethod("Edit Collaboration")]
        public BoxCollaboration EditCollaborationStep([TokenPicker] string tokenId, BoxCollaborationRequest collaborationRequest)
        {
            var url = $"{StringConstants.BaseUrl}collaborations/{collaborationRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(collaborationRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollaboration>(response);
        }

        [AutoRegisterMethod("Remove Collaboration")]
        public bool RemoveCollaborationStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}collaborations/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Collaboration")]
        public BoxCollaboration GetCollaborationStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}collaborations/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollaboration>(response);
        }

        [AutoRegisterMethod("Get Pending Collaboration")]
        public BoxCollection<BoxCollaboration> GetPendingCollaborationStep([TokenPicker] string tokenId)
        {
            var url = $"{StringConstants.BaseUrl}collaborations/";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxCollaboration>>(response);
        }
    }
}