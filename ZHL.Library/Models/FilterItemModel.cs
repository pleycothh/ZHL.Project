using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHL.Library.Models
{
    public class FilterItemModel
    {
        public string FilterName { get; set; }
        public string HashId { get; set; }
        public DateTime Created { get; set; }
        public FilterItemModel(string filterName)
        {
            FilterName = filterName;
            HashId = $"{FilterName}-{DateTime.Now.Millisecond}";
            Created = DateTime.Now;
        }
    }
}
