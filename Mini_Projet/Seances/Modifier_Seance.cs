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
    public partial class Modifier_Seance : MetroFramework.Forms.MetroForm
    {
        Dal_Seance Dal_Sea = new Dal_Seance();
        Seances S = new Seances();
        string oldNom;
        public Modifier_Seance(DataRowView currentDataRowView)
        {
            InitializeComponent();
            this.Txt_Nom.Text = currentDataRowView.Row[1].ToString();
            this.Txt_Code.Text = currentDataRowView.Row[0].ToString();
            this.dateTimeDeb.Text = currentDataRowView.Row[2].ToString();
            this.dateTimeFin.Text = currentDataRowView.Row[3].ToString();
            oldNom = currentDataRowView.Row[1].ToString();
        }

        private void Modifier_Seance_Load(object sender, EventArgs e)
        {

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

                    S.PropNom = Txt_Nom.Text.ToString();
                    S.PropCode = Txt_Code.Text.ToString();
                    S.PropHeureDebut = dateTimeDeb.Text.ToString();
                    S.PropHeureFin = dateTimeFin.Text.ToString();
                    Dal_Sea.UpdateSeance(oldNom, S);
                    MessageBox.Show("Modifié avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                   
                    this.Close();
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Modifier_Seance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Seance.Result = DialogResult.No;
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
