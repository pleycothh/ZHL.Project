using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.GUI.Provider;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Models;

namespace ZHL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IItemProvider _itemProvider;
        private static readonly ILog log = LogManager.GetLogger("file");

        public IndexModel(IItemProvider itemProvider)
        {
            _itemProvider = itemProvider;
        }

        [BindProperty]
        public string UserInput { get; set; }
        //public string UserId { get; set; } <<-- no user for now

        public List<string> filterList = new();
        public List<ItemModel> itemList = new();


        /// <summary>
        /// get filterList and itemList from cache all the time
        /// </summary>
        public void OnGet(string userInput)
        {
            itemList = _itemProvider.GetCacheItemList();
            filterList = _filterProvider.GetFilter(filterList);
        }

        /// <summary>
        /// submit main form, run analysis, return new result
        /// </summary>
        public IActionResult OnPost()
        {

            /// Question: why User input is null??
            Console.WriteLine($"On Posted called, User input is {UserInput}, User Id is : {UserId}");

            _itemProvider.SetCacheItemList(UserInput);

            return RedirectToPage("./Index", new { UserInput });
            //return Page();
        }

        /// <summary>
        /// submit filter list updates:
        /// 1: reload page
        /// 2: keep the input box as cache
        /// 3: load new filter list to the UI
        /// </summary>
        public IActionResult OnPostUpdateList()
        {

            /// Question: why User input is null??
            Console.WriteLine($"On Posted called, User input is {UserInput}, User Id is : {UserId}");

            _filterProvider.SetFilter(filterList);
           

            return RedirectToPage("./Index", new { UserInput });

        }
    }
}