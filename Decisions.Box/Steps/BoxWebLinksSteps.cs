using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Web Links")]
    public class BoxWebLinksSteps
    {
        [AutoRegisterMethod("Create Web Link")]
        public BoxWebLink CreateWebLinkStep([TokenPicker] string tokenId, BoxWebLinkRequest createWebLinkRequest)
        {
            var url = $"{StringConstants.BaseUrl}web_links/";
            var requestBody = JsonConvert.SerializeObject(createWebLinkRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebLink>(response);
        }

        [AutoRegisterMethod("Delete Web Link")]
        public bool DeleteWebLinkStep([TokenPicker] string tokenId, string webLinkId)
        {
            var url = $"{StringConstants.BaseUrl}web_links/{webLinkId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Web Link")]
        public BoxWebLink GetWebLinkStep([TokenPicker] string tokenId, string webLinkId)
        {
            var url = $"{StringConstants.BaseUrl}web_links/{webLinkId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebLink>(response);
        }

        [AutoRegisterMethod("Update Web Link")]
        public BoxWebLink UpdateWebLinkStep([TokenPicker] string tokenId, string webLinkId,
            BoxWebLinkRequest updateWebLinkRequest)
        {
            var url = $"{StringConstants.BaseUrl}web_links/{webLinkId}";
            var requestBody = JsonConvert.SerializeObject(updateWebLinkRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebLink>(response);
        }

        [AutoRegisterMethod("Copy Web Link")]
        public BoxWebLink CopyStep([TokenPicker] string tokenId, string webLinkId, string destinationFolderId)
        {
            var url = $"{StringConstants.BaseUrl}web_links/{webLinkId}/copy";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebLink>(response);
        }

        [AutoRegisterMethod("Create Shared Link")]
        public BoxWebLink CreateSharedLinkStep([TokenPicker] string tokenId, string id, BoxSharedLinkRequest sharedLinkRequest)
        {
            var url = $"{StringConstants.BaseUrl}web_links/{id}";
            var requestBody = JsonConvert.SerializeObject(sharedLinkRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebLink>(response);
        }

        [AutoRegisterMethod("Delete Shared Link")]
        public BoxWebLink DeleteSharedLinkStep([TokenPicker] string tokenId, string id)
        {
            var url = "";
            var jsonStr = JsonConvert.SerializeObject(new BoxDeleteSharedLinkRequest());
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebLink>(response);
        }
    }
}