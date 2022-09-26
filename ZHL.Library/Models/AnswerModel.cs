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
        public string InputString { get; set; }
        public string MatchString { get; set; }
        public string MatchName { get; set; }

        public AnswerModel( string inputString, string matchString, string matchName, int vecValue = -1)
        {
            VecValue = vecValue;
            InputString = inputString;
            MatchString = matchString;
            MatchName = matchName;
        }
    }
}
