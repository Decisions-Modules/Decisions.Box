using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Webhooks")]
    public class BoxWebhooksSteps
    {
        [AutoRegisterMethod("Create Webhook")]
        public BoxWebhook CreateWebhookStep([TokenPicker] string tokenId, BoxWebhookRequest webhookRequest)
        {
            var url = $"{StringConstants.BaseUrl}webhooks/";
            var requestBody = JsonConvert.SerializeObject(webhookRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebhook>(response);
        }

        [AutoRegisterMethod("Get Webhook")]
        public BoxWebhook GetWebhookStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}webhooks/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebhook>(response);
        }

        [AutoRegisterMethod("Update Webhook")]
        public BoxWebhook UpdateWebhookStep([TokenPicker] string tokenId, BoxWebhookRequest webhookRequest)
        {
            var url = $"{StringConstants.BaseUrl}webhooks/{webhookRequest.Id}";
            var requestBody = JsonConvert.SerializeObject(webhookRequest);
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.PUT, url, requestBody).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxWebhook>(response);
        }

        [AutoRegisterMethod("Delete Webhook")]
        public bool DeleteWebhookStep([TokenPicker] string tokenId, string id)
        {
            var url = $"{StringConstants.BaseUrl}webhooks/{id}";
            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.DELETE, url).GetAwaiter().GetResult();
            return response != null;
        }

        [AutoRegisterMethod("Get Webhooks")]
        public BoxCollectionMarkerBased<BoxWebhook> GetWebhooksStep([TokenPicker] string tokenId, int limit = 100,
            string nextMarker = null, bool autoPaginate = false)
        {
            var url = $"{StringConstants.BaseUrl}webhooks/";
            url += $"?limit={limit.ToString()}";
            url += $"&marker={nextMarker}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollectionMarkerBased<BoxWebhook>>(response);
        }

        [AutoRegisterMethod("Verify Webhook")]
        public static bool VerifyWebhook([TokenPicker] string tokenId, string deliveryTimestamp, string signaturePrimary, string signatureSecondary, string payload, string primaryWebhookKey, string secondaryWebhookKey)
        {
            var primaryKeyBytes = Encoding.UTF8.GetBytes(primaryWebhookKey);
            var secondaryKeyBytes = Encoding.UTF8.GetBytes(secondaryWebhookKey);
            var bodyBytes = Encoding.UTF8.GetBytes(payload);
            var allBytes = bodyBytes.Concat(Encoding.UTF8.GetBytes(deliveryTimestamp)).ToArray();
            using (var hmacsha256Primary = new HMACSHA256(primaryKeyBytes))
            using (var hmacsha256Secondary = new HMACSHA256(secondaryKeyBytes))
            {
                var hashBytes = hmacsha256Primary.ComputeHash(allBytes);
                var hashPrimary = Convert.ToBase64String(hashBytes);

                hashBytes = hmacsha256Secondary.ComputeHash(allBytes);
                var hashSecondary = Convert.ToBase64String(hashBytes);

                if (hashPrimary != signaturePrimary && hashSecondary != signatureSecondary)
                {
                    return false;
                }
            }

            return true;
        }
    }
}