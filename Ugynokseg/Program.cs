using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bev3
{
    class Mercedesz
    {
        private string nev;
        private double maxUzemanyag;
        private double uzemanyagAllas;
        private double tavVaros;
        private double tavOrszagUt;
        private double fogyasztasVaros;
        private double fogyasztasOU;
        public double tankol;
        public double tankolasMenny = 0;
        public double fogyasztas = 0;

        public Mercedesz(string nev, double maxUzemanyag, double uzemanyagAllas, double tavVaros, double tavOrszagUt, double fogyasztasVaros, double fogyasztasOU)
        {
            Nev = nev;
            MaxUzemanyag = maxUzemanyag;
            UzemanyagAllas = uzemanyagAllas;
            TavVaros = tavVaros;
            TavOrszagUt = tavOrszagUt;
            FogyasztasVaros = fogyasztasVaros;
            FogyasztasOU = fogyasztasOU;
        }

        public string Nev { get => nev; set => nev = value; }
        public double MaxUzemanyag { get => maxUzemanyag; set => maxUzemanyag = value; }
        public double UzemanyagAllas { get => uzemanyagAllas; set => uzemanyagAllas = value; }
        public double TavVaros { get => tavVaros; set => tavVaros = value; }
        public double TavOrszagUt { get => tavOrszagUt; set => tavOrszagUt = value; }
        public double FogyasztasVaros { get => fogyasztasVaros; set => fogyasztasVaros = value; }
        public double FogyasztasOU { get => fogyasztasOU; set => fogyasztasOU = value; }

        public bool kellEtankolni()
        {
            FogyasztasVaros = fogyasztasVaros / 100; //1km fogyasztása
            FogyasztasOU = fogyasztasOU / 100; // 1km fogyasztása
            double eredmeny = UzemanyagAllas;

            for (int i = 0; i < TavOrszagUt; i++)
            {
                eredmeny -= FogyasztasOU;
                fogyasztas += FogyasztasOU;
            }

            for (int i = 0; i < TavVaros; i++)
            {
                eredmeny -= FogyasztasVaros;
                fogyasztas += FogyasztasVaros;
            }

            if (eredmeny < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double tankolas()
        {
            tankol = 1; // 1L tankolása az autóba
            tankolasMenny = 0;
            double eredmeny = UzemanyagAllas - fogyasztas;
            while(eredmeny <= 5)
            {
                tankolasMenny++;
                eredmeny += tankol;
            }
            
            return eredmeny;
        }

        

    }
    class Program
    {
        static public void Kikuldetes(Mercedesz ugynok)
        {
            Console.WriteLine("Ügynök neve: " + ugynok.Nev);
            Console.WriteLine("\t Távolság: " + (ugynok.TavOrszagUt + ugynok.TavVaros) + "km" + " (Országút: " + ugynok.TavOrszagUt + "km, Város: " + ugynok.TavVaros + "km)");
            Console.WriteLine("\t Kezdeti üzemanyagmérő állása: " + ugynok.UzemanyagAllas + "L");
            if (ugynok.kellEtankolni() == true)
            {
                Console.WriteLine("\t Megmaradt üzemanyag: " + Math.Round(ugynok.tankolas(),2) + "L");
            }
            else
            {
                Console.WriteLine("\t Megmaradt üzemanyag: " + Math.Round((ugynok.UzemanyagAllas - ugynok.fogyasztas),2) + "L");
            }
            Console.WriteLine("\t Fogyasztott üzemanyag: " + Math.Round((ugynok.fogyasztas), 2) + "L");
            Console.WriteLine("\t Tankolva lett az autóba: " + ugynok.tankolasMenny + "L\n");
        }


        static void Main(string[] args)
        {
            //név, maxuzemanyag, ueallas, tavvaros, tavorszag, fogyvaros, fogyOU
            Mercedesz ugynok1 = new Mercedesz("Zoli", 50, 20, 10, 500, 7.5, 6);
            Mercedesz ugynok2 = new Mercedesz("Máté", 60, 60, 5, 300, 9.5, 7.2);
            Kikuldetes(ugynok1);
            Kikuldetes(ugynok2);

            Console.ReadKey();
        }
    }
}
