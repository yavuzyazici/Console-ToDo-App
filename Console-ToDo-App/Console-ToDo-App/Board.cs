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
        public void Start(Board board)
        {
            string input;
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :\n*******************************************\n(1) Board Listelemek (2) Board'a Kart Eklemek (3) Board'dan Kart Silmek (4) Kart Taşımak");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ListBoard(board);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

        }
        public void ListBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine("TODO Line\r\n ************************\r");
            if (toDo.Count() == 0)
                Console.WriteLine("~Boş~");
            
            foreach (var item in board.toDo)
            {
                
                Console.WriteLine($" Başlık      :{item.Title}\r\n İçerik      :{item.Content}\r\n Atanan Kişi :{item.PersonWhoOwns}\r\n Büyüklük    :{item.Priority}\n");
            }
            Console.WriteLine("\nIN PROGRESS Line\r\n ************************\r");
            if (inProgress.Count() == 0)
                Console.WriteLine("~Boş~");
            
            foreach (var item in board.inProgress)
            {
                Console.WriteLine($" Başlık      :{item.Title}\r\n İçerik      :{item.Content}\r\n Atanan Kişi :{item.PersonWhoOwns}\r\n Büyüklük    :{item.Priority}\n");
            }
            Console.WriteLine("\nDone Line\r\n ************************\r");
            if (done.Count() == 0)
                Console.WriteLine("~Boş~"); 
            foreach (var item in board.done)
            {
                Console.WriteLine($" Başlık      :{item.Title}\r\n İçerik      :{item.Content}\r\n Atanan Kişi :{item.PersonWhoOwns}\r\n Büyüklük    :{item.Priority}\n");
            }

            Console.WriteLine(" İşlem Tamamlandı. \n * Ana Menüye Dönmek için bir tuşa basınız    :");
        Beginning:
            var input = Console.ReadKey();
            Console.Clear();
            Start(board);
        }
    }
}
