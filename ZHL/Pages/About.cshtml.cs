using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZHL.GUI.Pages
{
    
    public class AboutModel : PageModel
    {
        public AboutModel()
        {

        }
     
        public string CacheId { get; set; } = "tempId"; //<<-- no user for now

        public void OnGet(string cacheId)
        {
            CacheId = cacheId;
        }

        public IActionResult OnPostSendEmail()
        {
       /// Send Email to me
       //     _emailProvider.Sender(new EmailClientModel("zhuoheng.li1993@qq.com", $"{Subject} - {Name}", TextBox));
       //
       //
       //     /// Send conformation email to user
       //     StringBuilder sb = new();
       //     sb.AppendLine($"Hi {Name}, This is Ben Li");
       //     sb.AppendLine($"Thank you for your {Subject}");
       //     sb.AppendLine("Your Request is receved, and I will contact your shortly !");
       //     sb.AppendLine("Email: <a>ben.li19930119@gmail.com</a>");
       //
       //     _emailProvider.Sender(new EmailClientModel(UserEmail, "Thank You!", sb.ToString()));
       //
            return RedirectToPage("./About", new { CacheId });

        }
    }
}
