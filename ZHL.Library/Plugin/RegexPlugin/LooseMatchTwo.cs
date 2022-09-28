using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.Plugin.RegexPlugin
{
    public class LooseMatchTwo : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input, List<FilterItemModel> filterList)
        {
            var regex = new Regex(@"name");

            if (regex.IsMatch(input))
            {
                yield return new AnswerModel(inputString: input, matchString: new FilterItemModel("demo"), vecValue: 7, matchName: "Loose Match Two");
            }
        }
    }
}
