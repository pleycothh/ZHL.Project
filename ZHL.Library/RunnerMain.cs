using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHL.Library.Contracts;
using log4net;

namespace ZHL.Library
{
    public class RunnerMain : IRunnerMain
    {
        private readonly IRegexIntro _regexIntro;
        public RunnerMain(IRegexIntro regexIntro)
        {
            _regexIntro = regexIntro;
        }

        private static readonly ILog log = LogManager.GetLogger("file");

        public string Run(string input)
        {
            string result = _regexIntro.Process(input);
            log.Info($"Take library input as {input}");
            log.Info($"Library return result as {result}");
            return result;
        }
    }
}
