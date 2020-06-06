namespace Mini_Projet 
{
    partial class ActivateKey
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
            this.Btn_validate = new System.Windows.Forms.Button();
            this.txt_activate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_validate
            // 
            this.Btn_validate.Location = new System.Drawing.Point(295, 111);
            this.Btn_validate.Name = "Btn_validate";
            this.Btn_validate.Size = new System.Drawing.Size(93, 25);
            this.Btn_validate.TabIndex = 0;
            this.Btn_validate.Text = "Valider";
            this.Btn_validate.UseVisualStyleBackColor = true;
            this.Btn_validate.Click += new System.EventHandler(this.Btn_validate_Click);
            // 
            // txt_activate
            // 
            this.txt_activate.Location = new System.Drawing.Point(48, 114);
            this.txt_activate.Name = "txt_activate";
            this.txt_activate.Size = new System.Drawing.Size(224, 20);
            this.txt_activate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(23, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Veillez entrer le code d\'activation s\'il vous plait";
            // 
            // ActivateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 159);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_activate);
            this.Controls.Add(this.Btn_validate);
            this.Name = "ActivateKey";
            this.Text = "ActivateKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_validate;
        private System.Windows.Forms.TextBox txt_activate;
        private System.Windows.Forms.Label label1;
    }
}