using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ToDo_App
{
    public class Cards
    {
        public enum prio
        {
            XS = 1,
            S = 2,
            M = 3,
            L = 4,
            XL = 5
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PersonWhoOwns { get; set; }
        public prio Priority { get; set; }
        public string Line { get; set; }
        public Cards()
        {
            List<Cards> carts = new List<Cards>();
        }

        public Cards(string title, string content, string personWhoOwns, prio priority, string line)
        {
            Title = title;
            Content = content;
            PersonWhoOwns = personWhoOwns;
            Priority = priority;
            Line = line;
        }

    }
}
