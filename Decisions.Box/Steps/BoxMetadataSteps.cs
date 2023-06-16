using System.Collections.Generic;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Metadata")]
    public class BoxMetadataSteps
    {
        [AutoRegisterMethod("Get File Metadata")]
        public Dictionary<string, object> GetFileMetadataStep([TokenPicker] string tokenId, string fileId, string scope,
            string template)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileId}/metadata/{scope}/{template}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        [AutoRegisterMethod("Get Folder Metadata")]
        public Dictionary<string, object> GetFolderMetadataStep([TokenPicker] string tokenId, string folderId,
            string scope, string template)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderId}/metadata/{scope}/{template}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        [AutoRegisterMethod("Create File Metadata")]
        public Dictionary<string, object> CreateFileMetadataStep([TokenPicker] string tokenId, string fileId,
            Dictionary<string, object> metadata,
            string scope, string template)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileId}/metadata/{scope}/{template}";
            var requestBody = JsonConvert.SerializeObject(metadata);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        [AutoRegisterMethod("Create Folder Metadata")]
        public Dictionary<string, object> CreateFolderMetadataStep([TokenPicker] string tokenId, string folderId,
            Dictionary<string, object> metadata,
            string scope, string template)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderId}/metadata/{scope}/{template}";
            var requestBody = JsonConvert.SerializeObject(metadata);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        [AutoRegisterMethod("Update File Metadata")]
        public Dictionary<string, object> UpdateFileMetadataStep([TokenPicker] string tokenId, string fileId,
            List<BoxMetadataUpdate> updates, string scope, string template)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileId}/metadata/{scope}/{template}";
            var requestBody = JsonConvert.SerializeObject(updates);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        [AutoRegisterMethod("Update Folder Metadata")]
        public Dictionary<string, object> UpdateFolderMetadataStep([TokenPicker] string tokenId, string folderId,
            List<BoxMetadataUpdate> updates, string scope, string template)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderId}/metadata/{scope}/{template}";
            var requestBody = JsonConvert.SerializeObject(updates);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        [AutoRegisterMethod("Delete File Metadata")]
        public bool DeleteFileMetadataStep([TokenPicker] string tokenId, string fileId, string scope, string template)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileId}/metadata/{scope}/{template}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Delete Folder Metadata")]
        public bool DeleteFolderMetadataStep([TokenPicker] string tokenId, string folderId, string scope,
            string template)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderId}/metadata/{scope}/{template}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Metadata Template")]
        public BoxMetadataTemplate GetMetadataTemplate([TokenPicker] string tokenId, string scope, string template)
        {
            var url = "";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxMetadataTemplate>(response);
        }

        [AutoRegisterMethod("Create Metadata Template")]
        public BoxMetadataTemplate CreateMetadataTemplate([TokenPicker] string tokenId, BoxMetadataTemplate template)
        {
            var url = "";
            var requestBody = JsonConvert.SerializeObject(template);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxMetadataTemplate>(response);
        }

        [AutoRegisterMethod("Delete Metadata Template")]
        public bool DeleteMetadataTemplate([TokenPicker] string tokenId, string scope, string template)
        {
            var url = "";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Update Metadata Template")]
        public BoxMetadataTemplate UpdateMetadataTemplate([TokenPicker] string tokenId,
            IEnumerable<BoxMetadataTemplateUpdate> metadataTemplateUpdate, string scope, string template)
        {
            var url = "";
            var requestBody = JsonConvert.SerializeObject(metadataTemplateUpdate);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxMetadataTemplate>(response);
        }

        [AutoRegisterMethod("Get Metadata Template")]
        public BoxMetadataTemplate GetMetadataTemplateById([TokenPicker] string tokenId, string templateId)
        {
            var url = "";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxMetadataTemplate>(response);
        }

        [AutoRegisterMethod("Get All File Metadata Templates")]
        public BoxMetadataTemplateCollection<Dictionary<string, object>> GetAllFileMetadataTemplatesStep(
            [TokenPicker] string tokenId, string fileId)
        {
            var url = "";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxMetadataTemplateCollection<Dictionary<string, object>>>(response);
        }

        [AutoRegisterMethod("Get All Folder Metadata Templates")]
        public BoxMetadataTemplateCollection<Dictionary<string, object>> GetAllFolderMetadataTemplatesStep(
            [TokenPicker] string tokenId,
            string folderId)
        {
            var url = "";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxMetadataTemplateCollection<Dictionary<string, object>>>(response);
        }

        [AutoRegisterMethod("Get Enterprise Metadata")]
        public BoxEnterpriseMetadataTemplateCollection<BoxMetadataTemplate> GetEnterpriseMetadataStep([TokenPicker] string tokenId, string scope = "enterprise")
        {
            var url = "";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxEnterpriseMetadataTemplateCollection<BoxMetadataTemplate>>(response);
        }

        [AutoRegisterMethod("Execute Metadata Query")]
        public BoxCollectionMarkerBased<BoxItem> ExecuteMetadataQueryStep([TokenPicker] string tokenId, BoxMetadataQueryRequest queryRequest)
        {
            var url = "";
            var requestBody = JsonConvert.SerializeObject(queryRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollectionMarkerBased<BoxItem>>(response);
        }
    }
}