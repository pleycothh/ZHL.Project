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
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailClientModel(string name, string to, string subject, string body)
        {
            Name = name;
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
