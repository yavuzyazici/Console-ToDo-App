using Newtonsoft.Json;
using System;
using System.IO;

namespace Console_ToDo_App
{
    public class DataManager
    {
        public void SaveData(Board board)
        {
            string json = JsonConvert.SerializeObject(board);

            // JSON'u bir dosyaya kaydetme
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\data.json";
            File.WriteAllText(path, json);
        }

        public Board LoadData()
        {
            // JSON'u dosyadan okuma
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\data.json";
            string json = File.ReadAllText(path);

            // JSON'u Board objesine dönüştürme
            Board board = JsonConvert.DeserializeObject<Board>(json);

            return board;
        }
    }
}
