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
        PracownicyClass Pclass = new PracownicyClass();
        public Pracownicy()
        {
            InitializeComponent();
            this.Pracownicy_table.ItemsSource = Pclass.CreateTable();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Pracownicy_table.Columns[0].Visibility = Visibility.Collapsed;
            this.Pracownicy_table.Columns[1].Header = "Imię";
            this.Pracownicy_table.Columns[2].Header = "Nazwisko";
            var counter = this.Pracownicy_table.Columns.Count();
            this.Pracownicy_table.Columns[counter-1].Visibility = Visibility.Collapsed;
            this.Pracownicy_table.Columns[counter-2].Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
