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
    public partial class Ajouter_Salle : MetroFramework.Forms.MetroForm
    {
        Dal_Salle Dal_Salle = new Dal_Salle();
        Salles S = new Salles();
        public Ajouter_Salle()
        {
            InitializeComponent();
        }

        private void Ajouter_Salle_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_Nom.Text) || string.IsNullOrEmpty(Cbx_Type.Text))
                {
                    MessageBox.Show("Une ou plusieurs entrées invalides", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    S.PropNom = Txt_Nom.Text;
                    S.PropType = Cbx_Type.SelectedItem.ToString();

                    Dal_Salle.AddSalle(S);
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
    }
}
