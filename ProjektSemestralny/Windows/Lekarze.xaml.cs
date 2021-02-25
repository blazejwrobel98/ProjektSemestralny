using ProjektSemestralny.Class;
using ProjektSemestralny.Windows;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logika interakcji dla klasy Lekarze.xaml
    /// </summary>
    public partial class Lekarze : Page
    {
        LekarzeClass dbclass = new LekarzeClass();
        Functions functions = new Functions();
        public Lekarze()
        {
            InitializeComponent();
            Load_Table();
        }
        private void Load_Table()
        {
            var doctors = dbclass.CreateTable();
            List<LekarzView> displayItems = new List<LekarzView>();
            foreach (var doctor in doctors)
            {
                displayItems.Add(new LekarzView(doctor));
            }
            this.DataTable.ItemsSource = displayItems;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Mouse_Click(object sender, MouseButtonEventArgs e)
        {
            foreach (LekarzView lekarz in DataTable.SelectedItems)
            {
                lekarz_imie.Text = lekarz.Imie;
                lekarz_nazwisko.Text = lekarz.Nazwisko;
                lekarz_pesel.IsReadOnly = true;
                lekarz_pesel.Text = lekarz.Pesel;
                lekarz_specjalizacja.Text = lekarz.Specjalizacja;
                lekarz_pracaod.Text = lekarz.Praca_Start.ToString();
                lekarz_pracado.Text = lekarz.Praca_Stop.ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new MainPanel());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pracownik pracownik = new Pracownik();
            pracownik.Imie = lekarz_imie.Text;
            pracownik.Nazwisko = lekarz_nazwisko.Text;
            pracownik.Pesel = lekarz_pesel.Text;
            pracownik.Specjalizacja = lekarz_specjalizacja.Text;
            pracownik.Pracuje_Od = int.Parse(lekarz_pracaod.Text);
            pracownik.Pracuje_Do = int.Parse(lekarz_pracado.Text);
            dbclass.ChangeLekarzValue(pracownik);
            Load_Table();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (LekarzView lekarzView in DataTable.SelectedItems)
            {
                Pracownik pracownik = new Pracownik();
                pracownik.Pesel = lekarzView.Pesel.ToString();
                dbclass.DeleteLekarz(pracownik);
            }
            lekarz_imie.Text = "";
            lekarz_nazwisko.Text = "";
            lekarz_pesel.Text = "";
            lekarz_specjalizacja.Text = "";
            lekarz_pracaod.Text = "";
            lekarz_pracado.Text = "";
            Load_Table();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    Pracownik pracownik = new Pracownik();
                    pracownik.Imie = lekarz_imie.Text;
                    pracownik.Nazwisko = lekarz_nazwisko.Text;
                    pracownik.Pesel = lekarz_pesel.Text;
                    pracownik.Specjalizacja = lekarz_specjalizacja.Text;
                    pracownik.Pracuje_Od = int.Parse(lekarz_pracaod.Text);
                    pracownik.Pracuje_Do = int.Parse(lekarz_pracado.Text);
                    pracownik.Stanowisko = "Lekarz";
                    if (dbclass.AddLekarz(pracownik)) ClearInputs();
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool ValidateInputs()
        {
            bool state = true;
            var alerts = new List<string>();

            if(lekarz_imie.Text.Length < 2)
            {
                alerts.Add("Imie : Za mało znaków");
                state = false;
            }

            if(lekarz_nazwisko.Text.Length < 2)
            {
                alerts.Add("Nazwisko : Za mało znaków");
                state = false;
            }

            if (lekarz_pesel.Text.Length < 11)
            {
                alerts.Add("Pesel : Za mało znaków");
                state = false;
            }

            if(lekarz_specjalizacja.Text.Length < 2)
            {
                alerts.Add("Specjalizacja : Za mało znaków");
                state = false;
            }

            if(lekarz_pracaod.Text.Length < 1)
            {
                alerts.Add("Praca od : Za mało znaków");
                state = false;
            }
            if(lekarz_pracado.Text.Length < 1)
            {
                alerts.Add("Praca do : Za mało znaków");
                state = false;
            }
            if (!state) functions.AlertBox(alerts);
            return state;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            lekarz_imie.Text = "";
            lekarz_nazwisko.Text = "";
            lekarz_pesel.Text = "";
            lekarz_pesel.IsReadOnly = false;
            lekarz_specjalizacja.Text = "";
            lekarz_pracaod.Text = "";
            lekarz_pracado.Text = "";
            AlertLabel.Content = "";
            Load_Table();
        }
    }
}
