using System;
using System.Collections.Generic;
using Decisions.Box.Api;
using Decisions.Box.Api.Data;
using Decisions.Box.Api.Data.Request;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Properties.Attributes;
using Newtonsoft.Json;

namespace Decisions.Box.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/Box/Search")]
    public class BoxSearchSteps
    {
        [AutoRegisterMethod("Query")]
        public BoxCollection<BoxItem> QueryStep([TokenPicker] string tokenId, string query, string scope = null,
            IEnumerable<string> fileExtensions = null, DateTimeOffset? createdAfter = null,
            DateTimeOffset? createdBefore = null, DateTimeOffset? updatedAfter = null,
            DateTimeOffset? updatedBefore = null, long? sizeLowerBound = null,
            long? sizeUpperBound = null, IEnumerable<string> ownerUserIds = null,
            IEnumerable<string> ancestorFolderIds = null, IEnumerable<string> contentTypes = null,
            string type = null, string trashContent = null, List<BoxMetadataFilterRequest> mdFilters = null,
            int limit = 30, int offset = 0,
            IEnumerable<string> fields = null, string sort = null, BoxSortDirection? direction = null)

        {
            string mdFiltersString = null;
            if (mdFilters != null)
            {
                mdFiltersString = JsonConvert.SerializeObject(mdFilters);
            }

            var createdAtRangeString = BuildDateRangeField(createdAfter, createdBefore);
            var updatedAtRangeString = BuildDateRangeField(updatedAfter, updatedBefore);
            var sizeRangeString = BuildSizeRangeField(sizeLowerBound, sizeUpperBound);

            var url = $"{StringConstants.BaseUrl}search";
            url += $"?query={query}";
            url += $"&scope={scope}";
            url += $"&file_extensions={fileExtensions}";
            url += $"&created_at_range={createdAtRangeString}";
            url += $"&updated_at_range={updatedAtRangeString}";
            url += $"&size_range={sizeRangeString}";
            url += $"&owner_user_ids={ownerUserIds}";
            url += $"&ancestor_folder_ids={ancestorFolderIds}";
            url += $"&content_types={contentTypes}";
            url += $"&type={type}";
            url += $"&trash_content={trashContent}";
            url += $"&mdfilters={mdFiltersString}";
            url += $"&limit={limit.ToString()}";
            url += $"&offset={offset.ToString()}";
            url += $"&sort={sort}";
            url += $"&direction={direction.ToString()}";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.GET, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxItem>>(response);
        }


        [AutoRegisterMethod("Query With Shared Links")]
        public BoxCollection<BoxSearchResult> QueryAsyncWithSharedLinks([TokenPicker] string tokenId, string query,
            string scope = null, IEnumerable<string> fileExtensions = null,
            DateTimeOffset? createdAfter = null, DateTimeOffset? createdBefore = null,
            DateTimeOffset? updatedAfter = null, DateTimeOffset? updatedBefore = null,
            long? sizeLowerBound = null, long? sizeUpperBound = null, IEnumerable<string> ownerUserIds = null,
            IEnumerable<string> ancestorFolderIds = null,
            IEnumerable<string> contentTypes = null, string type = null, string trashContent = null,
            List<BoxMetadataFilterRequest> mdFilters = null,
            int limit = 30, int offset = 0, string sort = null, BoxSortDirection? direction = null)

        {
            string mdFiltersString = null;
            if (mdFilters != null)
            {
                mdFiltersString = JsonConvert.SerializeObject(mdFilters);
            }

            var createdAtRangeString = BuildDateRangeField(createdAfter, createdBefore);
            var updatedAtRangeString = BuildDateRangeField(updatedAfter, updatedBefore);
            var sizeRangeString = BuildSizeRangeField(sizeLowerBound, sizeUpperBound);

            var url = $"{StringConstants.BaseUrl}search";
            url += $"?query={query}";
            url += $"&scope={scope}";
            url += $"&file_extensions={fileExtensions}";
            url += $"&created_at_range={createdAtRangeString}";
            url += $"&updated_at_range={updatedAtRangeString}";
            url += $"&size_range={sizeRangeString}";
            url += $"&owner_user_ids={ownerUserIds}";
            url += $"&ancestor_folder_ids={ancestorFolderIds}";
            url += $"&content_types={contentTypes}";
            url += $"&type={type}";
            url += $"&trash_content={trashContent}";
            url += $"&mdfilters={mdFiltersString}";
            url += $"&limit={limit.ToString()}";
            url += $"&offset={offset.ToString()}";
            url += $"&sort={sort}";
            url += $"&direction={direction.ToString()}";
            url += $"&include_recent_shared_links=true";

            var response = BoxHelper.GetResponse(tokenId, BoxHelper.HttpRequestMethods.POST, url).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<BoxCollection<BoxSearchResult>>(response);
        }

        private string BuildDateRangeField(DateTimeOffset? from, DateTimeOffset? to)
        {
            var fromString = from.HasValue
                ? from.Value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssK")
                : string.Empty;
            var toString = to.HasValue ? to.Value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssK") : string.Empty;

            return BuildRangeString(fromString, toString);
        }

        private string BuildSizeRangeField(long? lowerBoundBytes, long? upperBoundBytes)
        {
            var lowerBoundString = lowerBoundBytes.HasValue ? lowerBoundBytes.Value.ToString() : string.Empty;
            var upperBoundString = upperBoundBytes.HasValue ? upperBoundBytes.Value.ToString() : string.Empty;

            return BuildRangeString(lowerBoundString, upperBoundString);
        }

        private string BuildRangeString(string from, string to)
        {
            var rangeString = string.Format("{0},{1}", from, to);
            if (rangeString == ",")
                rangeString = null;

            return rangeString;
        }
    }
}