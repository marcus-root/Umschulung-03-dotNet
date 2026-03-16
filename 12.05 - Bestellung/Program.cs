using System.Text.Json;
using System.Linq;

namespace _12._05___Bestellung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var artikelString = File.ReadAllText(@"..\..\..\alleArtikel.json");
            var bestellungString = File.ReadAllText(@"..\..\..\bestellung.json");

            Bestellung bestellung = JsonSerializer.Deserialize<Bestellung>(bestellungString);
            List<Bestellposition> positionen = bestellung.AllePositionen;
            List<Artikel> artikel = JsonSerializer.Deserialize<List<Artikel>>(artikelString);

            var query = positionen.Join(artikel, p => p.Artikelnummer, a => a.Artikelnummer, (p1, a1) => new { Nr = p1.Artikelnummer, Name = a1.Name, Anzahl = p1.Anzahl, Summe = $"{a1.Preis * p1.Anzahl:C2}" }).OrderBy(query => query.Nr);

            Console.WriteLine($"| {"Nr.",-4} | {"Name",-40} | {"Anzahl",-6} | {"Summe",10} |");
            foreach (var q in query)
            {
                Console.WriteLine($"| {q.Nr,-4} | {q.Name,-40} | {q.Anzahl,-6} | {q.Summe,10} |");
            }
        }
    }
}
