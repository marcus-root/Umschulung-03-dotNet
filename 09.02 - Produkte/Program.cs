using System.Text.Json;

namespace _09._02___Produkte
{
    internal class Program
    {
        static String jsonPath;
        static String jsonString;
        static Category[] kategorien;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            jsonPath = @"..\..\..\Produkte.json";
            JsonNeuLaden();
            Menu menu = new Menu(kategorien, 2, 25);
            menu.PrintStaticText();
            while (true)
            {
                menu.PromptUser();
            }
        }

        static private void JsonNeuLaden()
        {
            jsonString = File.ReadAllText(jsonPath);
            kategorien = JsonSerializer.Deserialize<Category[]>(jsonString);
        }
    }
}

