using ZHL.Library.Models;

namespace ZHL.GUI.Provider.Contracts
{
    public interface IItemProvider
    {
        List<ItemModel> GetItemList(string CacheId);
        void SetItemList(string userId, string CacheId);
    }
}