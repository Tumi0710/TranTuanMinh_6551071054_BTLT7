using System;
using System.Windows.Forms;

namespace AnKhangClinic
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLichKham());
        }
    }
}