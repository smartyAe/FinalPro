namespace Mini_Projet
{
    partial class Modifier_Departement
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
            this.Btn_Modifier = new System.Windows.Forms.Button();
            this.Btn_Annuler = new System.Windows.Forms.Button();
            this.Txt_Code = new System.Windows.Forms.TextBox();
            this.Txt_Nom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Modifier
            // 
            this.Btn_Modifier.Location = new System.Drawing.Point(237, 161);
            this.Btn_Modifier.Name = "Btn_Modifier";
            this.Btn_Modifier.Size = new System.Drawing.Size(75, 23);
            this.Btn_Modifier.TabIndex = 25;
            this.Btn_Modifier.Text = "Modifier";
            this.Btn_Modifier.UseVisualStyleBackColor = true;
            this.Btn_Modifier.Click += new System.EventHandler(this.Btn_Modifier_Click);
            // 
            // Btn_Annuler
            // 
            this.Btn_Annuler.Location = new System.Drawing.Point(112, 161);
            this.Btn_Annuler.Name = "Btn_Annuler";
            this.Btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.Btn_Annuler.TabIndex = 24;
            this.Btn_Annuler.Text = "Annuler";
            this.Btn_Annuler.UseVisualStyleBackColor = true;
            this.Btn_Annuler.Click += new System.EventHandler(this.Btn_Annuler_Click);
            // 
            // Txt_Code
            // 
            this.Txt_Code.Location = new System.Drawing.Point(112, 118);
            this.Txt_Code.Name = "Txt_Code";
            this.Txt_Code.Size = new System.Drawing.Size(200, 20);
            this.Txt_Code.TabIndex = 23;
            // 
            // Txt_Nom
            // 
            this.Txt_Nom.Location = new System.Drawing.Point(112, 80);
            this.Txt_Nom.Name = "Txt_Nom";
            this.Txt_Nom.Size = new System.Drawing.Size(200, 20);
            this.Txt_Nom.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nom";
            // 
            // Modifier_Departement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 207);
            this.Controls.Add(this.Btn_Modifier);
            this.Controls.Add(this.Btn_Annuler);
            this.Controls.Add(this.Txt_Code);
            this.Controls.Add(this.Txt_Nom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modifier_Departement";
            this.Text = "Modifier_Departement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Modifier_Departement_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Modifier;
        private System.Windows.Forms.Button Btn_Annuler;
        private System.Windows.Forms.TextBox Txt_Code;
        private System.Windows.Forms.TextBox Txt_Nom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}