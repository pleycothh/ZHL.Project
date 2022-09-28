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

        public List<ItemModel> Run(string input, List<FilterItemModel> filterList)
        {
            /// Load from voic and process
            /// Dump the voic result to speach module
            /// Return Speach modual result back to GUI
            /// 

            // Add to Chat history

            List<ItemModel> itemHistory = new();
            AggregateAnswer answers = new();

           
            /// Add User input to Model List, no need
            //itemHistory.Add(new ItemModel(id: 2, textItem: new AnswerModel(input), isUser: true));
            /// The history of the chat will convert to a special model and add to byies to the process model


            /// Add Final Answer to Model List
            
            if(filterList.Count() != 0)
            {
                _regexIntroTestCases.ToList().ForEach(x => answers.Push(x.Process(input, filterList)));
                AnswerModel result = answers.GetAnswers();
                itemHistory.Add(new ItemModel(userId: "tempUserId", textItem: result));
            }
            else
            {
                itemHistory.Add(new ItemModel(userId: "tempUserId", textItem: new AnswerModel(inputString: input, matchString: "null", matchName: "Enpty Filter")));
            }

            // store Chat History to file

            log.Info($"Take library input:{input}, match list: {filterList}");
            return itemHistory;

        }
    }
}
