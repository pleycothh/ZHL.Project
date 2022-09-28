using ZHL.Library.Models;

namespace ZHL.GUI.Provider.Contracts
{
    public interface IItemProvider
    {
        List<ItemModel> GetItemList(string cacheId);
        void SetItemList(string userInput, List<FilterItemModel> filterList, string cacheId);
        void DeleteItem(string hashId);
    }
}