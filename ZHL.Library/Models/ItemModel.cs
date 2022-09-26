using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHL.Library.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public AnswerModel TextItem { get; set; }
        public DateTime Created { get; set; }

        public ItemModel(int id, AnswerModel textItem, bool isUser)
        {
            Id = id;
            TextItem = textItem;
            Created = DateTime.Now;
        }
    }
}
