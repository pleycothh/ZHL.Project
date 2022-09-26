using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.Plugin.RegexPlugin
{
    public class IDK : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input)
        {
            yield return new AnswerModel(answer: "I don't unsdertand...", vecValue: 1);
        }
    }
}
