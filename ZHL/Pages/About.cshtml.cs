using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZHL.GUI.Pages
{
    public class AboutModel : PageModel
    {
        public string CacheId { get; set; } = "tempId"; //<<-- no user for now

        public void OnGet()
        {
        }
    }
}
