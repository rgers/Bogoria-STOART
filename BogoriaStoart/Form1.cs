using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BogoriaStoart
{

    class Song
    {
        public string file;
        public string wykonawca;
        public string utwor;
        public int nadania;

        public Song(string a, string b, string c)
        {
            file = a;
            wykonawca = b;
            utwor = c;
            nadania = 1;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ArrayList folderyMuzyczne, folderyNiemuzyczne, utworyGrane;
            
            folderyMuzyczne = new ArrayList();
            folderyNiemuzyczne = new ArrayList();
            utworyGrane = new ArrayList();

            StreamReader czytnik = new StreamReader("test.txt");
            string linia = czytnik.ReadLine();
            string[] dane = linia.Split(';');

            Song piosenka = new Song(dane[0], dane[1], dane[2]);

            int numer = utworyGrane.BinarySearch(piosenka);
            if (numer < 0)
            {
                utworyGrane.Add(piosenka);
            }
            else
            {
                piosenka = (Song)utworyGrane[numer];
                piosenka.nadania++;
                utworyGrane[numer] = piosenka;
            }

        }
    }
}
