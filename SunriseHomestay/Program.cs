using System;
using System.Windows.Forms;

namespace SunriseHomestay
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPhong());
        }
    }
}