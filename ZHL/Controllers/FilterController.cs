using Microsoft.AspNetCore.Mvc;
using ZHL.GUI.Provider;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Controllers
{
    [Route("api/[Controller]")]
    public class FilterController : Controller
    {

        private readonly IFilterListProvider filterListProvider;

        public FilterController(IFilterListProvider FilterListProvider)
        {
            filterListProvider = FilterListProvider;
        }

        [HttpGet]
        public string Index()
        {
            return "Demo API: https://localhost:7200/api/Item/deleteFilter?deleteIndex=asdf-789";
        }


        // api/deleteItem/{hashId}/
        [HttpDelete("{deleteFilter}")]
        public List<FilterItemModel> DeleteFilter(string deleteIndex)
        {
            return filterListProvider.DeleteFilter(deleteIndex);

        }
    }
}
