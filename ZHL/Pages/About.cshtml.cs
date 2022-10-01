using ZHL.GUI.Provider; 
using ZHL.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.GUI.Provider.Contracts;
using System.Text;

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
        public string UserEmail { get; set; }
        [BindProperty]
        public string Subject { get; set; }



        public void OnGet(string cacheId)
        {
            CacheId = cacheId;
        }

        public IActionResult OnPostSendEmail()
        {
            /// Send Email to me
            _emailProvider.Sender(new EmailClientModel(Name, "ben.li19930110@gmail.com", Subject, TextBox));


            /// Send conformation email to user
            StringBuilder sb = new();
            sb.AppendLine($"Hi {Name}, This is Ben Li");
            sb.AppendLine($"Thank you for your {Subject}");
            sb.AppendLine("Your Request is receved, and I will contact your shortly !");
            sb.AppendLine("Email: <a>ben.li19930119@gmail.com</a>");

            _emailProvider.Sender(new EmailClientModel(Name, UserEmail, "Thank You!", sb.ToString()));

            return RedirectToPage("./About", new { CacheId });

        }
    }
}
