using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Device Pins")]
    public class BoxDevicePinSteps
    {
        [AutoRegisterMethod("Get Device Pin")]
        public BoxDevicePin GetDevicePin([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}device_pinners/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxDevicePin>(response);
        }

        [AutoRegisterMethod("Delete Device Pin")]
        public bool DeleteDevicePin([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}device_pinners/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }
    }
}