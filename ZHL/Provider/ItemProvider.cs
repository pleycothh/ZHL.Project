using Microsoft.Extensions.Caching.Memory;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Provider
{
    public class ItemProvider
    {

        private readonly IMemoryCache _memoryCache;
        private readonly IRunnerMain _mainRunner;

        public ItemProvider(IRunnerMain mainRunner, IMemoryCache memoryCache)
        {
            _mainRunner = mainRunner;
            _memoryCache = memoryCache;
        }


        public List<ItemModel> GetCacheItemList(string userId)
        {
            userId = userId is null ? "-1" : userId;

            var result = _memoryCache.Get<List<ItemModel>>(userId);

            if (result is null)
            {
                return new List<ItemModel>();
            }
            return result;
        }
    }
}
