using Microsoft.Extensions.Caching.Memory;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Contracts;

namespace ZHL.GUI.Provider
{
    public class FilterListProvider : IFilterListProvider
    {


        private readonly IMemoryCache _memoryCache;

        public FilterListProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<string> GetFilter()
        {
            return new List<string>();
        }

        public void SetFilter(List<string> filterList)
        {

        }

        //  no need for library invove, just set to cache 
        // add to db later
    }
}
