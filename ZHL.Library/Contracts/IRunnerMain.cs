using ZHL.Library.Models;

namespace ZHL.Library.Contracts
{
    public interface IRunnerMain
    {
        List<ItemModel> Run(string input, List<string> filterList);
    }
}