namespace Mini_Projet
{
    partial class Ajouter_Surveillance
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
            this.BtnAnnuler = new System.Windows.Forms.Button();
            this.BtnAjouter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpDateSurvAdd = new System.Windows.Forms.DateTimePicker();
            this.CbSalleAdd = new System.Windows.Forms.ComboBox();
            this.CbSeanceAdd = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnAnnuler
            // 
            this.BtnAnnuler.Location = new System.Drawing.Point(100, 202);
            this.BtnAnnuler.Name = "BtnAnnuler";
            this.BtnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnuler.TabIndex = 0;
            this.BtnAnnuler.Text = "Annuler";
            this.BtnAnnuler.UseVisualStyleBackColor = true;
            this.BtnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);
            // 
            // BtnAjouter
            // 
            this.BtnAjouter.Location = new System.Drawing.Point(225, 202);
            this.BtnAjouter.Name = "BtnAjouter";
            this.BtnAjouter.Size = new System.Drawing.Size(75, 23);
            this.BtnAjouter.TabIndex = 1;
            this.BtnAjouter.Text = "Ajouter";
            this.BtnAjouter.UseVisualStyleBackColor = true;
            this.BtnAjouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Séance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Salle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date";
            // 
            // DtpDateSurvAdd
            // 
            this.DtpDateSurvAdd.Location = new System.Drawing.Point(100, 156);
            this.DtpDateSurvAdd.Name = "DtpDateSurvAdd";
            this.DtpDateSurvAdd.Size = new System.Drawing.Size(200, 20);
            this.DtpDateSurvAdd.TabIndex = 4;
            // 
            // CbSalleAdd
            // 
            this.CbSalleAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSalleAdd.FormattingEnabled = true;
            this.CbSalleAdd.Location = new System.Drawing.Point(100, 118);
            this.CbSalleAdd.Name = "CbSalleAdd";
            this.CbSalleAdd.Size = new System.Drawing.Size(200, 21);
            this.CbSalleAdd.TabIndex = 3;
            // 
            // CbSeanceAdd
            // 
            this.CbSeanceAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSeanceAdd.FormattingEnabled = true;
            this.CbSeanceAdd.Location = new System.Drawing.Point(100, 80);
            this.CbSeanceAdd.Name = "CbSeanceAdd";
            this.CbSeanceAdd.Size = new System.Drawing.Size(200, 21);
            this.CbSeanceAdd.TabIndex = 2;
            // 
            // Ajouter_Surveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 248);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpDateSurvAdd);
            this.Controls.Add(this.CbSalleAdd);
            this.Controls.Add(this.CbSeanceAdd);
            this.Controls.Add(this.BtnAjouter);
            this.Controls.Add(this.BtnAnnuler);
            this.Name = "Ajouter_Surveillance";
            this.Text = "Ajouter une surveillance";
            this.Load += new System.EventHandler(this.Ajouter_Surveillance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAnnuler;
        private System.Windows.Forms.Button BtnAjouter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpDateSurvAdd;
        private System.Windows.Forms.ComboBox CbSalleAdd;
        private System.Windows.Forms.ComboBox CbSeanceAdd;
    }
}