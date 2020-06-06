namespace Mini_Projet
{
    partial class Ajouter_Seance
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeDeb = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFin = new System.Windows.Forms.DateTimePicker();
            this.Txt_Nom = new System.Windows.Forms.TextBox();
            this.Txt_Code = new System.Windows.Forms.TextBox();
            this.Btn_Ajouter = new System.Windows.Forms.Button();
            this.Btn_Annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Heure de début";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Heure de fin";
            // 
            // dateTimeDeb
            // 
            this.dateTimeDeb.CustomFormat = "HH:mm";
            this.dateTimeDeb.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDeb.Location = new System.Drawing.Point(112, 156);
            this.dateTimeDeb.Name = "dateTimeDeb";
            this.dateTimeDeb.ShowUpDown = true;
            this.dateTimeDeb.Size = new System.Drawing.Size(200, 20);
            this.dateTimeDeb.TabIndex = 4;
            // 
            // dateTimeFin
            // 
            this.dateTimeFin.CustomFormat = "hh:mm";
            this.dateTimeFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFin.Location = new System.Drawing.Point(112, 194);
            this.dateTimeFin.Name = "dateTimeFin";
            this.dateTimeFin.ShowUpDown = true;
            this.dateTimeFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFin.TabIndex = 5;
            // 
            // Txt_Nom
            // 
            this.Txt_Nom.Location = new System.Drawing.Point(112, 80);
            this.Txt_Nom.Name = "Txt_Nom";
            this.Txt_Nom.Size = new System.Drawing.Size(200, 20);
            this.Txt_Nom.TabIndex = 6;
            // 
            // Txt_Code
            // 
            this.Txt_Code.Location = new System.Drawing.Point(112, 118);
            this.Txt_Code.Name = "Txt_Code";
            this.Txt_Code.Size = new System.Drawing.Size(200, 20);
            this.Txt_Code.TabIndex = 7;
            // 
            // Btn_Ajouter
            // 
            this.Btn_Ajouter.Location = new System.Drawing.Point(237, 240);
            this.Btn_Ajouter.Name = "Btn_Ajouter";
            this.Btn_Ajouter.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ajouter.TabIndex = 9;
            this.Btn_Ajouter.Text = "Ajouter";
            this.Btn_Ajouter.UseVisualStyleBackColor = true;
            this.Btn_Ajouter.Click += new System.EventHandler(this.Btn_Ajouter_Click);
            // 
            // Btn_Annuler
            // 
            this.Btn_Annuler.Location = new System.Drawing.Point(112, 240);
            this.Btn_Annuler.Name = "Btn_Annuler";
            this.Btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.Btn_Annuler.TabIndex = 8;
            this.Btn_Annuler.Text = "Annuler";
            this.Btn_Annuler.UseVisualStyleBackColor = true;
            this.Btn_Annuler.Click += new System.EventHandler(this.Btn_Annuler_Click);
            // 
            // Ajouter_Seance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 287);
            this.Controls.Add(this.Btn_Ajouter);
            this.Controls.Add(this.Btn_Annuler);
            this.Controls.Add(this.Txt_Code);
            this.Controls.Add(this.Txt_Nom);
            this.Controls.Add(this.dateTimeFin);
            this.Controls.Add(this.dateTimeDeb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Ajouter_Seance";
            this.Text = "Ajouter une séance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ajouter_Seance_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeDeb;
        private System.Windows.Forms.DateTimePicker dateTimeFin;
        private System.Windows.Forms.TextBox Txt_Nom;
        private System.Windows.Forms.TextBox Txt_Code;
        private System.Windows.Forms.Button Btn_Ajouter;
        private System.Windows.Forms.Button Btn_Annuler;
    }
}