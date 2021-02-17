﻿using ProjektSemestralny.Class;
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
    /// Logika interakcji dla klasy Wizyty.xaml
    /// </summary>
    public partial class Wizyty : Window
    {
        WizytyClass dbclass = new WizytyClass();
        public Wizyty()
        {
            InitializeComponent();
            this.DataTable.ItemsSource = dbclass.CreateTable();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var counter = this.DataTable.Columns.Count();
            //this.DataTable.Columns[0].Visibility = Visibility.Collapsed;
            //this.DataTable.Columns[counter - 1].Visibility = Visibility.Collapsed;
            //this.DataTable.Columns[counter - 2].Visibility = Visibility.Collapsed;

        }
        private void ExpanderGenerator(object sender, RoutedEventArgs e)
        {
            var curItem = ((DataGridRow)DataTable.ContainerFromElement((Button)sender));
            DataTable.SelectedItem = (DataGridRow)curItem;
            var RowID = DataTable.SelectedIndex;
            var ColumnID = 1;
            TextBlock x = (TextBlock)DataTable.Columns[ColumnID].GetCellContent(DataTable.Items[RowID]);
            int PacjentID = int.Parse(x.Text);
            MessageBox.Show(dbclass.GetPacjent(PacjentID));
            //this.ExpandTable.ItemsSource = dbclass.GetPacjent(PacjentID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
