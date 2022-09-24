using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Provider
{
    public class ChatHistoryProvider : IChatHistoryProvider
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRunnerMain _mainRunner;

        public ChatHistoryProvider(IRunnerMain mainRunner, IMemoryCache memoryCache)
        {
            _mainRunner = mainRunner;
            _memoryCache = memoryCache;
        }

        public List<ChatItem> SetCacheHistory(string userInput,string userId)
        {
            List<ChatItem> chatItems = new();

            userId = initUserID(userId);
            userInput = initUserInput(userInput);

            chatItems = _memoryCache.Get<List<ChatItem>>(userId);

            if (chatItems is null)
            {
                //allResults = mainRunner.RunBatchAnalysis($@"{Path.Path}", true).GetResults();
                chatItems = _mainRunner.Run(userInput);
            }
            else
            {
                chatItems.AddRange(_mainRunner.Run(userInput));
            }
            _memoryCache.Set(userId, chatItems);
            return chatItems;
        }

        public List<ChatItem> GetCacheHistory(string userId)
        {
            userId = initUserID(userId);

            var result = _memoryCache.Get<List<ChatItem>>(userId);

            if(result is null)
            {
                return new List<ChatItem>();
            }
            return result;
        }

        /// <summary>
        /// User input is null when refresh the page
        /// </summary>
        private string initUserInput(string userInput)
        {
            return userInput is null ? "hi": userInput;
        }

        /// <summary>
        /// User id is null if user is not log in
        /// </summary>
        private string initUserID(string userID)
        {
            return userID is null ? "-1" : userID;
        }

    }

}
