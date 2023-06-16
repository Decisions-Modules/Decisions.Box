using System;
using System.Collections.Generic;
using System.IO;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Users")]
    public class BoxUsersSteps
    {
        [AutoRegisterMethod("Get User Information")]
        public BoxUser GetUserInformationStep([TokenPicker] string tokenId, string userId)
        {
            var url = $"{StringConstants.BaseUrl}users/{userId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxUser>(response);
        }

        [AutoRegisterMethod("Move User Folder")]
        public BoxFolder MoveUserFolderStep([TokenPicker] string tokenId, string userId, string ownedByUserId,
            string folderId = "0", bool notify = false, TimeSpan? timeout = null)
        {
            var bu = new BoxMoveUserFolderRequest() { OwnedBy = new BoxUserRequest() { Id = ownedByUserId } };
            var jsonStr = JsonConvert.SerializeObject(bu);

            var url = $"{StringConstants.BaseUrl}{userId}/folders/{folderId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, jsonStr).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }
    }
}