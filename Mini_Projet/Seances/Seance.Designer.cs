namespace Mini_Projet
{
    partial class Seance
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
            this.Gb_Sea = new System.Windows.Forms.GroupBox();
            this.Txt_Rech = new System.Windows.Forms.TextBox();
            this.Btn_Modifier = new System.Windows.Forms.Button();
            this.Btn_Supprimer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Ajouter = new System.Windows.Forms.Button();
            this.Dgv_Seance = new System.Windows.Forms.DataGridView();
            this.Gb_Sea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Seance)).BeginInit();
            this.SuspendLayout();
            // 
            // Gb_Sea
            // 
            this.Gb_Sea.Controls.Add(this.Txt_Rech);
            this.Gb_Sea.Controls.Add(this.Btn_Modifier);
            this.Gb_Sea.Controls.Add(this.Btn_Supprimer);
            this.Gb_Sea.Controls.Add(this.label2);
            this.Gb_Sea.Controls.Add(this.Btn_Ajouter);
            this.Gb_Sea.Controls.Add(this.Dgv_Seance);
            this.Gb_Sea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gb_Sea.Location = new System.Drawing.Point(23, 69);
            this.Gb_Sea.Name = "Gb_Sea";
            this.Gb_Sea.Size = new System.Drawing.Size(588, 433);
            this.Gb_Sea.TabIndex = 10;
            this.Gb_Sea.TabStop = false;
            this.Gb_Sea.Text = "Gestion des séances";
            // 
            // Txt_Rech
            // 
            this.Txt_Rech.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_Rech.Location = new System.Drawing.Point(18, 89);
            this.Txt_Rech.Name = "Txt_Rech";
            this.Txt_Rech.Size = new System.Drawing.Size(240, 22);
            this.Txt_Rech.TabIndex = 9;
            this.Txt_Rech.Text = "Recherche";
            this.Txt_Rech.Click += new System.EventHandler(this.Txt_Rech_Click);
            this.Txt_Rech.TextChanged += new System.EventHandler(this.Txt_Rech_TextChanged);
            // 
            // Btn_Modifier
            // 
            this.Btn_Modifier.Location = new System.Drawing.Point(435, 189);
            this.Btn_Modifier.Name = "Btn_Modifier";
            this.Btn_Modifier.Size = new System.Drawing.Size(136, 44);
            this.Btn_Modifier.TabIndex = 8;
            this.Btn_Modifier.Text = "Modifier";
            this.Btn_Modifier.UseVisualStyleBackColor = true;
            this.Btn_Modifier.Click += new System.EventHandler(this.Btn_Modifier_Click);
            // 
            // Btn_Supprimer
            // 
            this.Btn_Supprimer.Location = new System.Drawing.Point(435, 261);
            this.Btn_Supprimer.Name = "Btn_Supprimer";
            this.Btn_Supprimer.Size = new System.Drawing.Size(136, 44);
            this.Btn_Supprimer.TabIndex = 7;
            this.Btn_Supprimer.Text = "Supprimer";
            this.Btn_Supprimer.UseVisualStyleBackColor = true;
            this.Btn_Supprimer.Click += new System.EventHandler(this.Btn_Supprimer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Liste des séances";
            // 
            // Btn_Ajouter
            // 
            this.Btn_Ajouter.Location = new System.Drawing.Point(435, 117);
            this.Btn_Ajouter.Name = "Btn_Ajouter";
            this.Btn_Ajouter.Size = new System.Drawing.Size(136, 44);
            this.Btn_Ajouter.TabIndex = 1;
            this.Btn_Ajouter.Text = "Ajouter";
            this.Btn_Ajouter.UseVisualStyleBackColor = true;
            this.Btn_Ajouter.Click += new System.EventHandler(this.Btn_Ajouter_Click);
            // 
            // Dgv_Seance
            // 
            this.Dgv_Seance.AllowUserToAddRows = false;
            this.Dgv_Seance.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Dgv_Seance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Seance.Location = new System.Drawing.Point(18, 117);
            this.Dgv_Seance.Name = "Dgv_Seance";
            this.Dgv_Seance.ReadOnly = true;
            this.Dgv_Seance.RowHeadersVisible = false;
            this.Dgv_Seance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Seance.Size = new System.Drawing.Size(399, 305);
            this.Dgv_Seance.TabIndex = 0;
            // 
            // Seance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 525);
            this.Controls.Add(this.Gb_Sea);
            this.Name = "Seance";
            this.Text = "Seance";
            this.Gb_Sea.ResumeLayout(false);
            this.Gb_Sea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Seance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gb_Sea;
        private System.Windows.Forms.Button Btn_Modifier;
        private System.Windows.Forms.Button Btn_Supprimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Ajouter;
        private System.Windows.Forms.DataGridView Dgv_Seance;
        private System.Windows.Forms.TextBox Txt_Rech;
    }
}