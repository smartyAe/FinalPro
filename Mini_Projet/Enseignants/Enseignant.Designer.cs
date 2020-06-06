namespace Mini_Projet
{
    partial class Enseignant
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Modifier = new System.Windows.Forms.Button();
            this.Btn_Supprimer = new System.Windows.Forms.Button();
            this.Btn_Importer = new System.Windows.Forms.Button();
            this.Btn_Ajouter = new System.Windows.Forms.Button();
            this.Dgv_Enseignant = new System.Windows.Forms.DataGridView();
            this.Txt_Rech = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Enseignant)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Txt_Rech);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Btn_Modifier);
            this.groupBox2.Controls.Add(this.Btn_Supprimer);
            this.groupBox2.Controls.Add(this.Btn_Importer);
            this.groupBox2.Controls.Add(this.Btn_Ajouter);
            this.groupBox2.Controls.Add(this.Dgv_Enseignant);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 435);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestion des enseigants";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Liste des enseignants";
            // 
            // Btn_Modifier
            // 
            this.Btn_Modifier.Location = new System.Drawing.Point(540, 255);
            this.Btn_Modifier.Name = "Btn_Modifier";
            this.Btn_Modifier.Size = new System.Drawing.Size(136, 44);
            this.Btn_Modifier.TabIndex = 4;
            this.Btn_Modifier.Text = "Modifier";
            this.Btn_Modifier.UseVisualStyleBackColor = true;
            this.Btn_Modifier.Click += new System.EventHandler(this.Btn_Modifier_Click);
            // 
            // Btn_Supprimer
            // 
            this.Btn_Supprimer.Location = new System.Drawing.Point(540, 324);
            this.Btn_Supprimer.Name = "Btn_Supprimer";
            this.Btn_Supprimer.Size = new System.Drawing.Size(136, 44);
            this.Btn_Supprimer.TabIndex = 3;
            this.Btn_Supprimer.Text = "Supprimer";
            this.Btn_Supprimer.UseVisualStyleBackColor = true;
            this.Btn_Supprimer.Click += new System.EventHandler(this.Btn_Supprimer_Click);
            // 
            // Btn_Importer
            // 
            this.Btn_Importer.Location = new System.Drawing.Point(540, 186);
            this.Btn_Importer.Name = "Btn_Importer";
            this.Btn_Importer.Size = new System.Drawing.Size(136, 44);
            this.Btn_Importer.TabIndex = 2;
            this.Btn_Importer.Text = "Importer";
            this.Btn_Importer.UseVisualStyleBackColor = true;
            this.Btn_Importer.Click += new System.EventHandler(this.Btn_Importer_Click);
            // 
            // Btn_Ajouter
            // 
            this.Btn_Ajouter.Location = new System.Drawing.Point(540, 117);
            this.Btn_Ajouter.Name = "Btn_Ajouter";
            this.Btn_Ajouter.Size = new System.Drawing.Size(136, 44);
            this.Btn_Ajouter.TabIndex = 1;
            this.Btn_Ajouter.Text = "Ajouter";
            this.Btn_Ajouter.UseVisualStyleBackColor = true;
            this.Btn_Ajouter.Click += new System.EventHandler(this.Btn_Ajouter_Click);
            // 
            // Dgv_Enseignant
            // 
            this.Dgv_Enseignant.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Dgv_Enseignant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Enseignant.Location = new System.Drawing.Point(18, 117);
            this.Dgv_Enseignant.MultiSelect = false;
            this.Dgv_Enseignant.Name = "Dgv_Enseignant";
            this.Dgv_Enseignant.RowHeadersVisible = false;
            this.Dgv_Enseignant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Enseignant.Size = new System.Drawing.Size(503, 305);
            this.Dgv_Enseignant.TabIndex = 0;
            // 
            // Txt_Rech
            // 
            this.Txt_Rech.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_Rech.Location = new System.Drawing.Point(18, 89);
            this.Txt_Rech.Name = "Txt_Rech";
            this.Txt_Rech.Size = new System.Drawing.Size(339, 22);
            this.Txt_Rech.TabIndex = 7;
            this.Txt_Rech.Text = "Recherche";
            this.Txt_Rech.Click += new System.EventHandler(this.Txt_Rech_Click);
            this.Txt_Rech.TextChanged += new System.EventHandler(this.Txt_Rech_TextChanged);
            // 
            // Enseignant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 524);
            this.Controls.Add(this.groupBox2);
            this.Name = "Enseignant";
            this.Text = "Enseignant";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Enseignant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Modifier;
        private System.Windows.Forms.Button Btn_Supprimer;
        private System.Windows.Forms.Button Btn_Importer;
        private System.Windows.Forms.Button Btn_Ajouter;
        private System.Windows.Forms.DataGridView Dgv_Enseignant;
        private System.Windows.Forms.TextBox Txt_Rech;
    }
}