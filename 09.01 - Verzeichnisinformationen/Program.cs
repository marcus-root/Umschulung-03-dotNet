using System.Text.Json;

namespace _09._01___Verzeichnisinformationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String suchpfad = @"C:\Windows";
            String jsonPfad = @"..\..\..\windows.json";
            int tiefe = 0;

            List<DirInfo> dirInfoList = new List<DirInfo>(); // die Liste die erzeugt wird
            List<DirInfo> dirInfoListRead; // die Liste die von der JSON-Datei eingelesen wird

            // Aufruf der rekursiven Funktion, die die Liste mit Objekten füllt
            Search(suchpfad, dirInfoList, tiefe);
            //Search(suchpfad, dirInfoList);

            // Speichern der Liste in einer json Datei
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            File.WriteAllText(jsonPfad, JsonSerializer.Serialize(dirInfoList, opt));

            // Json Datei einlesen
            dirInfoListRead = JsonSerializer.Deserialize<List<DirInfo>>(File.ReadAllText(jsonPfad)).ToList();

            // Ausgeben der Objekte
            foreach (DirInfo d in dirInfoListRead)
            {
                Console.WriteLine($"{d}\n");
            }
        }

        // Funktion die die Ordnerinformationen abruft und die Liste füllt
        static void Search(String pfad, List<DirInfo> dirs)
        {
            String[] currentDirsStrings = Directory.GetDirectories(pfad);
            DirInfo[] currentDirs = new DirInfo[currentDirsStrings.Length];
            for (int i = 0; i < currentDirs.Length; i++)
            {
                currentDirs[i] = new DirInfo() { Pfad = currentDirsStrings[i], AnzahlDateien = 0 };
            }
            foreach (DirInfo d in currentDirs)
            {
                d.Erstelldatum = Directory.GetCreationTime(d.Pfad).ToShortDateString();
                if (CanAccessFolder(d.Pfad)) d.AnzahlDateien = Directory.GetFiles(d.Pfad).Length;
                dirs.Add(d);
            }
        }

        // Überladung: Rekursive Funktion die die Ordnerinformationen abruft und die Liste füllt
        static void Search(String pfad, List<DirInfo> dirs, int tiefe)
        {
            if (tiefe < 0) return;
            String[] currentDirsStrings = Directory.GetDirectories(pfad);
            DirInfo[] currentDirs = new DirInfo[currentDirsStrings.Length];
            for (int i = 0; i < currentDirs.Length; i++)
            {
                currentDirs[i] = new DirInfo() { Pfad = currentDirsStrings[i], AnzahlDateien = 0 };
            }
            foreach (DirInfo d in currentDirs)
            {
                d.Erstelldatum = Directory.GetCreationTime(d.Pfad).ToShortDateString();
                if (CanAccessFolder(d.Pfad)) d.AnzahlDateien = Directory.GetFiles(d.Pfad).Length;
                dirs.Add(d);
                if (CanAccessFolder(d.Pfad)) Search(d.Pfad, dirs, tiefe - 1);
            }
        }

        static bool CanAccessFolder(string folderPath)
        {
            try
            {
                Directory.GetDirectories(folderPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false; // Zugriff verweigert
            }
        }
    }
}