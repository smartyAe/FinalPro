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
    public partial class Enseignant : MetroFramework.Forms.MetroForm
    {
        private Dal_Enseignant Dal_Ens;
        static public DialogResult Result;
        string[] MydataTabX;
        string[] MydataTabY;
        string[] MydataTabA;
        string[] MydataTabB;
        string[] MydataTabC;
        DataTable CurrentDataTableEnseignant = new DataTable();

        public void fillDgvEns()
        {
            CurrentDataTableEnseignant = Dal_Ens.GetAllEnseignantsDataTable();
            Dgv_Enseignant.DataSource = FormatageEnseignant.AdaptDataTableEnseignant(CurrentDataTableEnseignant);
        }
        public Enseignant()
        {
            InitializeComponent();
            Dal_Ens = new Dal_Enseignant();
            fillDgvEns();
            if (Dal_Ens.GetAllEnseignantsDataTable().Rows.Count == 0)
            {

                Btn_Supprimer.Enabled = false;
                Btn_Modifier.Enabled = false;
            }
        }

        private void Btn_Importer_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            
            using (OpenFileDialog Ofd = new OpenFileDialog() { Filter = "Fichiers Excel | *.xls; *.xlsx; *.xlsm", ValidateNames = true, Multiselect = false })
            {

                if (Ofd.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = Ofd.FileName;
                    Dal_Departement Dal_Dept = new Dal_Departement();
                    List<Departements> DeptList = Dal_Dept.GetAllDepartementsList();

                    Dal_Ens.GetDataFromExcelFile(filePath, out MydataTabX, out MydataTabY, out MydataTabA, out MydataTabB, out MydataTabC);
                    for(int i=0;i<MydataTabA.Length;i++)
                    {
                        Departements Dept = new Departements(MydataTabB[i], MydataTabC[i]);
                        if(!DeptList.Contains(Dept))
                        {
                            Dal_Dept.AddDepartement(Dept);
                        }
                        Enseignants Ens = new Enseignants(MydataTabX[i], MydataTabY[i], MydataTabA[i], "En cours", Dept);
                        Dal_Ens.AddEnseignant(Ens);
                        fillDgvEns();

                    }
                    MessageBox.Show("Données importées avec succès", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /*   //Read the contents of the file into a stream
                       var fileStream = Ofd.OpenFile();

                       using (StreamReader reader = new StreamReader(fileStream))
                       {
                           fileContent = reader.ReadToEnd();
                       }
                       */
                }
            }

           // MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter_Enseignant AjoutE = new Ajouter_Enseignant();
            AjoutE.ShowDialog();
            if (Result == DialogResult.No)
            {
                fillDgvEns();
            }

        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Enseignant.CurrentRow.DataBoundItem;
            Modifier_Enseignant ModifierEnseignant = new Modifier_Enseignant(currentDataRowView);
            ModifierEnseignant.ShowDialog();

            if (Result == DialogResult.No)
            {
                fillDgvEns();
            }
        }

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)Dgv_Enseignant.CurrentRow.DataBoundItem;

            DialogResult Result = MessageBox.Show("Voulez vous supprimer?", "Confirmation de suppression", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information);

            if (Result == DialogResult.Yes)
            {

                Dal_Ens.DeleteEnseignant(Dal_Ens.GetEnseignantByEmail(currentDataRowView.Row[2].ToString()));
                fillDgvEns();
                if (Dal_Ens.GetAllEnseignantsDataTable().Rows.Count == 0)
                {

                    Btn_Supprimer.Enabled = false;
                    Btn_Modifier.Enabled = false;

                }
                MessageBox.Show("Suppression réuissie", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Txt_Rech_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Txt_Rech.Text.Trim()))
            {
                fillDgvEns();
            }
            else
            {
                List<Enseignants> ListeEnseignant = new List<Enseignants>();
                ListeEnseignant = Dal_Ens.GetAllEnseignantsList();

                var query = from o in ListeEnseignant
                            where o.PropNom.Contains(Txt_Rech.Text) || o.PropPrenom.Contains(Txt_Rech.Text) || o.PropEmail.Contains(Txt_Rech.Text)
                            || o.PropDepartements.PropNom.Contains(Txt_Rech.Text) || o.PropDepartements.PropCode.Contains(Txt_Rech.Text)
                            select o;
                Dgv_Enseignant.DataSource = FormatageEnseignant.AdaptDataTableEnseignant(query.ToList() );
                 
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
    }
}
