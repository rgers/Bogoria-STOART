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

   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ArrayList folderyMuzyczne, folderyNiemuzyczne, utworyGrane;
            
            folderyMuzyczne = new ArrayList();
            folderyNiemuzyczne = new ArrayList();
            utworyGrane = new ArrayList();
            bool muzyczny;

            StreamReader czytnik = new StreamReader("test.txt");
            while (czytnik.EndOfStream == false)
            {
                string linia = czytnik.ReadLine();
                string[] dane = linia.Split(';');

                if (find_if_exists(folderyMuzyczne, dane[0]) == (-1))
                {
                    if (find_if_exists(folderyNiemuzyczne, dane[0]) == (-1))
                    {
                        czy_folder test = new czy_folder(dane[0]);
                        test.ShowDialog();
                        if (test.muzyczny)
                        { folderyMuzyczne.Add(dane[0]); muzyczny = true; }
                        else { folderyNiemuzyczne.Add(dane[0]); muzyczny = false; }
                    }
                    else { muzyczny = false; }
                }
                else { muzyczny = true; }

                if (muzyczny)
                {
                    Song piosenka = new Song(dane[0], dane[1], dane[2]);

                    int numer = find_if_exists(utworyGrane, piosenka);
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

        int find_if_exists(ArrayList arej, Song piosnka)
        {
            int a = 0;
            while (a < arej.Count)
            {
                Song song1=(Song)arej[a];
                if (song1.utwor == piosnka.utwor & song1.wykonawca == piosnka.wykonawca)
                {
                    return a;
                }
            }

            return (-1);
        }

        int find_if_exists(ArrayList arej, string dir)
        {
            int a = 0;
            while (a < arej.Count)
            {
                
                if (arej[a].ToString()==dir)
                {
                    return a;
                }
                a++;
            }

            return (-1);
        }

        string find_directory_from_path(string path)
        {
            string directory;
            directory = path.Substring(0, path.LastIndexOf('\\'));
            return directory;
        }
    }

    class Song
    {
        public string file;
        public string wykonawca;
        public string utwor;
        public int nadania;

        public Song(string path, string performer, string title)
        {
            file = path;
            wykonawca = performer;
            utwor = title;
            nadania = 1;
        }
    }
}
