using ProjektSemestralny.Class;
using ProjektSemestralny.Windows;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Page
    {
        Functions functions = new Functions();
        PracownicyClass dbclass = new PracownicyClass();
        /// <summary>
        /// Załadowanie Panelu
        /// </summary>
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
            if (ValidateInputs())
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
            ClearInputs();
        }
        /// <summary>
        /// Czyszczenie zawartości TextBox-ów
        /// </summary>
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
        /// <summary>
        /// Walidacja TextBox pod Int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Walidacja TextBox-ów pod tekst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Walidacja danych w TextBox-ach
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputs()
        {
            bool state = true;
            var alerts = new List<string>();

            if (pracownik_imie.Text.Length < 2)
            {
                alerts.Add("Imie : Za mało znaków");
                state = false;
            }

            if (pracownik_nazwisko.Text.Length < 2)
            {
                alerts.Add("Nazwisko : Za mało znaków");
                state = false;
            }

            if (pracownik_pesel.Text.Length < 11)
            {
                alerts.Add("Pesel : Za mało znaków");
                state = false;
            }

            if (pracownik_stanowisko.Text.Length < 2)
            {
                alerts.Add("Stanowisko : Za mało znaków");
                state = false;
            }

            if (pracownik_pracaod.Text.Length < 1)
            {
                alerts.Add("Praca od : Za mało znaków");
                state = false;
            }
            else
            {
                if (int.Parse(pracownik_pracaod.Text) < 8 || int.Parse(pracownik_pracaod.Text) > 20)
                {
                    alerts.Add("Praca od : Poprawny zakres pomiędzy 8 i 20");
                    state = false;
                }
            }
            if (pracownik_pracado.Text.Length < 1)
            {
                alerts.Add("Praca do : Za mało znaków");
                state = false;
            }
            else
            {
                if (int.Parse(pracownik_pracado.Text) < int.Parse(pracownik_pracaod.Text))
                {
                    alerts.Add("Praca do : Nie może być mniejsze niż Praca od");
                    state = false;
                }
                if (int.Parse(pracownik_pracado.Text) < 8 || int.Parse(pracownik_pracado.Text) > 20)
                {
                    alerts.Add("Praca do : Poprawny zakres pomiędzy 8 i 20");
                    state = false;
                }
            }
            if (pracownik_stanowisko.Text.ToLower() == "lekarz")
            {
                alerts.Add("Stanowisko : Dodawanie lekarzy jest w innym formularzu");
                state = false;
            }
            if (!state) functions.AlertBox(alerts);
            return state;
        }
        /// <summary>
        /// Wywołanie stylowania po wczytaniu panelu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e) => Table_Style();
        /// <summary>
        /// Nawigacja do MainPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new MainPanel());
        /// <summary>
        /// Wywołanie czyszczenia TextBox-ów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e) => ClearInputs();
        /// <summary>
        /// Dodawanie nowego Pracownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    Pracownik pracownik = new Pracownik();
                    pracownik.Imie = pracownik_imie.Text;
                    pracownik.Nazwisko = pracownik_nazwisko.Text;
                    pracownik.Pesel = pracownik_pesel.Text;
                    pracownik.Stanowisko = pracownik_stanowisko.Text;
                    pracownik.Pracuje_Od = int.Parse(pracownik_pracaod.Text);
                    pracownik.Pracuje_Do = int.Parse(pracownik_pracado.Text);
                    pracownik.Stanowisko = "Lekarz";
                    if (dbclass.AddWorker(pracownik)) ClearInputs();
                }
                catch (Exception ex)
                {
                    AlertLabel.Content = ex.Message.ToString();
                }
                finally
                {
                    Load_Table();
                }
            }
        }
    }
}
