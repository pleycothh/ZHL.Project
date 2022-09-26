using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHL.Library.Models
{
    public class AnswerModel
    {
        public int VecValue { get; set; }
        public string Answer { get; set; }

        public AnswerModel(string answer, int vecValue = -1)
        {
            VecValue = vecValue;
            Answer = answer;
        }
    }
}
