using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Collections")]
    public class BoxCollectionsSteps
    {
        [AutoRegisterMethod("Create or Delete Collections for Folder")]
        public BoxFolder CreateOrDeleteCollectionsForFolderStep([TokenPicker] string tokenId, string folderId, BoxCollectionsRequest collectionsRequest)
        {
            var url = $"{StringConstants.BaseUrl}folders/{folderId}";
            var requestBody = JsonConvert.SerializeObject(collectionsRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFolder>(response);
        }

        [AutoRegisterMethod("Create or Delete Collections for File")]
        public BoxFile CreateOrDeleteCollectionsForFileStep([TokenPicker] string tokenId, string fileId, BoxCollectionsRequest collectionsRequest)
        {
            var url = $"{StringConstants.BaseUrl}files/{fileId}";
            var requestBody = JsonConvert.SerializeObject(collectionsRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxFile>(response);
        }

        [AutoRegisterMethod("Get Collections")]
        public BoxCollection<BoxCollectionItem> GetCollectionsStep([TokenPicker] string tokenId)
        {
            var url = $"{StringConstants.BaseUrl}collections/";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxCollectionItem>>(response);
        }

        [AutoRegisterMethod("Get Collection Items")]
        public BoxCollection<BoxItem> GetCollectionItemsStep([TokenPicker] string tokenId, string collectionId, int limit = 100, int offset = 0)
        {
            var url = $"{StringConstants.BaseUrl}collections/{collectionId}/items";
            url += $"?limit={limit.ToString()}";
            url += $"&offset={offset.ToString()}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxItem>>(response);
        }
    }
}