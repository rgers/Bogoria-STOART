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
        ArrayList folderyMuzyczne, folderyNiemuzyczne, utworyGrane, files;

        public Form1()
        {
            InitializeComponent();

            folderyMuzyczne = new ArrayList();
            folderyNiemuzyczne = new ArrayList();
            utworyGrane = new ArrayList();
            files = new ArrayList();

            load_config();
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

        string find_file_from_path(string path)
        {
            string file;
            file = path.Substring(path.LastIndexOf('\\')+1, path.Length-path.LastIndexOf('\\')-1);
            return file;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {



            bool muzyczny;
            while (files.Count > 0)
            {
                StreamReader czytnik = new StreamReader((string)files[0]);
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
                            { folderyMuzyczne.Add(dane[0]); lst_muzyczne.Items.Add(dane[0]); muzyczny = true; }
                            else { folderyNiemuzyczne.Add(dane[0]); lst_nmuzyczne.Items.Add(dane[0]); muzyczny = false; }
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
                files.RemoveAt(0);
                lst_files.Items.RemoveAt(0);
            }
        }

        private void load_config()
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader("foldery_muzyczne.config");
                while (!sr.EndOfStream)
                {
                    folderyMuzyczne.Add(sr.ReadLine());
                    lst_muzyczne.Items.Add(folderyMuzyczne[folderyMuzyczne.Count - 1]);
                }
                sr.Close();
                sr.Dispose();
            }
            catch { }

            try
            {
                sr = new StreamReader("foldery_niemuzyczne.config");
                while (!sr.EndOfStream)
                {
                    folderyNiemuzyczne.Add(sr.ReadLine());
                    lst_nmuzyczne.Items.Add(folderyNiemuzyczne[folderyNiemuzyczne.Count - 1]);
                }
                sr.Close();
                sr.Dispose();
            }
            catch { }
        }

        private void save_config()
        {
            StreamWriter sw;
            try
            {
                sw = new StreamWriter("foldery_muzyczne.config");
                int a = 0;
                while (a<folderyMuzyczne.Count)
                {
                    sw.WriteLine(folderyMuzyczne[a]);
                    a++;
                }
                sw.Close();
                sw.Dispose();
            }
            catch { }

            try
            {
                sw = new StreamWriter("foldery_niemuzyczne.config");
                int a = 0;
                while (a < folderyNiemuzyczne.Count)
                {
                    sw.WriteLine(folderyNiemuzyczne[a]);
                    a++;
                }
                sw.Close();
                sw.Dispose();
            }
            catch { }
        }

        private void btn_savecfg_Click(object sender, EventArgs e)
        {
            save_config();
        }

        private void btn_del1_Click(object sender, EventArgs e)
        {
            while (lst_muzyczne.SelectedIndices.Count > 0)
            {
                folderyMuzyczne.RemoveAt(lst_muzyczne.SelectedIndices[0]);
                lst_muzyczne.Items.RemoveAt(lst_muzyczne.SelectedIndices[0]);
                
            }
        }

        private void btn_del2_Click(object sender, EventArgs e)
        {
            while (lst_nmuzyczne.SelectedIndices.Count > 0)
            {
                folderyNiemuzyczne.RemoveAt(lst_nmuzyczne.SelectedIndices[0]);
                lst_nmuzyczne.Items.RemoveAt(lst_nmuzyczne.SelectedIndices[0]);
                
            }
        }

        private void lst_files_DragEnter(object sender, DragEventArgs e)
        {
            if( e.Data.GetDataPresent(DataFormats.FileDrop, false) == true )
            e.Effect = DragDropEffects.All;
        }

        private void lst_files_DragDrop(object sender, DragEventArgs e)
        {
            string[] strfiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            // loop through the string array, adding each filename to the ListBox
            foreach (string file in strfiles)
            {
                lst_files.Items.Add(find_file_from_path(file));
                files.Add(file);
            }
        }

        private void btn_delfiles_Click(object sender, EventArgs e)
        {
            while (lst_files.SelectedIndices.Count > 0)
            {
                files.RemoveAt(lst_files.SelectedIndices[0]);
                lst_files.Items.RemoveAt(lst_files.SelectedIndices[0]);

            }
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
