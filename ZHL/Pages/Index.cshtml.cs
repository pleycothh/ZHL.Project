using ZHL.Library.Contracts;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.Library.Models;

namespace ZHL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRunnerMain _runnerMain;
        private static readonly ILog log = LogManager.GetLogger("file");

        public IndexModel( IRunnerMain runnerMain)
        {
            _runnerMain = runnerMain;
        }

        [BindProperty]
        public string UserInput { get; set; }

        public ChatHistory chatHistory { get; set; }
        public DateTime DateTimeNow { get; set; }
        


        public void OnGet(string userInput)
        {

            // append user input
            chatHistory = _runnerMain.Run(userInput is null? "hi": userInput) ;
            log.Info($"User Input is: {userInput}");

        }

        public IActionResult OnPost()
        {
            Console.WriteLine("On Posted called");
            return RedirectToPage("./Index", new { UserInput });
        }
    }
}