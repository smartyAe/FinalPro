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
    public partial class Ajouter_Surveillance : MetroFramework.Forms.MetroForm
    {
        Dal_Salle MyDalSalle = new Dal_Salle();
        Dal_Seance MyDalSeance = new Dal_Seance();

        List<Seances> AllSeances = null;
        List<Salles> AllSalles = null;

        List<Surveillances> AllSurv = null;
        Enseignants CurrentEns = null;

        public Surveillances CurrentSurveillance { get; set; }

        public Ajouter_Surveillance(List<Surveillances> ListSurveillances, Enseignants Ens)
        {
            InitializeComponent();
            AllSurv = ListSurveillances;
            CurrentEns = Ens;
        }
         
        private void Ajouter_Click(object sender, EventArgs e)
        {
            if (!CbSalleAdd.SelectedItem.ToString().ToLower().Equals("pas de salle") &&
                !CbSeanceAdd.SelectedItem.ToString().ToLower().Equals("pas de seance"))
            {
              
                if (SeanceExistAtThisDayAlready(AllSeances[CbSeanceAdd.SelectedIndex], DtpDateSurvAdd.Value))
                {
                    MessageBox.Show("SVP, changer de seance ou de date, car elle existe deja dans le programme");
                }
                else if (CurrentEns != null)
                {
                    CurrentSurveillance = new Surveillances(CurrentEns, AllSeances[CbSeanceAdd.SelectedIndex], AllSalles[CbSalleAdd.SelectedIndex], DtpDateSurvAdd.Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Veuillez selectionner une bonne salle ou seance");
            }
        }
        
        private void Ajouter_Surveillance_Load(object sender, EventArgs e)
        {
            AllSeances = MyDalSeance.GetAllSeancesList();
            AllSalles  = MyDalSalle.GetAllSallesList();
            
            if (AllSeances.Count <= 0)
            {
                CbSeanceAdd.Items.Add("Pas de seance");
            }
            else
            {
                foreach (Seances Row in AllSeances)
                {
                    CbSeanceAdd.Items.Add(Row.PropNom);
                }
            }
            if (AllSalles.Count <= 0)
            {
                CbSalleAdd.Items.Add("Pas de Salle");
            }
            else
            {
                foreach (Salles Row in AllSalles)
                {
                    CbSalleAdd.Items.Add(Row.PropNom);
                }
            }
            CbSeanceAdd.SelectedItem = CbSeanceAdd.Items[0];
            CbSalleAdd.SelectedItem = CbSalleAdd.Items[0];
        }

        private bool SeanceExistAtThisDayAlready(Seances CurrentSeance, DateTime Date)
        {
            foreach(Surveillances Row in AllSurv)
            {

                if (Row.PropSeance.PropCode == CurrentSeance.PropCode && Date.ToShortDateString().Equals(Row.PropDateSurveillance.ToShortDateString()))
                    return true;
            }
            return false;
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
