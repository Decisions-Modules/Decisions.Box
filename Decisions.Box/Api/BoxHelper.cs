using System;
using System.Net.Http;
using System.Threading.Tasks;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using Decisions.OAuth;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Api;

public static class BoxHelper
{
    public static async Task<string> GetResponse([TokenPicker] string tokenId, HttpRequestMethods method, string url,
        string requestBody = null)
    {
        DynamicORM orm = new DynamicORM();
        OAuthToken token = (OAuthToken)orm.Fetch(typeof(OAuthToken), tokenId);

        if (token == null)
            throw new Exception($"OAuth token '{tokenId}' is missing");


        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.TokenData}");
            
            string response;
            HttpResponseMessage result = null;
            switch (method)
            {
                case HttpRequestMethods.GET:
                    result = await client.GetAsync(url);
                    break;
                case HttpRequestMethods.PUT:
                    result = await client.PutAsync(url, new StringContent(requestBody ?? ""));
                    break;
                case HttpRequestMethods.POST:
                    result = await client.PostAsync(url, new StringContent(requestBody ?? ""));
                    break;
                case HttpRequestMethods.DELETE:
                    result = await client.DeleteAsync(url);
                    break;
            }

            if (result is { IsSuccessStatusCode: false })
                return null;

            return await result.Content.ReadAsStringAsync();
        }

        return string.Empty;
    }

    public static async Task<BoxFile> UploadFile(string tokenId, string uploadUri, FileData fileData, BoxFileRequest fileRequest, string fileToVersion = "")
    {
        var url = StringConstants.BaseUrl;
        if (string.IsNullOrEmpty(uploadUri))
        {
            // Default path
            if (!string.IsNullOrEmpty(fileToVersion))
            {
                // Adds a new file version to specified file id
                url += $"files/{fileToVersion}/content";
            }
            else
            {
                url += uploadUri ?? "files/content";
            }
        }
        
            
        DynamicORM orm = new DynamicORM();
        OAuthToken token = (OAuthToken)orm.Fetch(typeof(OAuthToken), tokenId);

        using var httpClient = new HttpClient();
        using var request = new HttpRequestMessage(new HttpMethod("POST"), url);
        request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token.TokenData}"); 

        var multipartContent = new MultipartFormDataContent();
        multipartContent.Add(new StringContent("{\"name\":\"" + fileData.FileName + "\", \"parent\":{\"id\":\"" + fileRequest.Parent.Id + "\"}}"), "attributes");
        multipartContent.Add(new ByteArrayContent(fileData.Contents), "file", fileData.FileName);
        request.Content = multipartContent;

        var response = await httpClient.SendAsync(request);

        if (response is { IsSuccessStatusCode: false })
            return null;

        return JsonConvert.DeserializeObject<BoxFile>(await response.Content.ReadAsStringAsync());
    }
    
    public enum HttpRequestMethods
    {
        GET,
        POST,
        DELETE,
        PUT,
    }
}