namespace Mini_Projet
{
    partial class Modifier_Enseignant
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
            this.Txt_Nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Pren = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cbx_Dept = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Modifier = new System.Windows.Forms.Button();
            this.Btn_Annuler = new System.Windows.Forms.Button();
            this.Txt_Email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt_Nom
            // 
            this.Txt_Nom.Location = new System.Drawing.Point(152, 91);
            this.Txt_Nom.Name = "Txt_Nom";
            this.Txt_Nom.Size = new System.Drawing.Size(200, 20);
            this.Txt_Nom.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nom";
            // 
            // Txt_Pren
            // 
            this.Txt_Pren.Location = new System.Drawing.Point(152, 129);
            this.Txt_Pren.Name = "Txt_Pren";
            this.Txt_Pren.Size = new System.Drawing.Size(200, 20);
            this.Txt_Pren.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Prénom";
            // 
            // Cbx_Dept
            // 
            this.Cbx_Dept.FormattingEnabled = true;
            this.Cbx_Dept.Location = new System.Drawing.Point(152, 205);
            this.Cbx_Dept.Name = "Cbx_Dept";
            this.Cbx_Dept.Size = new System.Drawing.Size(200, 21);
            this.Cbx_Dept.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Departement";
            // 
            // Btn_Modifier
            // 
            this.Btn_Modifier.Location = new System.Drawing.Point(277, 250);
            this.Btn_Modifier.Name = "Btn_Modifier";
            this.Btn_Modifier.Size = new System.Drawing.Size(75, 23);
            this.Btn_Modifier.TabIndex = 21;
            this.Btn_Modifier.Text = "Modifier";
            this.Btn_Modifier.UseVisualStyleBackColor = true;
            this.Btn_Modifier.Click += new System.EventHandler(this.Btn_Modifier_Click);
            // 
            // Btn_Annuler
            // 
            this.Btn_Annuler.Location = new System.Drawing.Point(152, 250);
            this.Btn_Annuler.Name = "Btn_Annuler";
            this.Btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.Btn_Annuler.TabIndex = 20;
            this.Btn_Annuler.Text = "Annuler";
            this.Btn_Annuler.UseVisualStyleBackColor = true;
            this.Btn_Annuler.Click += new System.EventHandler(this.Btn_Annuler_Click);
            // 
            // Txt_Email
            // 
            this.Txt_Email.Location = new System.Drawing.Point(152, 167);
            this.Txt_Email.Name = "Txt_Email";
            this.Txt_Email.Size = new System.Drawing.Size(200, 20);
            this.Txt_Email.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Email";
            // 
            // Modifier_Enseignant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 296);
            this.Controls.Add(this.Txt_Email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_Modifier);
            this.Controls.Add(this.Btn_Annuler);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cbx_Dept);
            this.Controls.Add(this.Txt_Pren);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Nom);
            this.Controls.Add(this.label1);
            this.Name = "Modifier_Enseignant";
            this.Text = "Modifier l\'enseignant";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Modifier_Enseignant_FormClosed);
            this.Load += new System.EventHandler(this.Modifier_Enseignant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Pren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbx_Dept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Modifier;
        private System.Windows.Forms.Button Btn_Annuler;
        private System.Windows.Forms.TextBox Txt_Email;
        private System.Windows.Forms.Label label5;
    }
}