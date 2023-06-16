using System.Collections.Generic;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Groups")]
    public class BoxGroupsSteps
    {
        [AutoRegisterMethod("Get All Groups")]
        public BoxCollection<BoxGroup> GetAllGroupsStep([TokenPicker] string tokenId, int? limit = null,
            int? offset = null, bool autoPaginate = false, string filterTerm = null)
        {
            var url = $"{StringConstants.BaseUrl}groups/";
            url += $"?limit={limit.ToString()}";
            url += $"&offset={offset.ToString()}";

            if (filterTerm != null)
                url += $"&filter_term={filterTerm}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxGroup>>(response);
        }

        [AutoRegisterMethod("Get Group")]
        public BoxGroup GetGroupStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}groups/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxGroup>(response);
        }

        [AutoRegisterMethod("Create Group")]
        public BoxGroup CreateStep([TokenPicker] string tokenId, BoxGroupRequest groupRequest)
        {
            var url = $"{StringConstants.BaseUrl}groups/";
            var requestBody = JsonConvert.SerializeObject(groupRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxGroup>(response);
        }

        [AutoRegisterMethod("Delete Group")]
        public bool DeleteStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}groups/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Update Group")]
        public BoxGroup UpdateStep([TokenPicker] string tokenId, string id, BoxGroupRequest groupRequest)
        {
            var url = $"{StringConstants.BaseUrl}groups/{id}";
            var requestBody = JsonConvert.SerializeObject(groupRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxGroup>(response);
        }

        [AutoRegisterMethod("Add Member to Group")]
        public BoxGroupMembership AddMemberToGroupStep([TokenPicker] string tokenId,
            BoxGroupMembershipRequest membershipRequest)
        {
            var url = $"{StringConstants.BaseUrl}group_memberships/";
            var requestBody = JsonConvert.SerializeObject(membershipRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxGroupMembership>(response);
        }

        [AutoRegisterMethod("Delete Group Membership")]
        public bool DeleteGroupMembershipStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}group_memberships/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Collaborations for Group")]
        public BoxCollection<BoxCollaboration> GetCollaborationsForGroupStep([TokenPicker] string tokenId,
            string groupId, int? limit = null, int? offset = null,
            IEnumerable<string> fields = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}groups/{groupId}/collaborations";
            url += $"?limit={limit.ToString()}";
            url += $"?offset={offset.ToString()}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxCollaboration>>(response);
        }

        [AutoRegisterMethod("Get All Group Memberships for Group")]
        public BoxCollection<BoxGroupMembership> GetAllGroupMembershipsForGroupStep([TokenPicker] string tokenId,
            string groupId, int? limit = null, int? offset = null,
            IEnumerable<string> fields = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}groups/{groupId}/memberships";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxGroupMembership>>(response);
        }

        [AutoRegisterMethod("Get All Group Memberships for User")]
        public BoxCollection<BoxGroupMembership> GetAllGroupMembershipsForUserStep([TokenPicker] string tokenId,
            string userId, int? limit = null, int? offset = null,
            IEnumerable<string> fields = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}users/{userId}/memberships";
            url += $"?limit={limit.ToString()}";
            url += $"?offset={offset.ToString()}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxGroupMembership>>(response);
        }

        [AutoRegisterMethod("Get Group Membership")]
        public BoxGroupMembership GetGroupMembershipStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}group_memberships/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxGroupMembership>(response);
        }

        [AutoRegisterMethod("Update Group Membership")]
        public BoxGroupMembership UpdateGroupMembershipStep([TokenPicker] string tokenId, string membershipId,
            BoxGroupMembershipRequest memRequest)
        {
            var url = $"{StringConstants.BaseUrl}group_memberships/{membershipId}";
            var requestBody = JsonConvert.SerializeObject(memRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxGroupMembership>(response);
        }
    }
}