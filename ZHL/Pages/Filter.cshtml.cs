using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Pages
{
    public class FilterModel : PageModel
    {

        private readonly IFilterListProvider _filterProvider;

        public FilterModel(IFilterListProvider filterProvider)
        {
            _filterProvider = filterProvider;
        }

        [BindProperty]
        public string FilterInput { get; set; }

        public string CacheId { get; set; } = "tempId"; //<<-- no user for now

        public List<string> filterList = new();


        public void OnGet(string cacheId)
        {
            CacheId = cacheId;

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

            /// Question: why User input is null??
            Console.WriteLine($"On Posted AddFilter called, User input is {FilterInput}, Cache Id is : {CacheId}");

            _filterProvider.AddFilter(FilterInput);


            return RedirectToPage("./Filter", new { CacheId });

        }
    }
}
