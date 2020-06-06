namespace Mini_Projet
{
    partial class Modifier_Surveillance
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpDateUpdate = new System.Windows.Forms.DateTimePicker();
            this.CbSalleUpdate = new System.Windows.Forms.ComboBox();
            this.CbSeanceUpdate = new System.Windows.Forms.ComboBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Salle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Séance";
            // 
            // DtpDateUpdate
            // 
            this.DtpDateUpdate.Location = new System.Drawing.Point(100, 156);
            this.DtpDateUpdate.Name = "DtpDateUpdate";
            this.DtpDateUpdate.Size = new System.Drawing.Size(200, 20);
            this.DtpDateUpdate.TabIndex = 12;
            // 
            // CbSalleUpdate
            // 
            this.CbSalleUpdate.FormattingEnabled = true;
            this.CbSalleUpdate.Location = new System.Drawing.Point(100, 118);
            this.CbSalleUpdate.Name = "CbSalleUpdate";
            this.CbSalleUpdate.Size = new System.Drawing.Size(200, 21);
            this.CbSalleUpdate.TabIndex = 11;
            this.CbSalleUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // CbSeanceUpdate
            // 
            this.CbSeanceUpdate.FormattingEnabled = true;
            this.CbSeanceUpdate.Location = new System.Drawing.Point(100, 80);
            this.CbSeanceUpdate.Name = "CbSeanceUpdate";
            this.CbSeanceUpdate.Size = new System.Drawing.Size(200, 21);
            this.CbSeanceUpdate.TabIndex = 10;
            this.CbSeanceUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(225, 202);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdate.TabIndex = 9;
            this.BtnUpdate.Text = "Modifier";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(100, 202);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Annuler";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Modifier_Surveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 248);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpDateUpdate);
            this.Controls.Add(this.CbSalleUpdate);
            this.Controls.Add(this.CbSeanceUpdate);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnCancel);
            this.Name = "Modifier_Surveillance";
            this.Text = "Modifier la surveillance";
            this.Load += new System.EventHandler(this.Modifier_Surveillance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpDateUpdate;
        private System.Windows.Forms.ComboBox CbSalleUpdate;
        private System.Windows.Forms.ComboBox CbSeanceUpdate;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnCancel;
    }
}