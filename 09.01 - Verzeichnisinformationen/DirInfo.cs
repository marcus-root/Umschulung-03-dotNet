namespace _09._01___Verzeichnisinformationen
{
    internal class DirInfo
    {
        public String Pfad { get; set; }
        public String Erstelldatum { get; set; }
        public int AnzahlDateien { get; set; }


        public override String ToString()
        {
            return $"{Pfad}\nErstelldatum: {Erstelldatum} | Dateien: {AnzahlDateien}";
        }



    }


}