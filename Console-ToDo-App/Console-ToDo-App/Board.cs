using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ToDo_App
{
    public class Board
    {
        public List<Cards> toDo;
        public List<Cards> inProgress;
        public List<Cards> done;

        public Board()
        {
            toDo = new List<Cards>();
            inProgress = new List<Cards>();
            done = new List<Cards>();
        }

        public void ListBoard(Board board)
        {
            Console.WriteLine("TODO Line\r\n ************************\r\n");
            foreach (var item in board.inProgress)
            {
                Console.WriteLine("Title: {0}", item);
                Console.WriteLine($" Başlık      :{item}\r\n İçerik      :\r\n Atanan Kişi :\r\n Büyüklük    :");
            }
        }
    }
}
