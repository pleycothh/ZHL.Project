using log4net;
using ZHL.Library.Models;
using ZHL.Library.Contracts;

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

        public List<ItemModel> Run(string input, List<FilterItemModel> filterList)
        {
            List<ItemModel> itemHistory = new();
            AggregateAnswer answers = new();

            /// Add Final Answer to Model List
            
            if(filterList.Count() != 0)
            {
                _regexIntroTestCases.ToList().ForEach(x => answers.Push(x.Process(input, filterList)));
                AnswerModel result = answers.GetAnswers(input);
                itemHistory.Add(new ItemModel(userId: "tempUserId", textItem: result));
            }
            else
            {
                /// if current filter is empty, 
                /// skip the test case
                /// direact add input to item result
                /// null filter model for match string, because therer is no match
                itemHistory.Add(new ItemModel(userId: "tempUserId", textItem: new AnswerModel(inputString: input)));
            }

            // store Chat History to file
            log.Info($"Take library input:{input}, match list: {filterList}");
            return itemHistory;
        }
    }
}
