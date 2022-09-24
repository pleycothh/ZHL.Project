using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.NLP
{
    public class Hello : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input)
        {
            List<string> inputList = new();

            inputList.AddRange(input.Split(' '));

            var result = inputList.Where(x => x.ToLower().Contains("hello") || x.ToLower().Contains("hi"));


            if (result is not null && result.ToList().Count >= 1)
            {
                yield return new AnswerModel(answer: "Hi, there!", rate: 10);
            }
        }
    }
}
