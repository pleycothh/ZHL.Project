using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHL.Library.Contracts;

namespace ZHL.Library.NLP
{
    public class Hello : IRegexIntro
    {
        public string Process(string input)
        {
            List<string> inputList = new();
            if(input is null)
            {
                return null;
            }
            inputList.AddRange(input.Split(' '));

            var result = inputList.Where(x => x.ToLower().Contains("hello") || x.ToLower().Contains("hi"));



            if (result is not null && result.ToList().Count >= 1)
            {
                return "Hi, there!"; // <- use yield return here.
            }
            else
            {
                return "What did you say?";
            }
        }

    }
}
