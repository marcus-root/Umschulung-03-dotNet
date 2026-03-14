using Aufgaben_aus_meiner_Umschulung;

namespace AufgabenAusUmschulung
{
    internal class Program
    {
        static void Main()
        {
            PrintContact();
            PrintMenu();
            PrintVerticalText();
            PrintMurphyQuote();
            PrintFileError();
        }

        static void PrintContact()
        {
            Person p1 = new Person();
            try
            {
                p1 = new Person("Max", "Mustermann", "+49 800 123-456", "hallo@beispiel.de");
            }
            catch (Exception e) { Console.WriteLine(e); }
            Console.WriteLine(p1);
            Console.WriteLine();
        }

        static void PrintMenu()
        {
            string title = "Meine Musiktitel";
            string border = new string('*', 6);

            Console.WriteLine($"{border}{title}{border}");
            Console.WriteLine("\tN = Neuen Eintrag hinzufügen");
            Console.WriteLine("\tL = Eintrag löschen");
            Console.WriteLine("\tF = Titel finden");
            Console.WriteLine("\tA = Alle Einträge anzeigen");
            Console.WriteLine("\tB = Programm beenden");
            Console.WriteLine("Ihre Wahl:");
            Console.WriteLine();
        }

        static void PrintVerticalText()
        {
            string textTop = "Just";
            string textMiddle = "for";
            string textBottom = "Fun";

            foreach (char c in textTop)
            {
                Console.Write($"\t{c}");
                if (textTop.Last() != c) Console.WriteLine();
                else Console.Write("  ");
            }
            Console.Write(textMiddle);
            foreach (char c in textBottom)
            {
                if (textBottom.First() == c) Console.WriteLine($"  {c}");
                else Console.WriteLine($"\t\t{c}");

            }
            Console.WriteLine();
        }

        static void PrintMurphyQuote()
        {
            Console.WriteLine("\"It is impossible to make anything foolproof\"");
            Console.WriteLine("\t\t\"because fools are so ingenious (Murphy).\"");
            Console.WriteLine();
        }

        static void PrintFileError()
        {
            string filePath = @"C:\Docs\Sprueche.doc";
            Console.WriteLine($"Datei nicht gefunden: \"{filePath}\"");
        }
    }
}