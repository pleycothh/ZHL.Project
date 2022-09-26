namespace ZHL.GUI.Provider.Contracts
{
    public interface IFilterListProvider
    {
        List<string> GetFilter();
        void AddFilter(string filterInput);
    }
}