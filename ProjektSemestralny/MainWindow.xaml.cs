using ProjektSemestralny.Windows;
using System.Windows;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.ParentWindowRef = this;
            this.ParentFrame.Navigate(new MainPanel());
        }
    }
}
