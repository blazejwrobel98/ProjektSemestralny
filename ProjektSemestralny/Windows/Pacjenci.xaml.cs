using ProjektSemestralny.Class;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
