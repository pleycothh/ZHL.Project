using System.Text.RegularExpressions;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.Plugin.RegexPlugin
{
    public class ExactMatch : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input, List<string> filterList)
        {
            return filterList
                .Where(x => Regex.IsMatch( input, x))
                .Select(x => new AnswerModel(answer: input, vecValue: 12, matchName: "Exact Match"));
        }
    }
}
