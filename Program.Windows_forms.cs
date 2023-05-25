using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_online_de_telefoane_3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var Magazin=new MagazinulDeTelefoaneMobile();
            Magazin.Adauga_Telefon(new Telefon("Samsung", "S24 Pro+",4000, "Alb", true));
            Magazin.Adauga_Telefon(new Telefon("Xiaomi", "13 Pro Ultra", 3200, "Maro", true));
            Magazin.Adauga_Telefon(new Telefon("Huawei", "P60 Pro", 3600, "Alb", true));
            Magazin.Adauga_Telefon(new Telefon("Iphone", "15 +", 7000, "Verde", true));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(Magazin));
        }
    }
}
