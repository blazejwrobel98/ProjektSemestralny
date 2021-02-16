using System;
using System.Collections.Generic;
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
            this.DataTable.ItemsSource = dbclass.CreateTable();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataTable.Columns[0].Visibility = Visibility.Collapsed;
            this.DataTable.Columns[1].Header = "Imię";
            this.DataTable.Columns[2].Header = "Nazwisko";
            this.DataTable.Columns[4].Header = "Kod";
            this.DataTable.Columns[5].Header = "Miejscowość";
            this.DataTable.Columns[9].Header = "Choroby";
            this.DataTable.Columns[10].Header = "Wizyty";
            var counter = this.DataTable.Columns.Count();
            this.DataTable.Columns[counter - 1].Visibility = Visibility.Collapsed;
            this.DataTable.Columns[counter - 2].Visibility = Visibility.Collapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
