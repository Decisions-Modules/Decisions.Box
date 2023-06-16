using System.Collections.Generic;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Comments")]
    public class BoxCommentsSteps
    {
        [AutoRegisterMethod("Add Comment")]
        public BoxComment AddCommentStep([TokenPicker] string tokenId, BoxCommentRequest commentRequest, IEnumerable<string> fields = null)
        {
            var url = $"{StringConstants.BaseUrl}comments/";
            var requestBody = JsonConvert.SerializeObject(commentRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxComment>(response);
        }

        [AutoRegisterMethod("Get Comment Information")]
        public BoxComment GetInformationStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}comments/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxComment>(response);
        }

        [AutoRegisterMethod("Update Comment")]
        public BoxComment UpdateStep([TokenPicker] string tokenId, string id, BoxCommentRequest commentsRequest)
        {
            var url = $"{StringConstants.BaseUrl}comments/{id}";
            var requestBody = JsonConvert.SerializeObject(commentsRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxComment>(response);
        }

        [AutoRegisterMethod("Delete Comment")]
        public bool DeleteStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}comments/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }
    }
}