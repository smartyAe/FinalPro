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
    public partial class Ajout_Departement : MetroFramework.Forms.MetroForm
    {
        Dal_Departement Dal_Dept = new Dal_Departement();
        Departements D = new Departements();
        public Ajout_Departement()
        {
            InitializeComponent();
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_Nom.Text) || string.IsNullOrEmpty(Txt_Code.Text))
                {
                    MessageBox.Show("Une ou plusieurs entrées invalides", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    D.PropNom = Txt_Nom.Text;
                    D.PropCode = Txt_Code.Text;
                   
                    Dal_Dept.AddDepartement(D);
                    MessageBox.Show("Ajouté avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (var Txt_Box in this.Controls.OfType<TextBox>())
                    {
                        Txt_Box.Clear();
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ajout_Departement_FormClosed(object sender, FormClosedEventArgs e)
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
