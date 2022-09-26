namespace ZHL.GUI.Provider.Contracts
{
    public interface IFilterListProvider
    {
        List<string> GetFilter();
        void SetFilter(List<string> filterList);
    }
}