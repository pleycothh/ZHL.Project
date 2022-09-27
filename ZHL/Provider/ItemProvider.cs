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


        public List<ItemModel> GetItemList(string cacheId)
        {
            cacheId = cacheId is null ? "-1" : cacheId;

            var result = _memoryCache.Get<List<ItemModel>>(cacheId);

            if (result is null)
            {
                Console.WriteLine("Item Cache is null, empty item list created");
                return new List<ItemModel>();
            }
            return result;
        }

        public void SetItemList(string userInput, List<string> filterList, string cacheId)
        {
           // List<ItemModel> items = new();
            cacheId = cacheId is null ? "-1" : cacheId;
            userInput = userInput is null ? "NULL" : userInput;
            Console.WriteLine($"Add item with user input: {userInput}");

            var items = _memoryCache.Get<List<ItemModel>>(cacheId);
            
               if (items is null)
               {
                    items = _mainRunner.Run(userInput, filterList);
               }
                else
                {
                    items.AddRange(_mainRunner.Run(userInput, filterList));
                }
            Console.WriteLine($"Save Item List to cache with chache Id: {cacheId}");

            _memoryCache.Set(cacheId, items);

        }
    }
}
