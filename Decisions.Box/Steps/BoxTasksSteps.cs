using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/EMPTY")]
    public class BoxTasksSteps
    {
        [AutoRegisterMethod("Create Task Assignment")]
        public BoxTaskAssignment CreateTaskAssignmentStep([TokenPicker] string tokenId, BoxTaskAssignmentRequest taskAssignmentRequest)
        {
            var url = $"{StringConstants.BaseUrl}task_assignments/";
            var requestBody = JsonConvert.SerializeObject(taskAssignmentRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxTaskAssignment>(response);
        }

        [AutoRegisterMethod("Update Task Assignment")]
        public BoxTaskAssignment UpdateTaskAssignmentStep([TokenPicker] string tokenId,
            BoxTaskAssignmentUpdateRequest taskAssignmentUpdateRequest)
        {
            var url = $"{StringConstants.BaseUrl}task_assignments/{taskAssignmentUpdateRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(taskAssignmentUpdateRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxTaskAssignment>(response);
        }

        [AutoRegisterMethod("Get Task Assignment")]
        public BoxTaskAssignment GetTaskAssignmentStep([TokenPicker] string tokenId, string taskAssignmentId)
        {
            var url = $"{StringConstants.BaseUrl}task_assignments/{taskAssignmentId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxTaskAssignment>(response);
        }

        [AutoRegisterMethod("Delete Task Assignment")]
        public bool DeleteTaskAssignmentStep([TokenPicker] string tokenId, string taskAssignmentId)
        {
            var url = $"{StringConstants.BaseUrl}task_assignments/{taskAssignmentId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Create Task")]
        public BoxTask CreateTaskStep([TokenPicker] string tokenId, BoxTaskCreateRequest taskCreateRequest)
        {
            var url = $"{StringConstants.BaseUrl}tasks/";
            var requestBody = JsonConvert.SerializeObject(taskCreateRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxTask>(response);
        }

        [AutoRegisterMethod("Update Task")]
        public BoxTask UpdateTaskStep([TokenPicker] string tokenId, BoxTaskUpdateRequest taskUpdateRequest)
        {
            var url = $"{StringConstants.BaseUrl}tasks/{taskUpdateRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(taskUpdateRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxTask>(response);
        }

        [AutoRegisterMethod("Delete Task")]
        public bool DeleteTaskStep([TokenPicker] string tokenId, string taskId)
        {
            var url = $"{StringConstants.BaseUrl}tasks/{taskId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Task")]
        public BoxTask GetTaskStep([TokenPicker] string tokenId, string taskId)
        {
            var url = $"{StringConstants.BaseUrl}tasks/{taskId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxTask>(response);
        }

        [AutoRegisterMethod("Get Assignments")]
        public BoxCollection<BoxTaskAssignment> GetAssignmentsStep([TokenPicker] string tokenId, string taskId)
        {
            var url = $"{StringConstants.BaseUrl}tasks/{taskId}/assignments";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxTaskAssignment>>(response);
        }
    }
}