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
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Window
    {
        PracownicyClass dbclass = new PracownicyClass();
        public Pracownicy()
        {
            InitializeComponent();
            this.DataTable.ItemsSource = dbclass.CreateTable();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataTable.Columns[0].Visibility = Visibility.Collapsed;
            this.DataTable.Columns[5].Visibility = Visibility.Collapsed;
            this.DataTable.Columns[1].Header = "Imię";
            this.DataTable.Columns[2].Header = "Nazwisko";
            var counter = this.DataTable.Columns.Count();
            this.DataTable.Columns[counter-1].Visibility = Visibility.Collapsed;
            this.DataTable.Columns[counter-2].Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
