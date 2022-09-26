﻿using System.Text.RegularExpressions;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.Library.Plugin.RegexPlugin
{
    public class ExactMatch : IRegexIntro
    {
        public IEnumerable<AnswerModel> Process(string input, List<string> filterList)
        {
            var inputList = input.Split(Path.DirectorySeparatorChar);

            foreach (var inp in inputList)
            {
                foreach(var filter in filterList)
                {
                    var regex = new Regex($"{filter}");

                    if (regex.IsMatch(inp))
                    {
                        yield return new AnswerModel(inputString: input, matchString: inp, vecValue: 9, matchName: "Exact Match");
                    }
                }
            }
        }
    }
}
