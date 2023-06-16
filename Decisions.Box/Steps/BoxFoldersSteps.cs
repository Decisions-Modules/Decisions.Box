using System;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Folders")]
    public class BoxFoldersSteps
    {
        [AutoRegisterMethod("Get Folder Items")]
        public BoxCollection<BoxItem> GetFolderItemsStep([TokenPicker] string tokenId, string id, int limit, int offset = 0, bool autoPaginate = false, string sort = null, BoxSortDirection? direction = null, string sharedLink = null, string sharedLinkPassword = null)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/items";
            url += $"?limit={limit.ToString()}";
            url += $"&offset={offset.ToString()}";
            url += $"&sort={sort}";
            url += $"&direction={direction.ToString()}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxItem>>(response);
        }

        [AutoRegisterMethod("Create Folder")]
        public BoxFolder CreateFolderStep([TokenPicker] string tokenId, BoxFolderRequest folderRequest)
        {
            var url = $"{StringConstants.BaseUrl}folders/";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Get Folder Information")]
        public BoxFolder GetInformationStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Copy Folder")]
        public BoxFolder CopyStep([TokenPicker] string tokenId, BoxFolderRequest folderRequest)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderRequest.Id}/copy";
            var requestBody = JsonConvert.SerializeObject(folderRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Delete Folder")]
        public bool DeleteStep([TokenPicker] string tokenId, string id, bool recursive = false, string etag = null)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Update Folder Information")]
        public BoxFolder UpdateInformationStep([TokenPicker] string tokenId, BoxFolderRequest folderRequest, string etag = null, TimeSpan? timeout = null)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(folderRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Create Shared Link")]
        public BoxFolder CreateSharedLinkStep([TokenPicker] string tokenId, string id, BoxSharedLinkRequest sharedLinkRequest)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Delete Shared Link")]
        public BoxFolder DeleteSharedLinkStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }


        [AutoRegisterMethod("Get Collaborations")]
        public BoxCollection<BoxCollaboration> GetCollaborationsStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/collaborations";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxCollaboration>>(response);
        }

        [AutoRegisterMethod("Get Trash Items")]
        public BoxCollection<BoxItem> GetTrashItemsStep([TokenPicker] string tokenId, int limit, int offset = 0, bool autoPaginate = false, string sort = null, BoxSortDirection? direction = null)
        {
            var url = $"{StringConstants.BaseUrl}folders/trash/items";
            url += $"?limit={limit.ToString()}";
            url += $"?offset={offset.ToString()}";
            url += $"?sort={sort}";
            url += $"?direction={direction.ToString()}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxItem>>(response);
        }

        [AutoRegisterMethod("Restore Trashed Folder")]
        public BoxFolder RestoreTrashedFolderStep([TokenPicker] string tokenId, BoxFolderRequest folderRequest)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(folderRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Purge Trashed Folder")]
        public bool PurgeTrashedFolderStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/trash";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Trashed Folder")]
        public BoxFolder GetTrashedFolderStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/trash";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Get Watermark")]
        public BoxWatermark GetWatermarkStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/watermark";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWatermark>(response);
        }

        [AutoRegisterMethod("Apply Watermark")]
        public BoxWatermark ApplyWatermarkStep([TokenPicker] string tokenId, string id, BoxApplyWatermarkRequest applyWatermarkRequest = null)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/watermark";
            var requestBody = JsonConvert.SerializeObject(applyWatermarkRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWatermark>(response);
        }

        [AutoRegisterMethod("Remove Watermark")]
        public bool RemoveWatermarkStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folders/{id}/watermark";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Create Folder Lock")]
        public BoxFolderLock CreateLockStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folder_locks/";

            var bodyObject = new JObject();
            var folderObject = new JObject();
            var lockOperationsObject = new JObject();

            folderObject.Add("id", id);
            folderObject.Add("type", "folder");

            lockOperationsObject.Add("move", true);
            lockOperationsObject.Add("delete", true);

            bodyObject.Add("folder", folderObject);
            bodyObject.Add("locked_operations", lockOperationsObject);

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, bodyObject.ToString()).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolderLock>(response);
        }

        [AutoRegisterMethod("Get Folder Lock")]
        public BoxCollection<BoxFolderLock> GetLocksStep([TokenPicker] string tokenId, string id,
            bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}folder_locks/";
            url += $"?folder_id={id}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxFolderLock>>(response);
        }

        [AutoRegisterMethod("Delete Folder Lock")]
        public bool DeleteLockStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}folder_locks/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }
    }
}