using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.Plugin.RegexPlugin
{
    public class LoosMatchOne : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input, List<FilterItemModel> filterList)
        {
            yield return new AnswerModel(inputString: input, matchString: new FilterItemModel("demo"), vecValue: 8, matchName: "Loose Match One");
        }
    }
}
