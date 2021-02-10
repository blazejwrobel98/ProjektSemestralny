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
        Database1Entities db = new Database1Entities();
        public Pacjenci()
        {
            InitializeComponent();
            this.Pacjenci_table.ItemsSource = db.Pacjent.ToList();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Pacjenci_table.Columns[0].Visibility = Visibility.Collapsed;
            this.Pacjenci_table.Columns[1].Header = "Imię";
            this.Pacjenci_table.Columns[2].Header = "Nazwisko";
            this.Pacjenci_table.Columns[4].Header = "Kod";
            this.Pacjenci_table.Columns[5].Header = "Miejscowość";
            this.Pacjenci_table.Columns[9].Header = "Choroby";
            this.Pacjenci_table.Columns[10].Header = "Wizyty";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
