
namespace ZHL.Library.Models
{
    public class ItemModel
    {
        public string UserId { get; set; } // temp not used, set as fixed value
        public string HashId { get; set; }
        public AnswerModel TextItem { get; set; }
        public DateTime Created { get; set; }

        public ItemModel(string userId, AnswerModel textItem)
        {
            UserId = userId;
            TextItem = textItem;
            HashId = $"{textItem.InputString}-{DateTime.Now.Millisecond}";
            Created = DateTime.Now;
        }
    }
}
