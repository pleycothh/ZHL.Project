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
        public IEnumerable<AnswerModel> Process(string input, List<string> filterList)
        {
            yield return new AnswerModel(answer: "I don't unsdertand...", vecValue: 1, matchName: "Loose Match One");
        }
    }
}
