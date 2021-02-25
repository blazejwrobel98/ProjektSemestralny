using ProjektSemestralny.Class;
using ProjektSemestralny.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy Wizyty.xaml
    /// </summary>
    public partial class Wizyty : Page
    {
        /// <summary>
        /// Wczytanie Panelu
        /// </summary>
        WizytyClass dbclass = new WizytyClass();
        public Wizyty()
        {
            InitializeComponent();
            LoadTable();
        }
        /// <summary>
        /// Pobranie danych do tabeli DataTable
        /// </summary>
        private void LoadTable()
        {
            var meets = dbclass.CreateTable();
            List<WizytaView> displayItems = new List<WizytaView>();
            foreach (var meet in meets)
            {
                displayItems.Add(new WizytaView(meet));
            }
            this.DataTable.ItemsSource = displayItems;
            if (DataTable.IsLoaded) ColumnStyle();
        }
        /// <summary>
        /// Wpisanie danych z zaznaczonego rekordu do TextBox-ów po double click-u
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Click(object sender, MouseButtonEventArgs e)
        {
            foreach (WizytaView wizyta in DataTable.SelectedItems)
            {
                wizyta_data.Text = wizyta.wizyta_data.ToString();
                wizyta_godzina.Text = wizyta.wizyta_godzina.ToString();
                wizyta_pacjent_imie.Text = wizyta.pacjent_imie;
                wizyta_pacjent_nazwisko.Text = wizyta.pacjent_nazwisko;
                wizyta_pacjent_pesel.Text = wizyta.pacjent_pesel;
                wizyta_lekarz_imie.Text = wizyta.lekarz_imie;
                wizyta_lekarz_nazwisko.Text = wizyta.lekarz_nazwisko;
                wizyta_lekarz_specjalizacja.Text = wizyta.lekarz_specjalizacja;
            }
        }
        /// <summary>
        /// Usuwanie zaznaczonego rekordu i czyszczenie TextBox-ów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (WizytaView wizytaview in DataTable.SelectedItems)
            {
                Wizyta wizyta = new Wizyta();
                wizyta.WizytaID = wizytaview.wizyta_id;
                dbclass.DeleteRow(wizyta);
                wizyta_data.Text = "";
                wizyta_godzina.Text = "";
                wizyta_pacjent_imie.Text = "";
                wizyta_pacjent_nazwisko.Text = "";
                wizyta_pacjent_pesel.Text = "";
                wizyta_lekarz_imie.Text = "";
                wizyta_lekarz_nazwisko.Text = "";
                wizyta_lekarz_specjalizacja.Text = "";
            }
            LoadTable();
        }
        /// <summary>
        /// Przypisanie niestandardowych nagłówek kolumn
        /// </summary>
        private void ColumnStyle()
        {
            this.DataTable.Columns[0].Visibility = Visibility.Collapsed;
            this.DataTable.Columns[1].Header = "Data";
            this.DataTable.Columns[2].Header = "Godzina";
            this.DataTable.Columns[3].Header = "Imie";
            this.DataTable.Columns[4].Header = "Nazwisko";
            this.DataTable.Columns[5].Header = "Pesel";
            this.DataTable.Columns[6].Header = "Imie";
            this.DataTable.Columns[7].Header = "Nazwisko";
            this.DataTable.Columns[8].Header = "Specjalizacja";
        }
        /// <summary>
        /// Wywołanie Stylowania kolumn po wczytaniu okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e) => ColumnStyle();
        /// <summary>
        /// Nawigacja do MainPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new MainPanel());
        /// <summary>
        /// Nawigacja do AddWizyta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new AddWizyta());
    }
}
