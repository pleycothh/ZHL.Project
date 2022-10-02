
namespace ZHL.Library.Models
{
    public class AnswerModel
    {
        public int VecValue { get; set; }
        public string InputString { get; set; }
        public FilterItemModel MatchString { get; set; }
        public string MatchName { get; set; }

        public AnswerModel( string inputString, FilterItemModel matchString, string matchName, int vecValue = -1)
        {
            VecValue = vecValue;
            InputString = inputString;
            MatchString = matchString;
            MatchName = matchName;
        }


        public AnswerModel(string inputString)
        {
            VecValue = -1;
            InputString = inputString;
            MatchString = new FilterItemModel("Null");
            MatchName = "NULL";
        }
    }
}
