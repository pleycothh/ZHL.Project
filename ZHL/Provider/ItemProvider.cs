using Microsoft.Extensions.Caching.Memory;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Provider
{
    public class ItemProvider : IItemProvider
    {

        private readonly IMemoryCache _memoryCache;
        private readonly IRunnerMain _mainRunner;

        public ItemProvider(IRunnerMain mainRunner, IMemoryCache memoryCache)
        {
            _mainRunner = mainRunner;
            _memoryCache = memoryCache;
        }


        public List<ItemModel> GetItemList(string CacheId)
        {
            CacheId = CacheId is null ? "-1" : CacheId;

            var result = _memoryCache.Get<List<ItemModel>>(CacheId);

            if (result is null)
            {
                return new List<ItemModel>();
            }
            return result;
        }

        public void SetItemList(string userId, string CacheId)
        {
            userId = userId is null ? "-1" : userId;

            // var result = _memoryCache.Set<List<ItemModel>>(userId);


        }
    }
}
