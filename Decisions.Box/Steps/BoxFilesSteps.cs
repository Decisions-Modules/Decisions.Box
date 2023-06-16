using System;
using System.IO;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Files")]
    public class BoxFilesSteps
    {
        [AutoRegisterMethod("Get File Information")]
        public BoxFile GetInformationStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Download File")]
        public Stream DownloadStep([TokenPicker] string tokenId, string id, string versionId = null, TimeSpan? timeout = null, long? startOffsetInBytes = null, long? endOffsetInBytes = null)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/content";
            url += $"?version={versionId}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Stream>(response);
        }

        [AutoRegisterMethod("Get Download Uri")]
        public Uri GetDownloadUriStep([TokenPicker] string tokenId, string id, string versionId = null)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/content";
            url += $"?version={versionId}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<Uri>(response);
        }

        [AutoRegisterMethod("Upload File")]
        public BoxFile UploadStep([TokenPicker] string tokenId, BoxFileRequest fileRequest, FileData fileData, TimeSpan? timeout = null, byte[] contentMD5 = null, bool setStreamPositionToZero = true, string uploadUri = null)
        {
            return BoxHelper.UploadFile(tokenId, uploadUri, fileData, fileRequest).GetAwaiter().GetResult();
        }

        [AutoRegisterMethod("Upload New Version")]
        public BoxFile UploadNewVersionStep([TokenPicker] string tokenId, string fileId, BoxFileRequest fileRequest, FileData fileData, string etag = null, TimeSpan? timeout = null, byte[] contentMD5 = null, bool setStreamPositionToZero = true, Uri uploadUri = null, DateTimeOffset? contentModifiedTime = null)
        {
            return BoxHelper.UploadFile(tokenId, null, fileData, fileRequest, fileId).GetAwaiter().GetResult();
        }

        [AutoRegisterMethod("View File Versions")]
        public BoxCollection<BoxFileVersion> ViewVersionsStep([TokenPicker] string tokenId, string id, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/versions";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxFileVersion>>(response);
        }

        [AutoRegisterMethod("Update File Information")]
        public BoxFile UpdateInformationStep([TokenPicker] string tokenId, BoxFileRequest fileRequest, string etag = null)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(fileRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Delete File")]
        public bool DeleteStep([TokenPicker] string tokenId, string id, string etag = null)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Copy File")]
        public BoxFile CopyStep([TokenPicker] string tokenId, BoxFileRequest fileRequest)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileRequest.Id}/copy";
            var requestBody = JsonConvert.SerializeObject(fileRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Create Shared Link")]
        public BoxFile CreateSharedLinkStep([TokenPicker] string tokenId, string id, BoxSharedLinkRequest sharedLinkRequest)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            var requestBody = JsonConvert.SerializeObject(new BoxItemRequest() { SharedLink = sharedLinkRequest });
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Delete Shared Link")]
        public BoxFile DeleteSharedLinkStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            var jsonStr = JsonConvert.SerializeObject(new BoxDeleteSharedLinkRequest());
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, jsonStr).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Get Collaborations Collection")]
        public BoxCollectionMarkerBasedV2<BoxCollaboration> GetCollaborationsCollectionStep([TokenPicker] string tokenId, string id, string marker = null, int? limit = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/collaborations";
            url += $"?limit={limit?.ToString() ?? ""}";
            url += $"&marker={marker}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollectionMarkerBasedV2<BoxCollaboration>>(response);
        }

        [AutoRegisterMethod("Get Comments")]
        public BoxCollection<BoxComment> GetCommentsStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/comments";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxComment>>(response);
        }

        [AutoRegisterMethod("Get Trashed")]
        public BoxFile GetTrashedStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/trash";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Restore Trashed")]
        public BoxFile RestoreTrashedStep([TokenPicker] string tokenId, BoxFileRequest fileRequest)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(fileRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Purge Trashed")]
        public bool PurgeTrashedStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/trash";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Lock")]
        public BoxFileLock GetLockStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            url += "?fields=lock";
            
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFileLock>(response);
        }

        [AutoRegisterMethod("Update Lock")]
        public BoxFileLock UpdateLockStep([TokenPicker] string tokenId, BoxFileLockRequest lockFileRequest, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            url += "?fields=lock";
            
            var requestBody = JsonConvert.SerializeObject(lockFileRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFileLock>(response);
        }

        [AutoRegisterMethod("Lock")]
        public BoxFileLock LockStep([TokenPicker] string tokenId, BoxFileLockRequest lockFileRequest, string id)
        {
            return UpdateLockStep(tokenId, lockFileRequest, id);
        }

        [AutoRegisterMethod("Unlock")]
        public bool UnLock([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}";
            url += "?fields=lock";
            
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, "{\"lock\":null}").GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get File Tasks")]
        public BoxCollection<BoxTask> GetFileTasks([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/tasks";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxTask>>(response);
        }

        [AutoRegisterMethod("Get Watermark")]
        public BoxWatermark GetWatermarkStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/watermark";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWatermark>(response);
        }

        [AutoRegisterMethod("Apply Watermark")]
        public BoxWatermark ApplyWatermarkStep([TokenPicker] string tokenId, string id, BoxApplyWatermarkRequest applyWatermarkRequest = null)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/watermark";
            var requestBody = JsonConvert.SerializeObject(applyWatermarkRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWatermark>(response);
        }

        [AutoRegisterMethod("Remove Watermark")]
        public bool RemoveWatermarkStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/watermark";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Delete Old Version")]
        public bool DeleteOldVersionStep([TokenPicker] string tokenId, string id, string versionId, string etag = null)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/versions/{versionId}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Promote Version")]
        public BoxFileVersion PromoteVersionStep([TokenPicker] string tokenId, string id, string versionId)
        {
            var url = $"{StringConstants.BaseUrl}files/{id}/versions/current";
            var jsonStr = JsonConvert.SerializeObject(new BoxPromoteVersionRequest()
            {
                Id = versionId
            });
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, jsonStr).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFileVersion>(response);
        }
    }
}