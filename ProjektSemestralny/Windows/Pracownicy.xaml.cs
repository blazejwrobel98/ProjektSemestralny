using ProjektSemestralny.Class;
using ProjektSemestralny.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Page
    {
        PracownicyClass dbclass = new PracownicyClass();
        public Pracownicy()
        {
            InitializeComponent();
            Load_Table();
        }
        /// <summary>
        /// Generowanie tabeli głównej
        /// </summary>
        private void Load_Table()
        {
            var workers = dbclass.CreateTable();
            List<PracownikView> displayItems = new List<PracownikView>();
            foreach (var worker in workers)
            {
                displayItems.Add(new PracownikView(worker));
            }
            this.DataTable.ItemsSource = displayItems;
            if (this.DataTable.IsLoaded) Table_Style();
        }
        /// <summary>
        /// Zmiana nagłówka kolumny
        /// </summary>
        private void Table_Style()
        {
            this.DataTable.Columns[4].Header = "Praca OD";
            this.DataTable.Columns[5].Header = "Praca DO";
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Table_Style();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new MainPanel());
        }
        /// <summary>
        /// Wpisanie wartości z klikniętego podwójnie wiersza w do TexBoxów umożliwiających edycję
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Click(object sender, MouseButtonEventArgs e)
        {
            foreach (PracownikView pracownik in DataTable.SelectedItems)
            {
                pracownik_imie.Text = pracownik.Imie;
                pracownik_nazwisko.Text = pracownik.Nazwisko;
                pracownik_pesel.Text = pracownik.Pesel;
                pracownik_stanowisko.Text = pracownik.Stanowisko;
                pracownik_pracaod.Text = pracownik.Praca_Start.ToString();
                pracownik_pracado.Text = pracownik.Praca_Stop.ToString();
            }
        }
        /// <summary>
        /// Zmiana danych pracownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pracownik pracownik = new Pracownik();
            pracownik.Imie = pracownik_imie.Text;
            pracownik.Nazwisko = pracownik_nazwisko.Text;
            pracownik.Pesel = pracownik_pesel.Text;
            pracownik.Stanowisko = pracownik_stanowisko.Text;
            pracownik.Pracuje_Od = int.Parse(pracownik_pracaod.Text);
            pracownik.Pracuje_Do = int.Parse(pracownik_pracado.Text);
            dbclass.ChangePracownikValue(pracownik);
            Load_Table();
        }
        /// <summary>
        /// Usunięcie pracownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (PracownikView pracownikView in DataTable.SelectedItems)
            {
                Pracownik pracownik = new Pracownik();
                pracownik.Pesel = pracownikView.Pesel.ToString();
                dbclass.DeletePracownik(pracownik);
            }
            pracownik_imie.Text = "";
            pracownik_nazwisko.Text = "";
            pracownik_pesel.Text = "";
            pracownik_stanowisko.Text = "";
            pracownik_pracaod.Text = "";
            pracownik_pracado.Text = "";
            Load_Table();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            pracownik_imie.Text = "";
            pracownik_nazwisko.Text = "";
            pracownik_pesel.Text = "";
            pracownik_pesel.IsReadOnly = false;
            pracownik_stanowisko.Text = "";
            pracownik_pracaod.Text = "";
            pracownik_pracado.Text = "";
            AlertLabel.Content = "";
            Load_Table();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
