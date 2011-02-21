namespace BogoriaStoart
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.lst_muzyczne = new System.Windows.Forms.ListBox();
            this.lst_nmuzyczne = new System.Windows.Forms.ListBox();
            this.btn_savecfg = new System.Windows.Forms.Button();
            this.btn_del1 = new System.Windows.Forms.Button();
            this.btn_del2 = new System.Windows.Forms.Button();
            this.lst_files = new System.Windows.Forms.ListBox();
            this.btn_delfiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 271);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lst_muzyczne
            // 
            this.lst_muzyczne.FormattingEnabled = true;
            this.lst_muzyczne.Location = new System.Drawing.Point(287, 12);
            this.lst_muzyczne.Name = "lst_muzyczne";
            this.lst_muzyczne.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_muzyczne.Size = new System.Drawing.Size(274, 160);
            this.lst_muzyczne.TabIndex = 1;
            // 
            // lst_nmuzyczne
            // 
            this.lst_nmuzyczne.FormattingEnabled = true;
            this.lst_nmuzyczne.Location = new System.Drawing.Point(567, 12);
            this.lst_nmuzyczne.Name = "lst_nmuzyczne";
            this.lst_nmuzyczne.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_nmuzyczne.Size = new System.Drawing.Size(264, 160);
            this.lst_nmuzyczne.TabIndex = 2;
            // 
            // btn_savecfg
            // 
            this.btn_savecfg.Location = new System.Drawing.Point(756, 271);
            this.btn_savecfg.Name = "btn_savecfg";
            this.btn_savecfg.Size = new System.Drawing.Size(75, 23);
            this.btn_savecfg.TabIndex = 3;
            this.btn_savecfg.Text = "Save Config";
            this.btn_savecfg.UseVisualStyleBackColor = true;
            this.btn_savecfg.Click += new System.EventHandler(this.btn_savecfg_Click);
            // 
            // btn_del1
            // 
            this.btn_del1.Location = new System.Drawing.Point(287, 174);
            this.btn_del1.Name = "btn_del1";
            this.btn_del1.Size = new System.Drawing.Size(90, 23);
            this.btn_del1.TabIndex = 4;
            this.btn_del1.Text = "Delete selected";
            this.btn_del1.UseVisualStyleBackColor = true;
            this.btn_del1.Click += new System.EventHandler(this.btn_del1_Click);
            // 
            // btn_del2
            // 
            this.btn_del2.Location = new System.Drawing.Point(582, 174);
            this.btn_del2.Name = "btn_del2";
            this.btn_del2.Size = new System.Drawing.Size(90, 23);
            this.btn_del2.TabIndex = 5;
            this.btn_del2.Text = "Delete selected";
            this.btn_del2.UseVisualStyleBackColor = true;
            this.btn_del2.Click += new System.EventHandler(this.btn_del2_Click);
            // 
            // lst_files
            // 
            this.lst_files.AllowDrop = true;
            this.lst_files.FormattingEnabled = true;
            this.lst_files.Location = new System.Drawing.Point(12, 12);
            this.lst_files.Name = "lst_files";
            this.lst_files.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_files.Size = new System.Drawing.Size(269, 160);
            this.lst_files.TabIndex = 6;
            this.lst_files.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_files_DragDrop);
            this.lst_files.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_files_DragEnter);
            // 
            // btn_delfiles
            // 
            this.btn_delfiles.Location = new System.Drawing.Point(12, 174);
            this.btn_delfiles.Name = "btn_delfiles";
            this.btn_delfiles.Size = new System.Drawing.Size(90, 23);
            this.btn_delfiles.TabIndex = 7;
            this.btn_delfiles.Text = "Delete selected";
            this.btn_delfiles.UseVisualStyleBackColor = true;
            this.btn_delfiles.Click += new System.EventHandler(this.btn_delfiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 306);
            this.Controls.Add(this.btn_delfiles);
            this.Controls.Add(this.lst_files);
            this.Controls.Add(this.btn_del2);
            this.Controls.Add(this.btn_del1);
            this.Controls.Add(this.btn_savecfg);
            this.Controls.Add(this.lst_nmuzyczne);
            this.Controls.Add(this.lst_muzyczne);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ListBox lst_muzyczne;
        private System.Windows.Forms.ListBox lst_nmuzyczne;
        private System.Windows.Forms.Button btn_savecfg;
        private System.Windows.Forms.Button btn_del1;
        private System.Windows.Forms.Button btn_del2;
        private System.Windows.Forms.ListBox lst_files;
        private System.Windows.Forms.Button btn_delfiles;
    }
}

