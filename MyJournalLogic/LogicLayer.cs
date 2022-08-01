using System.Text.Json;
using System.IO;

namespace MyJournalLogic
{
    public class LogicLayer
    {
        public List<Entry> Entries = new List<Entry>();
        private string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string fileName = "MyJournalEntries.json";


        public void AddEntry(string content, DateTime date)
        {
            if (content == null || date == null)
            {
                throw new ArgumentNullException();
            }

            Entries.Add(new Entry(content, date));
        }
        public List<Entry> GetEntries()
        {
            return Entries;
        }

        public void ModifyEntry(int index, string content, DateTime date)
        {
            if (index == null || content == null || date == null)
            {
                throw new ArgumentNullException();
            }

            Entries[index].Content = content;
            Entries[index].Date = date;

        }
        public void DeleteEntry(int index)
        {
            Entries.RemoveAt(index);
        }

        public string SaveAsJSON()
        {
            string savePath = myDocumentsPath + @"\" + fileName;
            string json = JsonSerializer.Serialize<List<Entry>>(Entries);
            File.WriteAllText(savePath, json);
            return savePath;
        }
        public string LoadJSON()
        {
            string loadPath = myDocumentsPath + @"\" + fileName;
            string jsonEntries = File.ReadAllText(loadPath);
            Entries = JsonSerializer.Deserialize<List<Entry>>(jsonEntries);
            return loadPath;
        }
        public string DeleteJSON()
        {
            string deletePath = myDocumentsPath + @"\" + fileName;
            string jsonEntries = File.ReadAllText(deletePath);
            File.Delete(deletePath);
  
            return deletePath;
        }
        public bool CheckJSON()
        {
            string jsonPath = myDocumentsPath + @"\" + fileName;
            if (File.Exists(jsonPath)) return true;
            return false;
        }
        public bool CheckChanges()
        {
            if (!CheckJSON()) return false;
            string loadPath = myDocumentsPath + @"\" + fileName;
            string jsonEntries = File.ReadAllText(loadPath);
            string entriesString = JsonSerializer.Serialize(Entries);

            if (!string.Equals(jsonEntries.Trim(), entriesString.Trim())) return true;
            
           
            return false;
            
        }
    }
}