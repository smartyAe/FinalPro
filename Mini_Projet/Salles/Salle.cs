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
    public partial class Salle : MetroFramework.Forms.MetroForm
    {
        Dal_Salle Dal_Salle = new Dal_Salle();
        static public DialogResult Result;
        public Salle()
        {
            InitializeComponent();
            Dgv_Salle.DataSource = Dal_Salle.GetAllSallesDataTable();
            if (Dal_Salle.GetAllSallesDataTable().Rows.Count == 0)
            {

                Btn_Supprimer.Enabled = false;
                Btn_Modifier.Enabled = false;
            }
        }

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Salle.CurrentRow.DataBoundItem;
            DialogResult Result = MessageBox.Show("Voulez vous supprimer?", "Confirmation de suppression", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information);

            if (Result == DialogResult.Yes)
            {

                Dal_Salle.DeleteSalle(Dal_Salle.GetSalleByNom(currentDataRowView.Row[0].ToString()));
                Dgv_Salle.DataSource = Dal_Salle.GetAllSallesDataTable();
                MessageBox.Show("Suppression réuissie", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Dal_Salle.GetAllSallesDataTable().Rows.Count == 0)
                {

                    Btn_Supprimer.Enabled = false;
                    Btn_Modifier.Enabled = false;


                }

            }
        }


        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter_Salle AjoutSalle = new Ajouter_Salle();
            AjoutSalle.ShowDialog();
        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Salle.CurrentRow.DataBoundItem;
            Modifier_Salle ModifierSalle = new Modifier_Salle(currentDataRowView);
            ModifierSalle.ShowDialog();

            if (Result == DialogResult.No)
            {
                Dgv_Salle.DataSource = Dal_Salle.GetAllSallesDataTable();
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
                Dgv_Salle.DataSource = Dal_Salle.GetAllSallesDataTable();
            }
            else
            {
                List<Salles> ListeSalle = new List<Salles>();
                ListeSalle = Dal_Salle.GetAllSallesList();

                var query = from o in ListeSalle
                            where o.PropType.Contains(Txt_Rech.Text) || o.PropNom.Contains(Txt_Rech.Text)
                            select o;
                Dgv_Salle.DataSource = query.ToList();
            }
        }
    }
}

