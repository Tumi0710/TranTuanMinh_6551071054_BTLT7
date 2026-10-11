using System;
using System.Windows.Forms;

namespace FitZoneGym
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormHoiVien());
        }
    }
}