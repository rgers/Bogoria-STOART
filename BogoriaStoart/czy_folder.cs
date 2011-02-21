using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BogoriaStoart
{
    public partial class czy_folder : Form
    {
        public bool muzyczny;

        public czy_folder(string folder)
        {
            InitializeComponent();
            lbl_folder.Text = folder;
        }

        private void btn_muz_Click(object sender, EventArgs e)
        {
            muzyczny = true;
            this.Close();
        }

        private void btn_nmuz_Click(object sender, EventArgs e)
        {
            muzyczny = false;
            this.Close();
        }
    }
}
