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
    public partial class Seance : MetroFramework.Forms.MetroForm
    {
        Dal_Seance Dal_Sea = new Dal_Seance();
        static public DialogResult Result;
        public Seance()
        {
            InitializeComponent();
            Dgv_Seance.DataSource = Dal_Sea.GetAllSeancesDataTable();
            if (Dal_Sea.GetAllSeancesDataTable().Rows.Count == 0)
            {

                Btn_Supprimer.Enabled = false;
                Btn_Modifier.Enabled = false;


            }
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter_Seance AjoutSeance = new Ajouter_Seance();
            AjoutSeance.ShowDialog();
            if (Result == DialogResult.No)
            {
                Dgv_Seance.DataSource = Dal_Sea.GetAllSeancesDataTable();
            }


        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Seance.CurrentRow.DataBoundItem;
            Modifier_Seance ModifierSeance = new Modifier_Seance(currentDataRowView);
            ModifierSeance.ShowDialog();
            
            if (Result == DialogResult.No)
            {
                Dgv_Seance.DataSource = Dal_Sea.GetAllSeancesDataTable();
            }

        }

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Seance.CurrentRow.DataBoundItem;
            DialogResult Result = MessageBox.Show("Voulez vous supprimer?", "Confirmation de suppression", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information);

            if (Result == DialogResult.Yes)
            {

                Dal_Sea.DeleteSeance(Dal_Sea.GetSeanceByNom(currentDataRowView.Row[1].ToString()));
                Dgv_Seance.DataSource = Dal_Sea.GetAllSeancesDataTable();
                MessageBox.Show("Suppression réuissie", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Dal_Sea.GetAllSeancesDataTable().Rows.Count == 0)
                {

                    Btn_Supprimer.Enabled = false;
                    Btn_Modifier.Enabled = false;
                    

                }

            }
        }

        private void Txt_Rech_Click(object sender, EventArgs e)
        {
            if (Txt_Rech.Text.Equals("Recherche"))
            {
                Txt_Rech.ForeColor = Color.Black;

            }
            Txt_Rech.Clear();
        }

        private void Txt_Rech_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Rech.Text.Trim()))
            {
                Dgv_Seance.DataSource = Dal_Sea.GetAllSeancesDataTable();
            }
            else
            {
                List<Seances> ListeSeance = new List<Seances>();
                ListeSeance = Dal_Sea.GetAllSeancesList();

                var query = from o in ListeSeance
                            where o.PropCode.Contains(Txt_Rech.Text) || o.PropNom.Contains(Txt_Rech.Text)
                            select o;
                Dgv_Seance.DataSource = query.ToList();
            }
        }
    }   
}
