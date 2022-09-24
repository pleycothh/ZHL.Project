using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZHL.Library.Models
{
    public class ChatHistory
    {
        public List<ChatItem> ChatItems = new();

        public void Push(ChatItem chatItem)
        {
            ChatItems.Add(chatItem);
        }

        public void Push(List<ChatItem> ChatItemList)
        {
            ChatItems.AddRange(ChatItemList);
        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(ChatItems);
        }
    }
}
