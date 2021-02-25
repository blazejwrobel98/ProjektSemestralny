using System.Collections.Generic;
using System.Windows;

namespace ProjektSemestralny.Class
{
    class Functions
    {
        public void AlertBox(List<string> alerts) => MessageBox.Show(string.Join("\n", alerts));
    }
}
