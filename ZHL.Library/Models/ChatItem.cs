using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHL.Library.Models
{
    public class ChatItem
    {
        public int Id { get; set; }
        public AnswerModel TextItem { get; set; }
        public bool IsUser { get; set; }
        public DateTime Created { get; set; }

        public ChatItem(int id, AnswerModel textItem, bool isUser)
        {
            Id = id;
            TextItem = textItem;
            IsUser = isUser;
            Created = DateTime.Now;
        }
    }
}
