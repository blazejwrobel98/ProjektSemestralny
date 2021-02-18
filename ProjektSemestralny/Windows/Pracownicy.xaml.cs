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
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Window
    {
        PracownicyClass dbclass = new PracownicyClass();
        public Pracownicy()
        {
            InitializeComponent();
            var workers = dbclass.CreateTable();
            List<PracownikView> displayItems = new List<PracownikView>();
            foreach (var worker in workers)
            {
                displayItems.Add(new PracownikView(worker));
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
