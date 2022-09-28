using Microsoft.Extensions.Caching.Memory;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Provider
{
    public class FilterListProvider : IFilterListProvider
    {


        private readonly IMemoryCache _memoryCache;

        public FilterListProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<FilterItemModel> GetFilter()
        {
            var filter = _memoryCache.Get<List<FilterItemModel>>("filter");
            Console.WriteLine($"Get filter from cache.");
            return filter is null ? new List<FilterItemModel>() : filter;
        }

        public void AddFilter(string filterInput)
        {
            Console.WriteLine($"Add Filter with input: {filterInput}");
            var filter = _memoryCache.Get<List<FilterItemModel>>("filter");

            if(filter is null)
            {
                Console.WriteLine("Filter Cache is null, empty filter list created");

                filter = new List<FilterItemModel>();
            }

            filter.Add(new FilterItemModel(filterInput));
            _memoryCache.Set("filter", filter);
        }

        public void DeleteFilter(string hashId)
        {
            var filter = GetFilter();

            filter.RemoveAll(x => x.HashId == hashId);

        //    _memoryCache.Set("filter", filter);


        }

        //  no need for library invove, just set to cache 
        // add to db later
    }
}
