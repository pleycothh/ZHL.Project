using ZHL.Library.Models;
using ZHL.Library.Contracts;
using ZHL.GUI.Provider.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace ZHL.GUI.Provider
{
    public class FilterListProvider : IFilterListProvider
    {
        private readonly IMemoryCache _memoryCache;

        public FilterListProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Get Filter list from cache memeory
        /// </summary>
        public List<FilterItemModel> GetFilter()
        {
            var filter = _memoryCache.Get<List<FilterItemModel>>("filter");
        //    Console.WriteLine($"Get filter from cache.");
            return filter is null ? new List<FilterItemModel>() : filter;
        }

        /// <summary>
        /// Get Filter from memory then add and pushback to cache memory
        /// </summary>
        public void AddFilter(string filterInput)
        {
        //    Console.WriteLine($"Add Filter with input: {filterInput}");
            var filter = _memoryCache.Get<List<FilterItemModel>>("filter");

            if(filter is null)
            {
             //   Console.WriteLine("Filter Cache is null, empty filter list created");

                filter = new List<FilterItemModel>();
            }

            filter.Add(new FilterItemModel(filterInput));
            _memoryCache.Set("filter", filter);
        }

        public List<FilterItemModel> DeleteFilter(string hashId)
        {
            var filter = GetFilter();

            filter.RemoveAll(x => x.HashId == hashId);

            return filter;
        }
    }
}
