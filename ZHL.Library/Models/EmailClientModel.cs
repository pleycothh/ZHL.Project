using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHL.Library.Models
{
    public class EmailClientModel
    {
        public string Name { get; set; }
        public EmailClientModel(string name)
        {
            Name = name;
        }
    }
}
