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
        string Title { get; set; }
        string Content { get; set; }
        string PersonWhoOwns { get; set; }
        prio Priority { get; set; }
        string Line { get; set; }
        public Cards()
        {

        }

        public Cards(string title, string content, string personWhoOwns, prio priority, string line)
        {
            List<Cards> carts = new List<Cards>();
            Title = title;
            Content = content;
            PersonWhoOwns = personWhoOwns;
            Priority = priority;
            Line = line;
        }

    }
}
