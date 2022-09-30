using ZHL.GUI.Provider; 
using ZHL.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZHL.GUI.Pages
{
    
    public class AboutModel : PageModel
    {
        public string CacheId { get; set; } = "tempId"; //<<-- no user for now
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string TextBox { get; set; }


        public void OnGet(string cacheId)
        {
            CacheId = cacheId;
        }

        public async Task<IActionResult> OnPostSendEmail()
        {
            await EmailerProvider.Sender(new EmailClientModel("Test Name"));

            return RedirectToPage("./About", new { CacheId });

        }
    }
}
