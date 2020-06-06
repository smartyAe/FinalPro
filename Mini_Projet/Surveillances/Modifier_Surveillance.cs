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
    public partial class Modifier_Surveillance : MetroFramework.Forms.MetroForm
    {

        Dal_Salle MyDalSalle = new Dal_Salle();
        Dal_Seance MyDalSeance = new Dal_Seance();

        List<Seances> AllSeances = null;
        List<Salles> AllSalles = null;

        List<Surveillances> AllSurv = null;
        Enseignants CurrentEns = null;

        public Surveillances CurrentSurveillance { get; set; }
        int IndexCurrent = 0;

        public Modifier_Surveillance(List<Surveillances> ListSurveillances, Enseignants Ens, int Index)
        {
            InitializeComponent();
            AllSurv = ListSurveillances;
            CurrentEns = Ens;
            IndexCurrent = Index;
            CurrentSurveillance = ListSurveillances[Index];
            
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!CbSalleUpdate.SelectedItem.ToString().ToLower().Equals("pas de salle") &&
                !CbSeanceUpdate.SelectedItem.ToString().ToLower().Equals("pas de seance"))
            {

                if (SeanceExistAtThisDayAlready(AllSeances[CbSeanceUpdate.SelectedIndex], DtpDateUpdate.Value))
                {
                    MessageBox.Show("SVP, changer de seance ou de date, car elle existe deja dans le programme");
                }
                else if (CurrentEns != null)
                {
                    CurrentSurveillance = new Surveillances(CurrentEns, AllSeances[CbSeanceUpdate.SelectedIndex], AllSalles[CbSalleUpdate.SelectedIndex], DtpDateUpdate.Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Veuillez selectionner une bonne salle ou seance");
            }
        }
        
        private bool SeanceExistAtThisDayAlready(Seances CurrentSeance, DateTime Date)
        {
            int i = 0;
            foreach (Surveillances Row in AllSurv)
            {
                if (i != IndexCurrent && Row.PropSeance.PropCode.Trim().ToLower().Equals(CurrentSeance.PropCode.Trim().ToLower()) && Date.ToShortDateString().Equals(Row.PropDateSurveillance.ToShortDateString()))
                    return true;
                i++;
            }
            return false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Modifier_Surveillance_Load(object sender, EventArgs e)
        {
            AllSeances = MyDalSeance.GetAllSeancesList();
            AllSalles = MyDalSalle.GetAllSallesList();

            int IndexSeance = -1;
            int IndexSalle = -1;

            if (AllSeances.Count <= 0)
            {
                CbSeanceUpdate.Items.Add("Pas de seance");
            }
            else
            {
                int i = 0;
                foreach (Seances Row in AllSeances)
                {
                    if(Row.PropCode.ToLower().Equals(CurrentSurveillance.PropSeance.PropCode.ToLower()))
                    {
                        IndexSeance = i;
                    }
                    i++;
                    CbSeanceUpdate.Items.Add(Row.PropNom);
                }
            }
            if (AllSalles.Count <= 0)
            {
                CbSalleUpdate.Items.Add("Pas de Salle");
            }
            else
            {
                int i = 0;
                foreach (Salles Row in AllSalles)
                {
                    if (Row.PropNom.ToLower().Equals(CurrentSurveillance.PropSalle.PropNom.ToLower()))
                    {
                        IndexSalle = i;
                    }
                    i++;
                    CbSalleUpdate.Items.Add(Row.PropNom);
                }
            }
            if(IndexSeance > -1)
            {
                CbSeanceUpdate.SelectedItem = CbSeanceUpdate.Items[IndexSeance];
            }
            else
                CbSeanceUpdate.SelectedItem = CbSeanceUpdate.Items[0];

            if (IndexSalle > -1)
            {
                CbSalleUpdate.SelectedItem = CbSalleUpdate.Items[IndexSalle];
            }
            else
                CbSalleUpdate.SelectedItem = CbSalleUpdate.Items[0];

            DtpDateUpdate.Value = CurrentSurveillance.PropDateSurveillance;
        }
    }
}
