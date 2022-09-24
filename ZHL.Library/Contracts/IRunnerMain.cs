using ZHL.Library.Models;

namespace ZHL.Library.Contracts
{
    public interface IRunnerMain
    {
        List<ChatItem> Run(string input);
    }
}