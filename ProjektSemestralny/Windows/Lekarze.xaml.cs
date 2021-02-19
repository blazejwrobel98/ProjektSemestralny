using ProjektSemestralny.Class;
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
    /// Logika interakcji dla klasy Lekarze.xaml
    /// </summary>
    public partial class Lekarze : Window
    {
        LekarzeClass dbclass = new LekarzeClass();
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
                lekarz_pesel.Text = lekarz.Pesel;
                lekarz_specjalizacja.Text = lekarz.Specjalizacja;
                lekarz_pracaod.Text = lekarz.Praca_Start.ToString();
                lekarz_pracado.Text = lekarz.Praca_Stop.ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
