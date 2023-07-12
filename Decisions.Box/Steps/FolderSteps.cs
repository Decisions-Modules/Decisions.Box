using System.Collections.Generic;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Models;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;

namespace Decisions.Box.Steps;

[AutoRegisterMethodsOnClass(true, "Integration/Box/Folders")]
public class FolderSteps
{
    public void CreateFolder(string folderName, string parentFolderId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();
        
        BoxFolderRequest request = new BoxFolderRequest()
        {
            Name = folderName,
            Parent = new BoxRequestEntity() { Id = parentFolderId }
        };

        Task t = Task.Run(async () =>
        {
            BoxFolder folder = await client.FoldersManager.CreateAsync(request);
        });
        t.Wait();
    }

    public FolderItem[] GetFolderList(string folderId)
    {
        BoxClient client = ModuleSettingsAccessor<BoxSettings>.GetSettings().GetClient();

        Task<FolderItem[]> t = Task.Run(async () =>
        {
            BoxCollection<BoxItem> items = await client.FoldersManager.GetFolderItemsAsync(folderId, 500, 0);
            
            var entries = new List<FolderItem>();
            foreach (var item in items.Entries)
            {
                if (item.Type == "folder")
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