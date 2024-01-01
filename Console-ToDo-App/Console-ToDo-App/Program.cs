using Console_ToDo_App;

Console.SetWindowSize(108, 50);

TeamMembers team = new TeamMembers();
team.teamMember.Add(1, "Yavuz Selim Yazıcı");
team.teamMember.Add(2, "Suat Kandemir");
team.teamMember.Add(3, "Muhammed Fatih Yazıcı");
team.teamMember.Add(4, "Jim Kwik");
team.teamMember.Add(5, "Robert Kiyosaki");

DataManager dataManager = new DataManager();
string path = AppDomain.CurrentDomain.BaseDirectory + "\\data.json";
Board board;
if (File.Exists(path))
{
    board = dataManager.LoadData();
}
else
{
    board = new Board();
    board.inProgress.Add(new Cards("Patika.dev 2 ders C# izlenicek", "Patika.dev 2 ders C# izlenicek", team.teamMember[1], Cards.prio.S, "inProgress"));
    board.inProgress.Add(new Cards("ToDo App Yapılacak", "ToDo App Yapılacak", team.teamMember[1], Cards.prio.M, "inProgress"));
    board.done.Add(new Cards("Yarın Okul Çıkışı Bir Yere Uğra", "Ayhan Tesisata Uğranılacak", team.teamMember[1], Cards.prio.XL, "done"));
    board.done.Add(new Cards("Telefon Rehber App Yap", "Telefon Rehber App Yap ve GitHub'da yayınla", team.teamMember[1], Cards.prio.XL, "done"));
}


board.Start(board,team);




