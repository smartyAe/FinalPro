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
    public partial class Modifier_Salle : MetroFramework.Forms.MetroForm
    {
        Dal_Salle Dal_Salle = new Dal_Salle();
        Salles S = new Salles();
        string oldNom;
        public Modifier_Salle(DataRowView currentDataRowView)
        {
            InitializeComponent();
            this.Txt_Nom.Text = currentDataRowView.Row[0].ToString();
            this.Cbx_Type.Text = currentDataRowView.Row[1].ToString();
            oldNom = currentDataRowView.Row[0].ToString();
        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_Nom.Text) || string.IsNullOrEmpty(Cbx_Type.Text))
                {
                    MessageBox.Show("Une ou plusieurs entrées invalides", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    S.PropNom = Txt_Nom.Text.ToString();
                    S.PropType = Cbx_Type.SelectedItem.ToString();

                    Dal_Salle.UpdateSalle(oldNom, S);
                    MessageBox.Show("Modifié avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Modifier_Salle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Salle.Result = DialogResult.No;
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
