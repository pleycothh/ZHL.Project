using ZHL.Library.Models;

namespace ZHL.GUI.Provider.Contracts
{
    public interface IChatHistoryProvider
    {
        List<ChatItem> SetCacheHistory(string userInput,string userId);
        List<ChatItem> GetCacheHistory(string userId);

    }
}