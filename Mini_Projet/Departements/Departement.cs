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
    
    public partial class Departement : MetroFramework.Forms.MetroForm
    {
        Dal_Departement Dal_Dept = new Dal_Departement();
        static public DialogResult Result;
        public Departement()
        {
            InitializeComponent();
            Dgv_Dept.DataSource = Dal_Dept.GetAllDepartementsDataTable();
            if (Dal_Dept.GetAllDepartementsDataTable().Rows.Count == 0)
            {

                Btn_Supprimer.Enabled = false;
                Btn_Modifier.Enabled = false;


            }
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            Ajout_Departement AjoutDept = new Ajout_Departement();
            AjoutDept.ShowDialog();
           
            if (Result == DialogResult.No)
            {
                Dgv_Dept.DataSource = Dal_Dept.GetAllDepartementsDataTable();
            }
        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
           
            DataRowView currentDataRowView = (DataRowView)Dgv_Dept.CurrentRow.DataBoundItem;
            Modifier_Departement ModifierDepartement = new Modifier_Departement(currentDataRowView);
            ModifierDepartement.ShowDialog();

            if (Result == DialogResult.No)
            {
                Dgv_Dept.DataSource = Dal_Dept.GetAllDepartementsDataTable();
            }
        }

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Dept.CurrentRow.DataBoundItem;
            DialogResult Result = MessageBox.Show("Voulez vous supprimer?", "Confirmation de suppression", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information);

            if (Result == DialogResult.Yes)
            {

                Dal_Dept.DeleteDepartement(Dal_Dept.GetDepartementByNom(currentDataRowView.Row[1].ToString()));
                Dgv_Dept.DataSource = Dal_Dept.GetAllDepartementsDataTable();
                MessageBox.Show("Suppression réuissie", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Dal_Dept.GetAllDepartementsDataTable().Rows.Count == 0)
                {

                    Btn_Supprimer.Enabled = false;
                    Btn_Modifier.Enabled = false;


                }

            }
        }

        private void Txt_Rech_Click(object sender, EventArgs e)
        {
             if(Txt_Rech.Text.Equals("Recherche"))
                {
                    Txt_Rech.ForeColor = Color.Black;
                
            }
            Txt_Rech.Clear();

        }

        private void Cbx_Rech_Click(object sender, EventArgs e)
        {
             
        }

        private void Txt_Rech_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Txt_Rech.Text.Trim()))
            {
                Dgv_Dept.DataSource = Dal_Dept.GetAllDepartementsDataTable();
            }
            else
            {
                List<Departements> ListeDepartement = new List<Departements>();
                ListeDepartement = Dal_Dept.GetAllDepartementsList();

                var query = from o in ListeDepartement
                            where o.PropCode.Contains(Txt_Rech.Text) || o.PropNom.Contains(Txt_Rech.Text)
                            select o;
                 Dgv_Dept.DataSource = query.ToList();
            }

        }
    }
}
