using System.Windows;
using System.Windows.Controls;

namespace ProjektSemestralny.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainPanel.xaml
    /// </summary>
    public partial class MainPanel : Page
    {
        /// <summary>
        /// Wczytanie panelu
        /// </summary>
        public MainPanel() => InitializeComponent();
        /// <summary>
        /// Nawigacja do panelu Pacjenci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new Pacjenci());
        /// <summary>
        /// Nawigacja do panelu Wizyty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new Wizyty());
        /// <summary>
        /// Nawigacja do panelu Lekarze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new Lekarze());
        /// <summary>
        /// Nawigacja do panelu Pracownicy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e) => App.ParentWindowRef.ParentFrame.Navigate(new Pracownicy());
        /// <summary>
        /// Zamknięcie aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e) => System.Windows.Application.Current.Shutdown();
    }
}
