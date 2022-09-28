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
        public readonly IItemProvider _itemProvider;
        private readonly IFilterListProvider _filterProvider;
        private static readonly ILog log = LogManager.GetLogger("file");

        public IndexModel(IItemProvider itemProvider, IFilterListProvider filterProvider)
        {
            _itemProvider = itemProvider;
            _filterProvider = filterProvider;
        }

        [BindProperty]
        public string UserInput { get; set; }

        public string CacheId { get; set; } = "tempId"; //<<-- no user for now

        public List<string> filterList = new();
        public List<ItemModel> itemList = new();


        /// <summary>
        /// get filterList and itemList from cache all the time
        /// </summary>
        public void OnGet(string cacheId)
        {
            CacheId = cacheId;

            itemList = _itemProvider.GetItemList(CacheId);
            filterList = _filterProvider.GetFilter();
            Console.WriteLine($"On Get called, Cache Id is : {CacheId}");

        }

        /// <summary>
        /// submit main form, run analysis, return new result
        /// </summary>
        public IActionResult OnPostSetItem()
        {

            /// Question: why User input is null??
            Console.WriteLine($"On Posted called, User input is {UserInput}, Cache Id is : {CacheId}");

            if(UserInput is not null)
            {
                _itemProvider.SetItemList(UserInput, filterList, CacheId);
            }

            return RedirectToPage("./Index", new { CacheId });
            //return Page();
        }
    }
}