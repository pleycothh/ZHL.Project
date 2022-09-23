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
        public RunnerMain()
        {

        }

        private static readonly ILog log = LogManager.GetLogger("file");

        public string Run(string input)
        {
            log.Info($"Take library input as {input}");
            return input;
        }
    }
}
