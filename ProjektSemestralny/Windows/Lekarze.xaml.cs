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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
