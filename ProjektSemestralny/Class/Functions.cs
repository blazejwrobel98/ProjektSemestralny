using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
