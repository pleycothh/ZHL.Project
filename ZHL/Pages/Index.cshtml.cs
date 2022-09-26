using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Models;

namespace ZHL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IItemProvider _itemProvider;
        private readonly IFilterListProvider _filterProvider;
        private static readonly ILog log = LogManager.GetLogger("file");

        public IndexModel(IItemProvider itemProvider, IFilterListProvider filterProvider)
        {
            _itemProvider = itemProvider;
            _filterProvider = filterProvider;
        }

        [BindProperty]
        public string UserInput { get; set; }
        public string CacheId { get; set; } //<<-- no user for now

        public List<string> filterList = new();
        public List<ItemModel> itemList = new();


        /// <summary>
        /// get filterList and itemList from cache all the time
        /// </summary>
        public void OnGet(string userInput, string CacheId)
        {
            itemList = _itemProvider.GetItemList(CacheId);
            filterList = _filterProvider.GetFilter();
        }

        /// <summary>
        /// submit main form, run analysis, return new result
        /// </summary>
        public IActionResult OnPost()
        {

            /// Question: why User input is null??
            Console.WriteLine($"On Posted called, User input is {UserInput}, User Id is : {CacheId}");

            _itemProvider.SetItemList(UserInput, CacheId);

            return RedirectToPage("./Index", new { UserInput, CacheId });
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
            Console.WriteLine($"On Posted called, User input is {UserInput}, User Id is : {CacheId}");

            _filterProvider.SetFilter(filterList);
           

            return RedirectToPage("./Index", new { UserInput, CacheId });

        }
    }
}