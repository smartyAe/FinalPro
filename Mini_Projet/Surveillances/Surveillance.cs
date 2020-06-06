using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Mini_Projet
{
    public partial class Surveillance : MetroFramework.Forms.MetroForm 
    {
        private int childFormNumber = 0;

        private Mailling Mail = new Mailling();
        string ChoiceRecherche = "";
        int CurrentIndex = 0;
        int ItemsPrecedant = 0;
        List<Selectionner> listSelect = new List<Selectionner>();
        bool IsUpdated = false, HasLoad = false;

        DataTable CurrentDataTableEnseignant = new DataTable();
        DataTable CurrentDataTableProgrammes = new DataTable();

        DataTable CurrentDataTableEnseignantInit = new DataTable();

        Enseignants CurrentEns = null;
        List<Surveillances> CurrentListSurv = null;
        List<Surveillances> CurrentListSurvInit = null;
         

        public Surveillance()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Fenêtre " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
/*
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        */
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        
        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter_Surveillance AjoutSurv = new Ajouter_Surveillance( 
                    CurrentListSurv, 
                    CurrentEns);
            var result = AjoutSurv.ShowDialog();

            if(result == DialogResult.OK)
            {
                Surveillances NewSurv = new Surveillances(AjoutSurv.CurrentSurveillance);
                CurrentListSurv.Add(NewSurv);

                /*
                foreach (Surveillances Row in CurrentListSurv)
                {
                    MessageBox.Show("Ens : " + Row.PropEnseignant.PropId + " " + Row.PropEnseignant.PropNom + " " + Row.PropEnseignant.PropPrenom + " " + Row.PropEnseignant.PropEmail + " " + Row.PropEnseignant.PropStatut + " " + Row.PropEnseignant.PropDepartements.PropCode + " " + Row.PropEnseignant.PropDepartements.PropNom
                                   + "\n\nSeance : " + Row.PropSeance.PropCode + " " + Row.PropSeance.PropNom + " " + Row.PropSeance.PropHeureDebut + " " + Row.PropSeance.PropHeureFin
                                   + "\n\nSalle : " + Row.PropSalle.PropNom + " " + Row.PropSalle.PropType
                                   + "\n\nDate : " + Row.PropDateSurveillance);
                }*/
                CurrentDataTableProgrammes.Rows.Add(
                         NewSurv.PropSalle.PropNom,
                         NewSurv.PropSeance.PropNom,
                         NewSurv.PropSeance.PropHeureDebut,
                         NewSurv.PropSeance.PropHeureFin,
                         NewSurv.PropDateSurveillance
                     );
                IsUpdated = true;
                DtgListeProgrames.DataSource = CurrentDataTableProgrammes;
            }
        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {

            if (CurrentListSurv != null && CurrentListSurv.Count > 0)
            {
                if (DtgListeProgrames.SelectedCells.Count > 0)
                {
                    int IndexRowSelected = DtgListeProgrames.SelectedCells[0].RowIndex;
                    DataGridViewRow SelectedRow = DtgListeProgrames.Rows[IndexRowSelected];

                    if (SelectedRow.Cells["Nom Salle"].Value != null
                        && SelectedRow.Cells["Nom Salle"].Value.ToString().Trim().Length != 0
                        && IndexRowSelected < CurrentListSurv.Count)
                    {
                        CurrentIndex = IndexRowSelected;
                        //MessageBox.Show("ind " + CurrentIndex + " Count " + CurrentListSurv.Count);
                        Modifier_Surveillance ModifierSurv = new Modifier_Surveillance(
                            CurrentListSurv, CurrentEns, CurrentIndex);

                        if (ModifierSurv.ShowDialog() == DialogResult.OK)
                        {
                            Surveillances NewSurv = new Surveillances(ModifierSurv.CurrentSurveillance);
                            CurrentListSurv.RemoveAt(CurrentIndex);
                            CurrentListSurv.Add(NewSurv);

                            CurrentDataTableProgrammes.Rows.RemoveAt(CurrentIndex);
                            CurrentDataTableProgrammes.Rows.Add(
                                     NewSurv.PropSalle.PropNom,
                                     NewSurv.PropSeance.PropNom,
                                     NewSurv.PropSeance.PropHeureDebut,
                                     NewSurv.PropSeance.PropHeureFin,
                                     NewSurv.PropDateSurveillance
                                 );
                            IsUpdated = true;
                            DtgListeProgrames.DataSource = CurrentDataTableProgrammes;
                        }
                    }
                    else
                        MessageBox.Show("Selectionner un valid programme");
                }
                else
                    MessageBox.Show("Selectionner un programme");
            }
            else
                MessageBox.Show("Ajouter des programmes");
        }
        

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {


            if (CurrentListSurv != null && CurrentListSurv.Count > 0)
            {
                if (DtgListeProgrames.SelectedCells.Count > 0)
                {

                    int IndexRowSelected = DtgListeProgrames.SelectedCells[0].RowIndex;
                    DataGridViewRow SelectedRow = DtgListeProgrames.Rows[IndexRowSelected];

                    if (SelectedRow.Cells["Nom Salle"].Value != null
                        && SelectedRow.Cells["Nom Salle"].Value.ToString().Trim().Length != 0
                        && IndexRowSelected < CurrentListSurv.Count)
                    {
                        CurrentIndex = IndexRowSelected;

                        DialogResult Result = MessageBox.Show("Voulez vous supprimer?", "Confirmation de suppression", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                        if (Result == DialogResult.Yes)
                        {
                            CurrentListSurv.RemoveAt(CurrentIndex);
                            CurrentDataTableProgrammes.Rows.RemoveAt(CurrentIndex);
                            DtgListeProgrames.DataSource = CurrentDataTableProgrammes;
                            IsUpdated = true;

                        }
                    }
                    else
                        MessageBox.Show("Selectionner un valid programme");
                }
                else
                    MessageBox.Show("Selectionner un programme");
            }
            else
                MessageBox.Show("Ajouter des programmes");
        }



        private void TmsOptionRecherche_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem Obj= (ToolStripMenuItem)sender;

            foreach (ToolStripMenuItem Item in TsmOptionRecherche.DropDownItems)
            {
                Item.Checked = false;
            }

            foreach (ToolStripMenuItem Item in TsmRechercheEtat.DropDownItems)
            {
                Item.Checked = false;
            }

            Obj.Checked = true;
            ChoiceRecherche = Obj.Text;
            TxtSearch_value_change(null, null);
        }

        private void TxtSearch_value_change(object sender, EventArgs e)
        {
            List<DataGridViewRow> RowToDelete = new List<DataGridViewRow>();

            if (CurrentDataTableEnseignant != null)
            {
                DtgListeEnseignants.DataSource = Helper.AdaptDataTableEnseignant(CurrentDataTableEnseignantInit);
            }


            if (TsmRechercheNom.Checked)
            {
                if (TxtSearch.Text.Trim().Length != 0)
                {
                    try
                    {
                        DtgListeEnseignants.ClearSelection();
                        foreach (DataGridViewRow row in DtgListeEnseignants.Rows)
                        {
                            if (row.Cells[1].Value != null && !row.Cells[1].Value.ToString().ToLower().Contains(TxtSearch.Text.Trim().ToLower()))
                            {
                                RowToDelete.Add(row);
                            }
                        }

                        foreach (DataGridViewRow CurrentRow in RowToDelete)
                        {
                            DtgListeEnseignants.Rows.Remove(CurrentRow);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Ce Nom n'existe pas, SVP essayer encore. " + exc.StackTrace);
                    }
                }
            }
            else if (TsmRechercheEnCour.Checked)
            {
                try
                {
                    DtgListeEnseignants.ClearSelection();
                    foreach (DataGridViewRow row in DtgListeEnseignants.Rows)
                    {
                        if (row.Cells[3].Value != null && !row.Cells[3].Value.ToString().ToLower().Contains("en cours"))
                        {
                            RowToDelete.Add(row);
                        }
                    }

                    foreach (DataGridViewRow CurrentRow in RowToDelete)
                    {
                        DtgListeEnseignants.Rows.Remove(CurrentRow);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erreur , SVP essayer encore. " + exc.StackTrace);
                }
            }
            else if (TsmRechercheTermine.Checked)
            {
                try
                {
                    DtgListeEnseignants.ClearSelection();
                    foreach (DataGridViewRow row in DtgListeEnseignants.Rows)
                    {
                        if (row.Cells[3].Value != null && !row.Cells[3].Value.ToString().ToLower().Contains("termine"))
                        {
                            RowToDelete.Add(row);
                        }
                    }

                    foreach (DataGridViewRow CurrentRow in RowToDelete)
                    {
                        DtgListeEnseignants.Rows.Remove(CurrentRow);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erreur , SVP essayer encore. " + exc.StackTrace);
                }
            }
            else if(TsmRechercheDepartement.Checked)
            {

                if (TxtSearch.Text.Trim().Length != 0)
                {
                    try
                    {
                        DtgListeEnseignants.ClearSelection();
                        foreach (DataGridViewRow row in DtgListeEnseignants.Rows)
                        {
                            if (row.Cells[2].Value != null && !row.Cells[2].Value.ToString().ToLower().Contains(TxtSearch.Text.Trim().ToLower()))
                            {
                                RowToDelete.Add(row);
                            }
                        }

                        foreach (DataGridViewRow CurrentRow in RowToDelete)
                        {
                            DtgListeEnseignants.Rows.Remove(CurrentRow);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Ce Departement n'existe pas, SVP essayer encore. " + exc.StackTrace);
                    }
                }
            }
        }

        private void Surveillance_Load(object sender, EventArgs e)
        {

            DtgListeEnseignants.DataSource = Helper.InitialiseDataGridEnseignant(CurrentDataTableEnseignant);
            DtgListeProgrames.DataSource = Helper.InitialiseDataGridProgrammes(CurrentDataTableProgrammes);
            FillDtgListeEnseignants();
        }

        public void FillDtgListeEnseignants()
        {
            CurrentDataTableEnseignant = new Dal_Enseignant().GetAllEnseignantsDataTable();
            CurrentDataTableEnseignantInit = CurrentDataTableEnseignant;
            CurrentDataTableEnseignant = Helper.AdaptDataTableEnseignant(CurrentDataTableEnseignant);

            DtgListeEnseignants.DataSource = CurrentDataTableEnseignant;
            DtgListeEnseignants.Columns["Email"].Visible = false;
            HasLoad = true;
            ParameterDetail();

        }

        public void ParameterDetail()
        {

            if (DtgListeEnseignants.SelectedCells.Count > 0)
            {
                int IndexRowSelected = DtgListeEnseignants.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DtgListeEnseignants.Rows[IndexRowSelected];

                if (SelectedRow.Cells["Nom"].Value != null
                    && SelectedRow.Cells["Nom"].Value.ToString().Trim().Length != 0
                    && IndexRowSelected < Helper.AllEnseignants.Count)
                {
                    CurrentIndex = IndexRowSelected;
                    ItemsPrecedant = CurrentIndex;
                    CurrentEns = new Enseignants( Helper.AllEnseignants[IndexRowSelected] );

                    InitialChamp(CurrentEns);
                }
                else
                {
                    CurrentEns = null;
                    ItemsPrecedant = -1;
                    InitialChamp(null);
                }
            }
            else
            {
                CurrentEns = null;
                ItemsPrecedant = -1;
                InitialChamp(null);
            }
        }

        private void InitialChamp(Enseignants CurrentEnseignant)
        {
            if (CurrentEnseignant != null)
            {

                if (CurrentEnseignant.PropNom != null && CurrentEnseignant.PropNom.Trim().Length != 0)
                    LbValueNom.Text = CurrentEnseignant.PropNom + ' ' + CurrentEnseignant.PropPrenom;
                else
                    LbValueNom.Text = "Pas de nom";

                if (CurrentEnseignant.PropDepartements != null && CurrentEnseignant.PropDepartements.PropNom.Trim().Length != 0)
                    LbValueDep.Text = CurrentEnseignant.PropDepartements.PropNom;
                else
                    LbValueDep.Text = "Pas de departement";

                if (CurrentEnseignant.PropStatut.ToLower().Trim().Equals("terminé"))
                    CbEtat.SelectedItem = CbEtat.Items[1];
                else
                    CbEtat.SelectedItem = CbEtat.Items[0];

                FillDtgListeProgrames(CurrentEnseignant.PropId);
            }
            else
            {
                LbValueNom.Text = "Pas de nom";
                LbValueDep.Text = "Pas de departement";
                FillDtgListeProgrames(0);
            }
        }
        
        public void FillDtgListeProgrames(int IdEns)
        {

            CurrentDataTableProgrammes = new Dal_Surveillance().GetSurveillancesByEnseignant(IdEns);
            CurrentListSurv = Helper.ConvertDatatableToListSurveillance(CurrentDataTableProgrammes);
            CurrentListSurvInit = Helper.ConvertDatatableToListSurveillance(CurrentDataTableProgrammes);

            CurrentDataTableProgrammes = Helper.AdaptDataTableProgrammes(CurrentDataTableProgrammes);
            DtgListeProgrames.DataSource = CurrentDataTableProgrammes;
            
        }

        private void DtgListeEns_SelectionChanged()
        {
            if (!IsUpdated)
                ParameterDetail();
            else
            {
                DialogResult Result = MessageBox.Show("Il y'a d , continuer?", "Confirmation de modification", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                if (Result == DialogResult.OK)
                {
                    IsUpdated = false;
                    ParameterDetail();
                }
                else if (Result == DialogResult.Cancel)
                {
                    DtgListeEnseignants.ClearSelection();
                    DtgListeEnseignants.Rows[ItemsPrecedant].Selected = true;
                }
            }
        }
        private void DtgListeEns_click(object sender, EventArgs e)
        {
            
            if (!IsUpdated)
                ParameterDetail();
            else
            {
                DialogResult Result = MessageBox.Show("Il y'a des modifications non enregistrées, continuer?", "Confirmation de modification", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                if (Result == DialogResult.OK)
                {
                    IsUpdated = false;
                    DtgListeEns_SelectionChanged();
                }
            }
        }

        private void DtgListeEns_cell_click(object sender, EventArgs e)
        {
            //if(HasLoad)
               // MessageBox.Show("Cell Click");
            /*
            if (!IsUpdated)
                ParameterDetail();
            else
            {
                DialogResult Result = MessageBox.Show("Il y'a des modifications non enregistrées, continuer?", "Confirmation de modification", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                if (Result == DialogResult.OK)
                {
                    IsUpdated = false;
                    DtgListeEns_SelectionChanged();
                }
            }*/
        }

        private void Btn_Enregistrer_Click(object sender, EventArgs e)
        {
            if (CurrentListSurv != null && CurrentListSurv.Count > 0)
            {
                //MessageBox.Show("A=Count " + CurrentListSurv.Count + " id : " + CurrentEns.PropId);
                Dal_Surveillance MyDal = new Dal_Surveillance();
                MyDal.DeleteSurveillances(CurrentEns.PropId);
                foreach(Surveillances Row in CurrentListSurv)
                {
                    if(Row != null)
                    {
                        MyDal.AddSurveillances(Row);
                    }
                }
                if(CurrentEns != null)
                {
                    CurrentEns.PropStatut = CbEtat.SelectedItem.ToString().ToLower().Trim();
                    new Dal_Enseignant().UpdateEnseignant(CurrentEns.PropEmail, CurrentEns);
                    

                    CurrentDataTableEnseignantInit = null;
                    HasLoad = false;
                    Surveillance_Load(null, null);
                }
                MessageBox.Show("Programme mis à jour !");
            }
            else if (CurrentListSurvInit != null && CurrentListSurvInit.Count > 0)
            {
                 
                Dal_Surveillance MyDal = new Dal_Surveillance();
                MyDal.DeleteSurveillances(CurrentEns.PropId);
                if (CurrentEns != null)
                {
                    CurrentEns.PropStatut = CbEtat.SelectedItem.ToString().ToLower().Trim();
                    new Dal_Enseignant().UpdateEnseignant(CurrentEns.PropEmail, CurrentEns);


                    CurrentDataTableEnseignantInit = null;
                    CurrentListSurvInit = null;
                    Surveillance_Load(null, null);
                }
                MessageBox.Show("Programme mis à jour  !");
            }
            else
                MessageBox.Show("Ajouter des programmes");
            IsUpdated = false;
        }

        private void impressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Programmes Pro = new Programmes();
        }

        private void aTousLesEnseigantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mail.FillMailEnseignants();
            MessageBox.Show("Programmes envoyés aux enseignant avec succès !");
        }

        private void auxEnseignantsSelectionnésToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable data;
           /* foreach (DataGridViewRow row in DtgListeEnseignants.Rows)
            {
                if (row.Cells[0].Value != null )
                {
                    MessageBox.Show(row.Cells[0].Value.ToString() + " " + row.Cells[1].Value.ToString());
                }
            }
             */
            Dal_Enseignant Dal_Ens = new Dal_Enseignant();
            //data = ((DataTable)DtgListeEnseignants.DataSource).Copy();
            foreach (Selectionner select in listSelect)
            {
                string email=DtgListeEnseignants.Rows[select.line].Cells[4].Value.ToString() ;
                data=Dal_Ens.GetEnseignantByEmail2(email) ; 
                Mail.FillMailEnseignants(data);
            }
            
            MessageBox.Show("Programmes envoyés aux enseignant avec succès !");

        }

        private void DtgListeEnseignants_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Selectionner selected = new Selectionner(e.RowIndex, e.ColumnIndex);
            if (listSelect.Count == 0)
            {
                listSelect.Add(selected);
            }
            else
            {
                for (int i = 0; i < listSelect.Count; i++)
                {
                    if (listSelect[i].line == selected.line && listSelect[i].col == selected.col)
                    {
                        listSelect.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        listSelect.Add(selected);
                        break;

                    }
                }

            }

        }

        public static void test(string Tex)
        {
            MessageBox.Show(Tex);
        }
       
         
    }
    public class Selectionner
    {
        public int line;
        public int col;
        public Selectionner()
        {

        }
        public Selectionner(int lin, int col)
        {
            this.line = lin;
            this.col = col;
        }
    }

}
