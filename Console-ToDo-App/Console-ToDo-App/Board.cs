using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public void Start(Board board, TeamMembers teamMembers)
        {
            Console.Clear();
            string input;
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :\n*******************************************\n(1) Board Listelemek (2) Board'a Kart Eklemek (3) Board'dan Kart Silmek (4) Kart Taşımak (5) Kaydet ve Çık");
            input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                    Console.Clear();
                    ListBoard(board, teamMembers);
                    break;
                case "2":
                    Console.Clear();
                    AddCard(board, teamMembers);
                    break;
                case "3":
                    DeleteCard(board, teamMembers);
                    Console.Clear();
                    break;
                case "4":
                    MoveCard(board, teamMembers);
                    Console.Clear();
                    break;
                case "5":
                    DataManager dataManager = new DataManager();
                    dataManager.SaveData(board);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış değer girdiniz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Start(board, teamMembers);
                    break;
            }

        }
        public void ListBoard(Board board, TeamMembers teamMembers)
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

            Console.Write(" İşlem Tamamlandı. \n * Ana Menüye Dönmek için bir tuşa basınız    :");
            Console.ReadKey();
            Console.Clear();
            Start(board, teamMembers);
        }

        public void AddCard(Board board, TeamMembers teamMembers)
        {
            Console.Clear();
            string title, content, size, toWho;
        Start:
            Console.WriteLine("Başlık Giriniz                                  : ");
            title = Console.ReadLine() ?? "";
            Console.WriteLine("İçerik Giriniz                                  :");
            content = Console.ReadLine() ?? "";
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            size = Console.ReadLine() ?? "";
            Console.WriteLine("Kişi Seçiniz                                    : ");
            toWho = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(content) ||
                string.IsNullOrEmpty(size) ||
                string.IsNullOrEmpty(toWho) ||
                !IsDigit(toWho) || !IsDigit(size))
            {
                Console.WriteLine("Verileri eksik veya hatalı girdiniz.");
                Thread.Sleep(1000);
                Console.Clear();
                goto Start;
            }
            var card = Cards.prio.S;
            switch (size)
            {
                case "1":
                    card = Cards.prio.XL;
                    break;
                case "2":
                    card = Cards.prio.XL;
                    break;
                case "3":
                    card = Cards.prio.XL;
                    break;
                case "4":
                    card = Cards.prio.XL;
                    break;
                case "5":
                    card = Cards.prio.XL;
                    break;
                default:
                    Console.WriteLine("Büyüklük değerini yanlış girdiniz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Start;
            }
            if (teamMembers.teamMember.Count() < Convert.ToInt32(toWho))
            {
                Console.WriteLine("Atanacak kişi değerini yanlış girdiniz");
                Thread.Sleep(1000);
                Console.Clear();
                goto Start;
            }

            int toWoo = teamMembers.teamMember.Keys.Where(x => x == Convert.ToInt32(toWho)).ToList().First();


            board.toDo.Add(new Cards(title, content, teamMembers.teamMember[toWoo + 1], card, "inProgress"));

            Console.Write(" İşlem Tamamlandı. \n * Ana Menüye Dönmek için bir tuşa basınız    :");
            Console.ReadKey();
            Console.Clear();
            Start(board, teamMembers);
        }

        public void DeleteCard(Board board, TeamMembers teamMembers)
        {
            string input;

            Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            input = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Yanlış Değer girdiniz");

            bool worked = false;
            for (int i = 0; i < board.toDo.Count(); i++)
            {
                var item = board.toDo[i];
                if (item.Title.Contains(input))
                {
                    board.toDo.Remove(item);
                    worked = true;
                }
            }
            for (int i = 0; i < board.inProgress.Count(); i++)
            {
                var item = board.inProgress[i];
                if (item.Title.Contains(input))
                {
                    board.inProgress.Remove(item);
                    worked = true;
                }
            }
            for (int i = 0; i < board.done.Count(); i++)
            {
                var item = board.done[i];
                if (item.Title.Contains(input))
                {
                    board.done.Remove(item);
                    worked = true;
                }
            }

            if (worked == false)
            {
                Console.Write("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2) ");
                input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "1":
                        Start(board, teamMembers);
                        break;
                    case "2":
                        DeleteCard(board, teamMembers);
                        break;
                    default:
                        Console.WriteLine("Yanlış tuşlama yaptınız");
                        break;
                }
            }

            Console.Write(" İşlem Tamamlandı. \n * Ana Menüye Dönmek için bir tuşa basınız    :");
            Console.ReadKey();
            Console.Clear();

            Start(board, teamMembers);
        }

        public void MoveCard(Board board, TeamMembers teamMembers)
        {
            string input, input2; int num;

            Console.Write("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            input = Console.ReadLine() ?? "";

        Start:
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
            input2 = Console.ReadLine() ?? "";

            switch (input2)
            {
                case "1":
                    num = 1;
                    break;

                case "2":
                    num = 2;
                    break;
                case "3":
                    num = 3;
                    break;
                default:
                    Console.WriteLine("Geçerli Line seçiniz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Start;
            }

            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Yanlış Değer girdiniz");

            bool worked = false;
            for (int i = 0; i < board.toDo.Count(); i++)
            {
                var item = board.toDo[i];
                if (item.Title.Contains(input))
                {
                    if (num == 1)
                    {
                        board.toDo.Add(item);
                    }
                    else if (num == 2)
                    {
                        board.inProgress.Add(item);
                    }
                    else if (num == 3)
                    {
                        board.done.Add(item);
                    }
                    board.toDo.Remove(item);
                    worked = true;
                }
            }
            for (int i = 0; i < board.inProgress.Count(); i++)
            {
                var item = board.inProgress[i];
                if (item.Title.Contains(input))
                {
                    if (num == 1)
                    {
                        board.toDo.Add(item);
                    }
                    else if (num == 2)
                    {
                        board.inProgress.Add(item);
                    }
                    else if (num == 3)
                    {
                        board.done.Add(item);
                    }
                    board.inProgress.Remove(item);
                    worked = true;
                }
            }
            for (int i = 0; i < board.done.Count(); i++)
            {
                var item = board.done[i];
                if (item.Title.Contains(input))
                {
                    if (num == 1)
                    {
                        board.toDo.Add(item);
                    }
                    else if (num == 2)
                    {
                        board.inProgress.Add(item);
                    }
                    else if (num == 3)
                    {
                        board.done.Add(item);
                    }
                    board.done.Remove(item);
                    worked = true;
                }
            }

            if (worked == false)
            {
                Console.Write("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Taşımayı sonlandırmak için : (1)\n* Yeniden denemek için : (2) ");
                input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Start(board, teamMembers);
                        break;
                    case "2":
                        Console.Clear();
                        DeleteCard(board, teamMembers);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Yanlış tuşlama yaptınız");
                        break;
                }
            }

            Console.Write(" İşlem Tamamlandı. \n * Ana Menüye Dönmek için bir tuşa basınız    :");
            Console.ReadKey();
            Console.Clear();

            Start(board, teamMembers);
        }

        bool IsDigit(string sayi)
        {
            foreach (char c in sayi)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
