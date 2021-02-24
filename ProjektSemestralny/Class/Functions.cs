using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektSemestralny.Class
{
    class Functions
    {
        public void AlertBox(List<string> alerts)
        {
            MessageBox.Show(string.Join("\n", alerts));
        }
    }
}
