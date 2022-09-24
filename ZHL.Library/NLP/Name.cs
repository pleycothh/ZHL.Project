using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.NLP
{
    public class Name : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input)
        {
            var regex = new Regex(@"name");

            if (regex.IsMatch(input))
            {
                yield return new AnswerModel(answer: "My Name is AI", rate: 12);
            }
        }
    }
}
