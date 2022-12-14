using ZHL.GUI.Pages;
using ZHL.Library.Models;

namespace ZHL.GUI.Provider.Contracts
{
    public interface IFilterListProvider
    {
        List<FilterItemModel> GetFilter();
        void AddFilter(string filterInput);
        void DeleteFilter(string hashId);
    }
}