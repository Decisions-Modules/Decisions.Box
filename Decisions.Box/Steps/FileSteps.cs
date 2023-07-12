using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Models;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Box.Steps;

[AutoRegisterMethodsOnClass(true, "Integration/Box/Files")]
public class FileSteps
{
    public void UploadFile(FileData fileData, string parentFolderId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();
        
        Stream file = new MemoryStream(fileData.Contents);
        var fileRequest = new BoxFileRequest
        {
            Name = fileData.FileName,
            Parent = new BoxFolderRequest { Id = parentFolderId }
        };

        Task t = Task.Run(async () => { await client.FilesManager.UploadAsync(fileRequest, file); });
        t.Wait();
    }

    public FileData DownloadFile(string fileId, string fileName)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();

        Task<Byte[]> t = Task.Run(async () =>
        {
            Stream fileStream = await client.FilesManager.DownloadAsync(fileId);

            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        });
        t.Wait();

        return new FileData(fileName, t.Result);
    }

    public FolderItem[] GetFileList(string folderId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();

        Task<FolderItem[]> t = Task.Run(async () =>
        {
            BoxCollection<BoxItem> items = await client.FoldersManager.GetFolderItemsAsync(folderId, 500, 0);
            
            var entries = new List<FolderItem>();
            foreach (var item in items.Entries)
            {
                if (item.Type == "file")
                {
                    entries.Add(new FolderItem()
                    {
                        name = item.Name,
                        etag = item.ETag,
                        id = item.Id,
                        sequence_id = item.SequenceId,
                        type = item.Type,
                    });
                }
            }

            return entries.ToArray();
        });
        t.Wait();

        return t.Result;
    }
}