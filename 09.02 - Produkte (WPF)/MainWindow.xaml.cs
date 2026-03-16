using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace _09._02___Produkte__WPF_
{
    public partial class MainWindow : Window
    {
        String jsonPath;
        String jsonString;
        Category[] kategorien;

        public MainWindow()
        {
            jsonPath = @"..\..\..\Produkte.json";
            InitializeComponent();
            JsonNeuLaden();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KategorieWahl(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            for (int i=0; i<kategorien.Length; i++)
            {
                if (e.AddedItems[0].Equals(kategorien[i])) ProdukteAnzeigen(kategorien[i]);
            }
        }

        private void ProdukteAnzeigen(Category kat)
        {
            if (kat != null) listBoxProdukte.ItemsSource = kat.GetProductNames();
            else listBoxProdukte.ItemsSource = null;
        }

        private void Produktwahl(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) NameUndPreisAnzeigen("", "");
            else
            {
                for (int i = 0; i < kategorien.Length; i++)
                {
                    for (int k = 0; k < kategorien[i].Products.Count; k++)
                    {
                        if (e.AddedItems[0].Equals(kategorien[i].Products[k].Name)) NameUndPreisAnzeigen(kategorien[i].GetProductNames()[k], $"{kategorien[i].GetProductPrices()[k]:C2}");
                    }
                }
            }
            
        }

        private void NameUndPreisAnzeigen(String name, String preis)
        {
            textBoxProduktname.Text = name;
            textBoxPreis.Text = preis;
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            JsonNeuLaden();
        }

        private void JsonNeuLaden()
        {
            jsonString = File.ReadAllText(jsonPath);
            kategorien = JsonSerializer.Deserialize<Category[]>(jsonString);

            comboBoxKategorie.ItemsSource = kategorien;
            comboBoxKategorie.DisplayMemberPath = "CategoryName";

            ProdukteAnzeigen(null);
        }
    }
}