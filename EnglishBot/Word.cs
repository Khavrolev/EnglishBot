using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBot
{
    public class Word
    {
        public string Russian { get; set; }
        public string English { get; set; }
        public string Subject { get; set; }

        public Word(string russian)
        {
            Russian = russian;
        }
    }
}
