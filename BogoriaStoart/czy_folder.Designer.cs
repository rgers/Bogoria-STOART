namespace BogoriaStoart
{
    partial class czy_folder
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
            this.lbl_folder = new System.Windows.Forms.Label();
            this.btn_muz = new System.Windows.Forms.Button();
            this.btn_nmuz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_folder
            // 
            this.lbl_folder.AutoSize = true;
            this.lbl_folder.Location = new System.Drawing.Point(12, 20);
            this.lbl_folder.Name = "lbl_folder";
            this.lbl_folder.Size = new System.Drawing.Size(0, 13);
            this.lbl_folder.TabIndex = 0;
            // 
            // btn_muz
            // 
            this.btn_muz.Location = new System.Drawing.Point(155, 191);
            this.btn_muz.Name = "btn_muz";
            this.btn_muz.Size = new System.Drawing.Size(75, 23);
            this.btn_muz.TabIndex = 1;
            this.btn_muz.Text = "Muzyczny";
            this.btn_muz.UseVisualStyleBackColor = true;
            this.btn_muz.Click += new System.EventHandler(this.btn_muz_Click);
            // 
            // btn_nmuz
            // 
            this.btn_nmuz.Location = new System.Drawing.Point(592, 191);
            this.btn_nmuz.Name = "btn_nmuz";
            this.btn_nmuz.Size = new System.Drawing.Size(87, 23);
            this.btn_nmuz.TabIndex = 2;
            this.btn_nmuz.Text = "Nie-muzyczny";
            this.btn_nmuz.UseVisualStyleBackColor = true;
            this.btn_nmuz.Click += new System.EventHandler(this.btn_nmuz_Click);
            // 
            // czy_folder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 284);
            this.Controls.Add(this.btn_nmuz);
            this.Controls.Add(this.btn_muz);
            this.Controls.Add(this.lbl_folder);
            this.Name = "czy_folder";
            this.Text = "Czy folder jest muzyczny";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_folder;
        private System.Windows.Forms.Button btn_muz;
        private System.Windows.Forms.Button btn_nmuz;
    }
}