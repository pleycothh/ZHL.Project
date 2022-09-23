using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHL.Library.Models
{
    public class AggregateAnswer
    {
        private AnswerModel _finalAnswer { get; set; }
        private List<AnswerModel> _answerList = new();

        public AnswerModel GetAnswers()
        {
            _answerList.ForEach(x =>
            {
                if (_finalAnswer is null || x.AnswerRate > _finalAnswer.AnswerRate)
                {
                    _finalAnswer = x;
                }
            });
            return _finalAnswer;
        }
        public void Push(IEnumerable<AnswerModel> ans)
        {
            _answerList.AddRange(ans);
        }


    }
}
