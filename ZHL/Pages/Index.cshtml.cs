using ZHL.Library.Contracts;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public string CacheName { get; set; }

        public void OnGet()
        {
            CacheName = _runnerMain.Run("To You");
            log.Info($"CacheName passed from Library is: {CacheName}");

        }
    }
}