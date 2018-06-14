using AutoTilesConverter.Dialogs;
using System;
using System.Windows.Forms;

namespace AutoTilesConverter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}