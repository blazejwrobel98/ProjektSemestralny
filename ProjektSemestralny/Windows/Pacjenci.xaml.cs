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
    /// Logika interakcji dla klasy Pacjenci.xaml
    /// </summary>
    public partial class Pacjenci : Page
    {
        PacjenciClass dbclass = new PacjenciClass();
        Functions functions = new Functions();
        /// <summary>
        /// Wczytanie Panelu
        /// </summary>
        public Pacjenci()
        {
            InitializeComponent();
            Load_Table();
        }
        /// <summary>
        /// Załadowanie danych do tabeli
        /// </summary>
        public void Load_Table()
        {
            var patients = dbclass.CreateTable();
            List<PacjentView> displayItems = new List<PacjentView>();
            foreach (var patient in patients)
            {
                displayItems.Add(new PacjentView(patient));
            }
            this.DataTable.ItemsSource = displayItems;
        }
        /// <summary>
        /// Wpisanie danych z zaznaczonego rekordu do TextBox-ów po double clicku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Click(object sender, MouseButtonEventArgs e)
        {
            foreach (PacjentView pacjent in DataTable.SelectedItems)
            {
                Input_Imie.Text = pacjent.Imie.ToString();
                Input_Nazwisko.Text = pacjent.Nazwisko.ToString();
                Input_Pesel.Text = pacjent.Pesel.ToString();
                Input_Pesel.IsReadOnly = true;
                Input_KodPocztowy.Text = pacjent.Kod_Pocztowy.ToString();
                Input_Miejscowosc.Text = pacjent.Miejscowosc.ToString();
                Input_Ulica.Text = pacjent.Ulica.ToString();
                Input_NrDomu.Text = pacjent.Nr_Domu.ToString();
                Input_NrLokalu.Text = pacjent.Nr_Lokalu.ToString();
            }
        }
        /// <summary>
        /// Wywołanie zmiany wartości w tabeli Pacjent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pacjent pacjent = new Pacjent();
            pacjent.Imie = Input_Imie.Text;
            pacjent.Nazwisko = Input_Nazwisko.Text;
            pacjent.Pesel = Input_Pesel.Text;
            pacjent.Kod_Pocztowy = Input_KodPocztowy.Text;
            pacjent.Miejscowosc = Input_Miejscowosc.Text;
            pacjent.Ulica = Input_Ulica.Text;
            pacjent.Nr_Domu = Input_NrDomu.Text;
            pacjent.Nr_Lokalu = Input_NrLokalu.Text;
            if (ValidateInputs())
            {
                dbclass.ChangePatientValue(pacjent);
                Load_Table();
            }
        }
        /// <summary>
        /// Wywołanie usunięcia rekordu z tabeli Pacjent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (PacjentView pacjentview in DataTable.SelectedItems)
            {
                Pacjent pacjent = new Pacjent();
                pacjent.Pesel = pacjentview.Pesel.ToString();
                dbclass.DeletePatient(pacjent);
            }
            ClearInputs();
        }
        /// <summary>
        /// Dodanie nowego pacjenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    Pacjent pacjent = new Pacjent();
                    pacjent.Imie = Input_Imie.Text;
                    pacjent.Nazwisko = Input_Nazwisko.Text;
                    pacjent.Pesel = Input_Pesel.Text;
                    pacjent.Kod_Pocztowy = Input_KodPocztowy.Text;
                    pacjent.Miejscowosc = Input_Miejscowosc.Text;
                    pacjent.Ulica = Input_Ulica.Text;
                    pacjent.Nr_Domu = Input_NrDomu.Text;
                    pacjent.Nr_Lokalu = Input_NrLokalu.Text;
                    if (dbclass.AddPatient(pacjent)) ClearInputs();

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
        /// <summary>
        /// Czyszczenie zawartości TextBox-ów
        /// </summary>
        private void ClearInputs()
        {
            Input_Imie.Text = "";
            Input_Nazwisko.Text = "";
            Input_Pesel.Text = "";
            Input_Pesel.IsReadOnly = false;
            Input_KodPocztowy.Text = "";
            Input_Miejscowosc.Text = "";
            Input_Ulica.Text = "";
            Input_NrDomu.Text = "";
            Input_NrLokalu.Text = "";
            AlertLabel.Content = "";
            Load_Table();
        }
        /// <summary>
        /// Walidowanie zawartości TextBox-ów
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputs()
        {
            bool state = true;
            var alerts = new List<string>();
            if (Input_Imie.Text.Length < 2)
            {
                alerts.Add("Imie : Za mało znaków");
                state = false;
            }

            if (Input_Nazwisko.Text.Length < 2)
            {
                alerts.Add("Nazwisko : Za mało znaków");
                state = false;
            }

            if (Input_Pesel.Text.Length < 11)
            {
                alerts.Add("Pesel : Za mało znaków");
                state = false;
            }

            if (Input_KodPocztowy.Text.Length < 6)
            {
                alerts.Add("Kod pocztowy : Za mało znaków");
                state = false;
            }

            if (Input_Miejscowosc.Text.Length < 2)
            {
                alerts.Add("Miejscowość : Za mało znaków");
                state = false;
            }

            if (Input_NrDomu.Text.Length < 1)
            {
                alerts.Add("Nr domu : Za mało znaków");
                state = false;
            }
            if (!state) functions.AlertBox(alerts);
            return state;
        }
        /// <summary>
        /// Walidacja TextBox-ów pod Int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Walidacja TextBox-ów pod Kod pocztowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostCodeValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^-0-9]+");
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
        private void Button_Click_4(object sender, RoutedEventArgs e) => ClearInputs();
    }
}
