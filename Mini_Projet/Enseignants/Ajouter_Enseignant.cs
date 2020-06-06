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
    public partial class Ajouter_Enseignant : MetroFramework.Forms.MetroForm
    {
        Dal_Enseignant Dal_Ens = new Dal_Enseignant();
        Enseignants S = new Enseignants();
        public Ajouter_Enseignant()
        {
            InitializeComponent();
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_Nom.Text) || string.IsNullOrEmpty(Cbx_Dept.Text))
                {
                    MessageBox.Show("Une ou plusieurs entrées invalides", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    S.PropNom = Txt_Nom.Text;
                    S.PropPrenom = Txt_Pren.Text;
                    S.PropEmail = Txt_Email.Text;
                    S.PropDepartements.PropCode = Cbx_Dept.SelectedItem.ToString();

                    Dal_Ens.AddEnseignant(S);
                    MessageBox.Show("Ajouté avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Annuler_Click(object sender, EventArgs e)
        {
            foreach (var Txt_Box in this.Controls.OfType<TextBox>())
            {
                Txt_Box.Clear();
            }
        }

        private void Ajouter_Enseignant_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Dal_Departement Dal_Dept = new Dal_Departement();
            dt = Dal_Dept.GetAllDepartementsDataTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.Cbx_Dept.Items.Add(dt.Rows[i]["Code"]);
            }
        }

        private void Ajouter_Enseignant_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enseignant.Result = DialogResult.No;
        }
    }
}
