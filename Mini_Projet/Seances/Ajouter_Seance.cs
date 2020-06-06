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
    public partial class Ajouter_Seance : MetroFramework.Forms.MetroForm
    {
         Dal_Seance Dal_Sea = new Dal_Seance();
        Seances S = new Seances();
        
        public Ajouter_Seance()
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

                        S.PropNom = Txt_Nom.Text;
                        S.PropCode = Txt_Code.Text;
                        DateTime Db = dateTimeDeb.Value;
                        S.PropHeureDebut = Db.ToShortTimeString();
                    MessageBox.Show(S.PropHeureDebut);
                        DateTime Df = dateTimeFin.Value;
                        S.PropHeureFin = Df.ToShortTimeString();
                        Dal_Sea.AddSeance(S);
                        MessageBox.Show("Ajouté avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (var Txt_Box in this.Controls.OfType<TextBox>())
                        {
                            Txt_Box.Clear();
                        }
                        foreach (var DatePicker in this.Controls.OfType<DateTimePicker>())
                        {
                            DatePicker.ResetText();
                        }
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Ajouter_Seance_FormClosed(object sender, FormClosedEventArgs e)
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
