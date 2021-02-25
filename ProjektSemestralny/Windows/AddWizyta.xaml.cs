using ProjektSemestralny.Class;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjektSemestralny.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddWizyta.xaml
    /// </summary>
    public partial class AddWizyta : Page
    {
        PacjenciClass pacjenciClass = new PacjenciClass();
        LekarzeClass lekarzeClass = new LekarzeClass();
        WizytyClass wizytyClass = new WizytyClass();
        List<Grid> forms = new List<Grid>();
        Wizyta wizyta = new Wizyta();
        /// <summary>
        /// Wczytanie Panelu
        /// </summary>
        public AddWizyta()
        {
            forms.Add(PacjentGrid);
            forms.Add(LekarzGrid);
            forms.Add(DataGrid);
            forms.Add(GodzinaGrid);
            InitializeComponent();
            LoadGrid();
        }
        /// <summary>
        /// Wczytanie danych do tabel
        /// </summary>
        private void LoadGrid()
        {
            var patients = pacjenciClass.CreateTable();
            List<PacjentView> pacjentViews = new List<PacjentView>();
            foreach (var patient in patients)
            {
                pacjentViews.Add(new PacjentView(patient));
            }
            this.PacjentTable.ItemsSource = pacjentViews;
            ChangeVisibility(1);

            var lekarze = lekarzeClass.CreateTable();
            List<LekarzView> lekarzViews = new List<LekarzView>();
            foreach (var lekarz in lekarze)
            {
                lekarzViews.Add(new LekarzView(lekarz));
            }
            this.LekarzTable.ItemsSource = lekarzViews;
        }
        /// <summary>
        /// Zmiana widoczności paneli
        /// </summary>
        /// <param name="grid"></param>
        private void ChangeVisibility(int grid)
        {
            switch (grid)
            {
                case 1:
                    this.PacjentGrid.Visibility = Visibility.Visible;
                    this.LekarzGrid.Visibility = Visibility.Collapsed;
                    this.DataGrid.Visibility = Visibility.Collapsed;
                    this.GodzinaGrid.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    this.PacjentGrid.Visibility = Visibility.Collapsed;
                    this.LekarzGrid.Visibility = Visibility.Visible;
                    this.DataGrid.Visibility = Visibility.Collapsed;
                    this.GodzinaGrid.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    this.PacjentGrid.Visibility = Visibility.Collapsed;
                    this.LekarzGrid.Visibility = Visibility.Collapsed;
                    this.DataGrid.Visibility = Visibility.Visible;
                    this.GodzinaGrid.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    this.PacjentGrid.Visibility = Visibility.Collapsed;
                    this.LekarzGrid.Visibility = Visibility.Collapsed;
                    this.DataGrid.Visibility = Visibility.Collapsed;
                    this.GodzinaGrid.Visibility = Visibility.Visible;
                    break;
            }
        }
        /// <summary>
        /// Wybór zaznaczonych wartości z tabeli do obiektu wizyta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Click(object sender, MouseButtonEventArgs e)
        {
            if (this.PacjentGrid.Visibility == Visibility.Visible)
            {
                foreach (PacjentView pacjent in PacjentTable.SelectedItems)
                {
                    Input_Imie.Text = pacjent.Imie.ToString();
                    Input_Nazwisko.Text = pacjent.Nazwisko.ToString();
                    Input_Pesel.Text = pacjent.Pesel.ToString();
                    wizyta.Pacjent = pacjenciClass.GetId(pacjent.Pesel.ToString());
                    this.next1.IsEnabled = true;
                }
            }
            if (this.LekarzTable.Visibility == Visibility.Visible)
            {
                foreach (LekarzView lekarz in LekarzTable.SelectedItems)
                {
                    lekarz_imie.Text = lekarz.Imie;
                    lekarz_nazwisko.Text = lekarz.Nazwisko;
                    lekarz_specjalizacja.Text = lekarz.Specjalizacja;
                    wizyta.Pracownik = lekarzeClass.GetId(lekarz.Pesel.ToString());
                    this.next2.IsEnabled = true;
                }
            }
        }
        /// <summary>
        /// Wczytanie wyboru godziny wizyty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next3_Click(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(4);
            this.PickedDate.Text = wizyta.Termin.ToShortDateString();
            CheckHours(wizyta);
        }
        /// <summary>
        /// Wczytanie wyboru daty wizyty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (this.DataGrid.Visibility == Visibility.Visible)
            {
                if (DataPicker.SelectedDate != null)
                {
                    wizyta.Termin = ((DateTime)DataPicker.SelectedDate);
                    this.next3.IsEnabled = true;
                }
            }
        }
        /// <summary>
        /// Reakcja na zatwierdzenie formularza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (this.AvailableHours.Text != "")
            {
                wizyta.Godzina = int.Parse(this.AvailableHours.Text);
                if (wizytyClass.AddRow(wizyta)) MessageBox.Show("Dodano wizytę");
                App.ParentWindowRef.ParentFrame.Navigate(new Wizyty());
            }
        }
        /// <summary>
        /// Sprawdzenie dostępnych godzin na podstawie daty i lekarza i przypisanie ich do ComboBox-a
        /// </summary>
        /// <param name="wizyta"></param>
        private void CheckHours(Wizyta wizyta)
        {
            AvailableHours.Items.Clear();
            Pracownik pracownik = new Pracownik();
            var hours = lekarzeClass.GetHours(wizyta.Pracownik);
            foreach (var el in hours)
            {
                pracownik.Pracuje_Od = el.Pracuje_Od;
                pracownik.Pracuje_Do = el.Pracuje_Do;
            }
            for (int i = pracownik.Pracuje_Od; i < pracownik.Pracuje_Do; i++)
            {
                AvailableHours.Items.Add(i);
            }
            var sethours = wizytyClass.ListRows(wizyta);
            if (sethours.Count > 0)
            {
                foreach (var el in sethours)
                {
                    AvailableHours.Items.Remove(el.Godzina);
                }
            }
        }
        /// <summary>
        /// Nawigacja do Wizyty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new Wizyty());
        /// <summary>
        /// Przejście do panelu wyboru lekarza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e) => ChangeVisibility(2);
        /// <summary>
        /// Przejście do panelu wyboru daty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next2_Click(object sender, RoutedEventArgs e) => ChangeVisibility(3);
        /// <summary>
        /// Przejście do panelu wyboru pacjenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e) => ChangeVisibility(1);
    }
}
