using ProjektSemestralny.Class;
using ProjektSemestralny.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Logika interakcji dla klasy Pacjenci.xaml
    /// </summary>
    public partial class Pacjenci : Window
    {
        PacjenciClass dbclass = new PacjenciClass();
        public Pacjenci()
        {
            InitializeComponent();
            Load_Table();
        }
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
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            dbclass.ChangePatientValue(pacjent);
            Load_Table();
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
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
            try
            {
                dbclass.AddPatient(pacjent);
            }
            finally
            {
                ClearInputs();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }
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
            Load_Table();
        }
    }
}
