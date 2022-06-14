using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJournalLogic
{
    public class Entry
    {
        public string ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Entry (string content, DateTime date)
        {
            ID = GenerateID();
            Content = content; 
            Date = date;
        }

        private string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }

}
