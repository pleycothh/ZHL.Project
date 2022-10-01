using ZHL.GUI.Provider; 
using ZHL.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.GUI.Provider.Contracts;

namespace ZHL.GUI.Pages
{
    
    public class AboutModel : PageModel
    {
        IEmailerProvider _emailProvider;
        public AboutModel(IEmailerProvider emailerProvider)
        {
            _emailProvider = emailerProvider;
        }
     
        
        public string CacheId { get; set; } = "tempId"; //<<-- no user for now
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string TextBox { get; set; }
        [BindProperty]
        public string To { get; set; }
        [BindProperty]
        public string Subject { get; set; }



        public void OnGet(string cacheId)
        {
            CacheId = cacheId;
        }

        public IActionResult OnPostSendEmail()
        {
            _emailProvider.Sender(new EmailClientModel(Name, To, Subject, TextBox));

            return RedirectToPage("./About", new { CacheId });

        }
    }
}
