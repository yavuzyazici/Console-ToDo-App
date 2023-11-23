using Console_ToDo_App;


TeamMembers team = new TeamMembers();
team.teamMember.Add(1, "Yavuz Selim Yazıcı");
team.teamMember.Add(2, "Suat Kandemir");
team.teamMember.Add(3, "Muhammed Fatih Yazıcı");
team.teamMember.Add(4, "Jim Kwik");
team.teamMember.Add(5, "Robert Kiyosaki");

Board board = new Board();
board.toDo.Add(new Cards("Yarın Atalay Amcaya Uğra", "Kapının ölcüleri alınacak", team.teamMember[1], Cards.prio.XL, "toDo"));


board.inProgress.Add(new Cards("Patika.dev 2 ders C# izlenicek", "Patika.dev 2 ders C# izlenicek", team.teamMember[1], Cards.prio.S, "inProgress"));
board.inProgress.Add(new Cards("ToDo App Yapılacak", "ToDo App Yapılacak", team.teamMember[1], Cards.prio.M, "inProgress"));


board.done.Add(new Cards("Yarın Okul Çıkışı Bir Yere Uğra", "Ayhan Tesisata Uğranılacak", team.teamMember[1], Cards.prio.XL, "done"));
board.done.Add(new Cards("Telefon Rehber App Yap", "Telefon Rehber App Yap ve GitHub'da yayınla", team.teamMember[1], Cards.prio.XL, "done"));

Start();

void Start()
{
    string input;
    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :\n*******************************************\n(1) Board Listelemek (2) Board'a Kart Eklemek (3) Board'dan Kart Silmek (4) Kart Taşımak");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            board.ListBoard(board);
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


