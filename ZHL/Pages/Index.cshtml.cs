using log4net;
using ZHL.Library.Models;
using Microsoft.AspNetCore.Mvc;
using ZHL.GUI.Provider.Contracts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZHL.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IItemProvider ItemProvider;
        private readonly IFilterListProvider _filterProvider;
    //    private static readonly ILog log = LogManager.GetLogger("file");

        public IndexModel(IItemProvider itemProvider, IFilterListProvider filterProvider)
        {
            ItemProvider = itemProvider;
            _filterProvider = filterProvider;
        }

        [BindProperty]
        public string UserInput { get; set; }

        public string CacheId { get; set; } = "tempId"; //<<-- no user for now

        public List<FilterItemModel> FilterList = new();
        public List<ItemModel> itemList = new();


        /// <summary>
        /// get filterList and itemList from cache all the time
        /// </summary>
        public void OnGet(string cacheId)
        {
            CacheId = cacheId;

            itemList = ItemProvider.GetItemList(CacheId);
            FilterList = _filterProvider.GetFilter();
        //    Console.WriteLine($"On Get called, Cache Id is : {CacheId}");

        }

        /// <summary>
        /// submit main form, run analysis, return new result
        /// </summary>
        public IActionResult OnPostSetItem()
        {
            FilterList = _filterProvider.GetFilter();
            //Console.WriteLine($"On Posted called, User input is {UserInput}, Cache Id is : {CacheId}");

            if(UserInput is not null)
            {
                ItemProvider.SetItemList(UserInput, FilterList, CacheId);
            }

            return RedirectToPage("./Index", new { CacheId });
        }
    }
}