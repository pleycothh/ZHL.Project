using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using log4net;
using ZHL.Library.Models;

namespace ZHL.Library
{
    public class RunnerMain : IRunnerMain
    {
        private readonly IEnumerable<IRegexIntro> _regexIntroTestCases;
        public RunnerMain(IEnumerable<IRegexIntro> regexIntro)
        {
            _regexIntroTestCases = regexIntro;
        }

        private static readonly ILog log = LogManager.GetLogger("file");

        public AnswerModel Run(string input)
        {
            /// Load from voic and process
            /// Dump the voic result to speach module
            /// Return Speach modual result back to GUI
            /// 

            /// The history of the chat will convert to a special model and add to byies to the process model

            AggregateAnswer answers = new();

            _regexIntroTestCases.ToList().ForEach(x => answers.Push(x.Process(input)));

            AnswerModel result = answers.GetAnswers();
            log.Info($"Take library input as {input}");
            log.Info($"Library return result as {result}");
            return result;
        }
    }
}
