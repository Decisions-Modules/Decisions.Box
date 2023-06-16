using Decisions.OAuth;
using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Decisions.Box;

[AutoRegisterMethodsOnClass(true, "Integration/Box")]
public static class BoxSteps
{
    public static FolderItemResult GetFolderItems([TokenPicker] string tokenId, string folderId, int limit, int offset)
    {
        if (string.IsNullOrEmpty(folderId))
        {
            folderId = "0";
        }

        string url = string.Format("https://api.box.com/2.0/folders/{0}/items", folderId);

        DynamicORM orm = new DynamicORM();
        OAuthToken token = (OAuthToken)orm.Fetch(typeof(OAuthToken), tokenId);

        if (token == null)
            throw new Exception($"OAuth token '{tokenId}' is missing");

        var req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        req.Headers.Add("Authorization: Bearer " + token.TokenData);

        req.Method = "GET";

        // Do the post and get the response.
        WebResponse resp;

        try
        {
            resp = req.GetResponse();
        }
        catch (WebException ex)
        {
            resp = ex.Response;

            var sr = new System.IO.StreamReader(resp.GetResponseStream());

            string errorMessage = sr.ReadToEnd();

            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = ex.Message;
            }

            return new FolderItemResult() { error_message = errorMessage };
        }

        if (resp == null) return null;
        var nonErrorSR = new System.IO.StreamReader(resp.GetResponseStream());

        string success = nonErrorSR.ReadToEnd();

        FolderItemResult result = JsonConvert.DeserializeObject<FolderItemResult>(success);
        return result;
    }

    public static string UploadDocument([TokenPicker] string tokenId, string folderId, string documentName,
        byte[] fileContents)
    {
        /*
        DynamicORM orm = new DynamicORM();
        OAuthToken token = (OAuthToken)orm.Fetch(typeof(OAuthToken), tokenId);

        if (token == null)
            throw new Exception($"OAuth token '{tokenId}' is missing");

        BoxFile bf = new BoxFile();
        bf.name = documentName;
        bf.parent = new FileParent();

        if (string.IsNullOrEmpty(folderId)) {
            folderId = "0";
        }

        bf.parent.id = folderId;

        string boundary = "----" + DateTime.Now.Ticks.ToString("x");

        var uri = "https://upload.box.com/api/2.0/files/content";
        var req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
        req.Headers.Add("Authorization: Bearer " + token.TokenData);
        req.ContentType = "multipart/form-data; boundary=" + boundary;
        req.Method = "POST";
        var os = req.GetRequestStream();

        // Add header for JSON part
        string body = "";
        body += "\r\n--" + boundary + "\r\n"; ;
        body += "Content-Disposition: form-data; name=\"attributes\"\r\n\r\n";
        //    body += "Content-Type: application/json\r\n\r\n";

        // Add document object data in JSON
        body += JsonConvert.SerializeObject(bf);

        // Add header for binary part 
        body += "\r\n--" + boundary + "\r\n"; ;
        body += string.Format("Content-Disposition: form-data; name=\"file\"; filename=\"{0}\" \r\n", documentName);
        body += "Content-Type: binary/octet-stream\r\n\r\n";

        // Add header data to request
        byte[] data = System.Text.Encoding.ASCII.GetBytes(body);
        os.Write(data, 0, data.Length);

        // Add file to reqeust
        os.Write(fileContents, 0, fileContents.Length);
      
        // Add trailer
        byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
        os.Write(trailer, 0, trailer.Length);
        os.Close();


        // Do the post and get the response.
        WebResponse resp;

        try
        {
            resp = req.GetResponse();
        }
        catch (WebException ex)
        {
            resp = ex.Response;

            var sr = new System.IO.StreamReader(resp.GetResponseStream());

            string errorMessage = sr.ReadToEnd();

            if (string.IsNullOrEmpty(errorMessage)) {
                errorMessage = ex.Message;
            }
            return errorMessage;
        }

        if (resp == null) return "No Response";
        var nonErrorSR = new System.IO.StreamReader(resp.GetResponseStream());

        string success = nonErrorSR.ReadToEnd();
        return success;
        */
        return "";
    }

    public static FolderItem CreateFolder([TokenPicker] string tokenId, string name, string parentFolderId)
    {
        if (string.IsNullOrEmpty(parentFolderId))
        {
            parentFolderId = "0";
        }

        string url = "https://api.box.com/2.0/folders";

        DynamicORM orm = new DynamicORM();
        OAuthToken token = (OAuthToken)orm.Fetch(typeof(OAuthToken), tokenId);

        if (token == null)
            throw new Exception($"OAuth token '{tokenId}' is missing");

        var req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        req.Headers.Add("Authorization: Bearer " + token.TokenData);
        req.ContentType = "application/json";
        req.Method = "POST";

        string
            json = ""; //JsonConvert.SerializeObject(new BoxFile { name = name, parent = new FileParent { id = parentFolderId } });

        using (Stream reqStream = req.GetRequestStream())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            reqStream.Write(bytes, 0, bytes.Length);
        }

        WebResponse resp = req.GetResponse();

        using (StreamReader resReader = new StreamReader(resp.GetResponseStream()))
        {
            string resJson = resReader.ReadToEnd();
            FolderItem result = JsonConvert.DeserializeObject<FolderItem>(resJson);
            return result;
        }
    }
}