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

        public AnswerModel GetAnswers(string input)
        {
            _answerList.ForEach(x =>
            {
                if (_finalAnswer is null || x.VecValue > _finalAnswer.VecValue)
                {
                    _finalAnswer = x;
                }
            });

            _finalAnswer = _finalAnswer is null ? new AnswerModel(input) : _finalAnswer;
            return _finalAnswer;
        }
        public void Push(IEnumerable<AnswerModel> ans)
        {
            _answerList.AddRange(ans);
        }


    }
}
