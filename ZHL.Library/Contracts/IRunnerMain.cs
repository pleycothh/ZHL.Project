using ZHL.Library.Models;

namespace ZHL.Library.Contracts
{
    public interface IRunnerMain
    {
        AnswerModel Run(string input);
    }
}