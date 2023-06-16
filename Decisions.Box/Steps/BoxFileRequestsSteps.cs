using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/File Requests")]
    public class BoxFileRequestsSteps
    {
        [AutoRegisterMethod("Get File Request")]
        public BoxFileRequestObject GetFileRequestByIdStep([TokenPicker] string tokenId, string fileRequestId)
        {
            var url = $"{StringConstants.BaseUrl}file_requests/{fileRequestId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFileRequestObject>(response);
        }

        [AutoRegisterMethod("Copy File Request")]
        public BoxFileRequestObject CopyFileRequestStep([TokenPicker] string tokenId, string fileRequestId, BoxFileRequestCopyRequest copyRequest)
        {
            var url = $"{StringConstants.BaseUrl}file_requests/{fileRequestId}/copy";
            var requestBody = JsonConvert.SerializeObject(copyRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFileRequestObject>(response);
        }

        [AutoRegisterMethod("Update File Request")]
        public BoxFileRequestObject UpdateFileRequestStep([TokenPicker] string tokenId, string fileRequestId, BoxFileRequestUpdateRequest updateRequest)
        {
            var url = $"{StringConstants.BaseUrl}file_requests/{fileRequestId}";
            var requestBody = JsonConvert.SerializeObject(updateRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFileRequestObject>(response);
        }

        [AutoRegisterMethod("Delete File Request")]
        public bool DeleteFileRequestStep([TokenPicker] string tokenId, string fileRequestId)
        {
            var url = $"{StringConstants.BaseUrl}file_requests/{fileRequestId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }
    }
}