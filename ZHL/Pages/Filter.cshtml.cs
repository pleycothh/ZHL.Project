using ZHL.Library.Models;
using Microsoft.AspNetCore.Mvc;
using ZHL.GUI.Provider.Contracts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZHL.GUI.Pages
{
    public class FilterModel : PageModel
    {

        public readonly IFilterListProvider _filterProvider;

        public FilterModel(IFilterListProvider filterProvider)
        {
            _filterProvider = filterProvider;
        }

        [BindProperty]
        public string FilterInput { get; set; }

        public string CacheId { get; set; } = "tempId"; //<<-- no user for now

        public List<FilterItemModel> filterList = new();


        public void OnGet(string cacheId)
        {
            CacheId = cacheId;
        //    if(filterList.Count > 2)
        //        Console.WriteLine(filterList.First().FilterName + "-" + filterList.First().HashId);

            filterList = _filterProvider.GetFilter();
        }


        /// <summary>
        /// submit filter list updates:
        /// 1: reload page
        /// 2: keep the input box as cache
        /// 3: load new filter list to the UI
        /// </summary>
        public IActionResult OnPostAddFilter()
        {

            //Console.WriteLine($"On Posted AddFilter called, User input is {FilterInput}, Cache Id is : {CacheId}");

            _filterProvider.AddFilter(FilterInput);

            return RedirectToPage("./Filter", new { CacheId });

        }
    }
}
