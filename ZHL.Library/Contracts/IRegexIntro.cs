using ZHL.Library.Models;

namespace ZHL.Library.Contracts
{
    public interface IRegexIntro
    {
        IEnumerable<AnswerModel> Process(string input);
    }
}