using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.GUI.Provider;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Models;

namespace ZHL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IChatHistoryProvider _chatHistoryProvider;
        private static readonly ILog log = LogManager.GetLogger("file");

        public IndexModel( IChatHistoryProvider chatHistoryProvider)
        {
            _chatHistoryProvider = chatHistoryProvider;
        }

        [BindProperty]
        public string UserInput { get; set; }
        public string UserId { get; set; }

        public List<ChatItem> chatHistory = new();
        


        public void OnGet()
        {
            Console.WriteLine($"On Get called, User input is {UserInput}, User Id is : {UserId}");
            // append user input, get full history from cache
            chatHistory = _chatHistoryProvider.GetCacheHistory(UserId);
            
            log.Info($"User Input is: {UserInput}");

        }

        public IActionResult OnPost()
        {

            /// Question: why User input is null??
            Console.WriteLine($"On Posted called, User input is {UserInput}, User Id is : {UserId}");

            _chatHistoryProvider.SetCacheHistory(UserInput, UserId);

            return RedirectToPage("./Index", new { UserInput });
            //return Page();
        }
    }
}