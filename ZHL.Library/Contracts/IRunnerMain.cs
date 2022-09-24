using ZHL.Library.Models;

namespace ZHL.Library.Contracts
{
    public interface IRunnerMain
    {
        ChatHistory Run(string input);
    }
}