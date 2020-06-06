using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Projet
{
    public partial class Modifier_Departement : MetroFramework.Forms.MetroForm
    {
        Dal_Departement Dal_Dept = new Dal_Departement();
        Departements D= new Departements();
        string oldNom;
        public Modifier_Departement(DataRowView currentDataRowView)
        {
            InitializeComponent();
            this.Txt_Nom.Text = currentDataRowView.Row[1].ToString();
            this.Txt_Code.Text = currentDataRowView.Row[0].ToString();

            oldNom = currentDataRowView.Row[1].ToString();
        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_Nom.Text) || string.IsNullOrEmpty(Txt_Code.Text))
                {
                    MessageBox.Show("Une ou plusieurs entrées invalides", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    D.PropNom = Txt_Nom.Text.ToString();
                    D.PropCode = Txt_Code.Text.ToString();
                   
                    Dal_Dept.UpdateDepartement(oldNom, D);
                    MessageBox.Show("Modifié avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Modifier_Departement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Departement.Result = DialogResult.No;
        }

        private void Btn_Annuler_Click(object sender, EventArgs e)
        {
            foreach (var Txt_Box in this.Controls.OfType<TextBox>())
            {
                Txt_Box.Clear();
            }
        }
    }
}
