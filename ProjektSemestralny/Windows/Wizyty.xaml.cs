using ProjektSemestralny.Class;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy Wizyty.xaml
    /// </summary>
    public partial class Wizyty : Window
    {
        WizytyClass dbclass = new WizytyClass();
        public Wizyty()
        {
            InitializeComponent();
            var orders = dbclass.CreateTable();
            List<WizytaView> displayItems = new List<WizytaView>();
            foreach (var order in orders)
            {
                displayItems.Add(new WizytaView(order));
            }
            this.DataTable.ItemsSource = displayItems;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataTable.Columns[0].Header = "Data";
            this.DataTable.Columns[1].Header = "Godzina";
            this.DataTable.Columns[2].Header = "Imie";
            this.DataTable.Columns[3].Header = "Nazwisko";
            this.DataTable.Columns[4].Header = "Pesel";
            this.DataTable.Columns[5].Header = "Imie";
            this.DataTable.Columns[6].Header = "Nazwisko";
            this.DataTable.Columns[7].Header = "Specjalizacja";
            this.DataTable.Width = 738;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
