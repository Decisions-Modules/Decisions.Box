using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Sign Request")]
    public class BoxSignRequestsSteps
    {
        [AutoRegisterMethod("Get Sign Request")]
        public BoxSignRequest GetSignRequestByIdStep([TokenPicker] string tokenId, string signRequestId)
        {
            var url = $"{StringConstants.BaseUrl}sign_requests/{signRequestId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxSignRequest>(response);
        }

        [AutoRegisterMethod("Get Sign Requests")]
        public BoxCollectionMarkerBased<BoxSignRequest> GetSignRequestsStep([TokenPicker] string tokenId, int limit = 100, string nextMarker = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}sign_requests/";
            url += $"?limit={limit.ToString()}";
            url += $"&marker={nextMarker}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollectionMarkerBased<BoxSignRequest>>(response);
        }

        [AutoRegisterMethod("Create Sign Request")]
        public BoxSignRequest CreateSignRequestStep([TokenPicker] string tokenId, BoxSignRequestCreateRequest signRequestCreateRequest)
        {
            var url = $"{StringConstants.BaseUrl}sign_requests/";
            var requestBody = JsonConvert.SerializeObject(signRequestCreateRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxSignRequest>(response);
        }

        [AutoRegisterMethod("Cancel Sign Request")]
        public BoxSignRequest CancelSignRequestStep([TokenPicker] string tokenId, string signRequestId)
        {
            var url = $"{StringConstants.BaseUrl}sign_requests/{signRequestId}/cancel";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxSignRequest>(response);
        }

        [AutoRegisterMethod("Resend Sign Request")]
        public bool ResendSignRequestStep([TokenPicker] string tokenId, string signRequestId)
        {
            var url = $"{StringConstants.BaseUrl}sign_requests/{signRequestId}/resend";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return response != null;
        }
    }
}