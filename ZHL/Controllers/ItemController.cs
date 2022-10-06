using Microsoft.AspNetCore.Mvc;
using ZHL.GUI.Provider.Contracts;
using ZHL.Library.Models;

namespace ZHL.GUI.Controllers
{
    [Route("api/[Controller]")]
    
    public class ItemController : Controller
    {
        private readonly IItemProvider itemProvider;

        public ItemController(IItemProvider ItemProvider)
        {
            itemProvider = ItemProvider;
        }

        [HttpGet]
        public string Index()
        {
            return "Demo API: https://localhost:7200/api/Item/deleteItem?deleteIndex=asdf-789";
        }


        // api/deleteItem/{hashId}/
        [HttpDelete("{deleteItem}")]
        public List<ItemModel> DeleteItem(string deleteIndex)
        {
            return itemProvider.DeleteItem(deleteIndex);

        }
    }
}
