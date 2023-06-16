using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Recent Items")]
    public class BoxRecentItemsSteps
    {
        [AutoRegisterMethod("Get Recent Items")]
        public BoxCollectionMarkerBasedV2<BoxRecentItem> GetRecentItemsStep([TokenPicker] string tokenId, int limit = 100, string marker = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}recent_items/";
            url += $"?limit={limit.ToString()}";
            url += $"&marker={marker}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollectionMarkerBasedV2<BoxRecentItem>>(response);
        }
    }
}