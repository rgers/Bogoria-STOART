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
        int last_index;

        public Form1()
        {
            InitializeComponent();

            folderyMuzyczne = new ArrayList();
            folderyNiemuzyczne = new ArrayList();
            utworyGrane = new ArrayList();
            files = new ArrayList();
            last_index = -1;

            load_config();
        }

        int find_if_exists(ArrayList arej, Song piosnka)
        {
            int a = 0;
            while (a < arej.Count)
            {
                Song song1=(Song)arej[a];
                if (song1.utwor.ToLower() == piosnka.utwor.ToLower() & song1.wykonawca.ToLower() == piosnka.wykonawca.ToLower())
                {
                    return a;
                }
                a++;
            }

            return (-1);
        }

        int find_if_exists(ArrayList arej, string dir)
        {
            int a = 0;
            while (a < arej.Count)
            {
                
                if (arej[a].ToString().ToLower()==dir.ToLower())
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
            if (path.LastIndexOf('\\') > 1)
            {
                directory = path.Substring(0, path.LastIndexOf('\\'));
            }
            else { directory = "error"; }
            return directory;
        }

        string find_file_from_path(string path)
        {
            string file;
            if (path.LastIndexOf('\\') > 1)
            {
                file = path.Substring(path.LastIndexOf('\\') + 1, path.Length - path.LastIndexOf('\\') - 1);
            }
            else { file = "error"; }
            return file;
        }

        string[] find_data_from_filename(string[] path)
        {
            string filename = path[1].Substring(path[1].LastIndexOf('\\')+1, path[1].Length - path[1].LastIndexOf('\\') - 5);
            string[] helper = filename.Split('-');
            if (helper.Length > 1)
            {
                helper[0] = helper[0].Trim();
                helper[1] = helper[1].Trim();
                string[] dane = { path[0], path[1], " ", helper[1], " ", helper[0] };
                return dane;
            }
            else
            {
                string[] dane = { " " };
                return dane;
            }
        }

        string[] try_to_fix_time(string time)
        {
            if (time.Length > 8)
            {
                int a = 0;
                while (a < time.Length - 2 & a != -1)
                {
                    a = time.IndexOf(':', a);
                    if (a != -1)
                    {
                        int b = time.IndexOf(':', a + 1);
                        if (b != -1)
                        {
                            if (b == a + 3)
                            {
                                time = time.Substring(a - 2, time.Length - a + 2);
                                a = -1;

                                return time.Split(';');
                            }
                            else { return null; }
                        }
                        else { return null; }
                    }
                    else { return null; }
                }
                return null;
            }

            return null;
        }

        void find_time(string time)
        {
           

            if (last_index > -1 & time.Length==8)
            {
                DateTime dt1, dt2, dtfinal;
                Song sngtemp = (Song)utworyGrane[last_index];
                if (sngtemp.czas.Length == 8)
                {
                    dt1 = Convert.ToDateTime(sngtemp.czas);
                    dt2 = Convert.ToDateTime(time.Trim());
                    if (dt2.Hour < dt1.Hour)
                    {
                        dt2 = dt2.AddDays(1);
                    }
                    long tiki = dt2.Ticks - dt1.Ticks;
                    if (tiki > 0)
                    {
                        dtfinal = new DateTime(tiki);
                        if (dtfinal.Second > 9)
                        {
                            sngtemp.czas = dtfinal.Minute + ":" + dtfinal.Second;
                        }
                        else
                        {
                            sngtemp.czas = dtfinal.Minute + ":" + "0" + dtfinal.Second;
                        }
                        utworyGrane[last_index] = sngtemp;
                    }
                    
                }
            }
        }

        string find_taglib_path(string path, string czas)
        {
            string time = "";
            try
            {
                TagLib.File pliktaglib = TagLib.File.Create(path);

                long tiki = pliktaglib.Properties.Duration.Ticks;
                DateTime dtfinal = new DateTime(tiki);
                
                if (dtfinal.Second > 9)
                {
                    time = dtfinal.Minute + ":" + dtfinal.Second;
                }
                else
                {
                    time = dtfinal.Minute + ":" + "0" + dtfinal.Second;
                }
                return time;
            }
            catch { }
            return czas;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {



            bool muzyczny;
            while (files.Count > 0)
            {
                StreamReader czytnik = new StreamReader((string)files[0], Encoding.GetEncoding(1250));
                while (czytnik.EndOfStream == false)
                {
                    string linia = czytnik.ReadLine();
                    string[] dane = linia.Split(';');
                    if (dane.Length > 3)
                    {
                        if (dane[0].Length > 8)
                        {
                            dane = try_to_fix_time(linia);
                        }
                    }
                    if (dane != null)
                    {
                        if (dane.Length > 3)
                        {
                            find_time(dane[0]);
                            if (find_if_exists(folderyMuzyczne, find_directory_from_path(dane[1])) == (-1))
                            {
                                if (find_if_exists(folderyNiemuzyczne, find_directory_from_path(dane[1])) == (-1))
                                {
                                    czy_folder test = new czy_folder(find_directory_from_path(dane[1]));
                                    test.ShowDialog();
                                    if (test.muzyczny)
                                    { folderyMuzyczne.Add(find_directory_from_path(dane[1])); lst_muzyczne.Items.Add(find_directory_from_path(dane[1])); muzyczny = true; }
                                    else { folderyNiemuzyczne.Add(find_directory_from_path(dane[1])); lst_nmuzyczne.Items.Add(find_directory_from_path(dane[1])); muzyczny = false; }
                                }
                                else { muzyczny = false; }
                            }
                            else { muzyczny = true; }

                            if (muzyczny)
                            {
                                if (dane[5].Length < 2)
                                {
                                    dane = find_data_from_filename(dane);
                                    if (dane.Length < 2)
                                    { muzyczny = false; }
                                }
                            }


                            if (muzyczny)
                            {

                                Song piosenka = new Song(dane[1], dane[5].Trim(), dane[3].Trim(), dane[0].Trim());

                                if (piosenka.utwor == "Keep Holding On")
                                {
                                    bool test = true;
                                }

                                piosenka.czas = find_taglib_path(piosenka.file, piosenka.czas);

                                int numer = find_if_exists(utworyGrane, piosenka);
                                if (numer < 0)
                                {
                                    utworyGrane.Add(piosenka);
                                    last_index = utworyGrane.Count - 1;
                                }
                                else
                                {
                                    piosenka = (Song)utworyGrane[numer];
                                    piosenka.nadania++;
                                    utworyGrane[numer] = piosenka;
                                    last_index = numer;
                                }
                            }
                        }
                        else
                        {
                            if (dane.Length < 4 & dane.Length > 0)
                            {
                                find_time(dane[0]);
                                last_index = -1;
                            }
                        }
                    }
                    }
                    files.RemoveAt(0);
                    lst_files.Items.RemoveAt(0);
                }
                if (last_index != -1)
                {
                    find_time("00:00:01");
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

        private void btn_saveout_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            try
            {
                sw = new StreamWriter("wynik.csv");
                int a = 0;
                while (a < utworyGrane.Count)
                {
                    Song utwor = (Song)utworyGrane[a];
                    sw.WriteLine(utwor.wykonawca + ";" + utwor.utwor + ";" + utwor.czas + ";" + utwor.nadania.ToString() + ";" + utwor.file);
                    a++;
                }
                sw.Close();
                sw.Dispose();
            }
            catch { }
                        
           
        }
    } //end class

    class Song
    {
        public string file;
        public string wykonawca;
        public string utwor;
        public string czas;
        public int nadania;
        

        public Song(string path, string performer, string title, string time)
        {
            file = path;
            wykonawca = performer;
            utwor = title;
            czas = time;
            nadania = 1;
        }
    }
}
