using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Projet
{
    class FormatageEnseignant
    {
        public static List<Enseignants> AllEnseignants = null;

        public static DataTable InitialiseDataGridEnseignant(DataTable CurrentDataTableEnseignant)
        {
            CurrentDataTableEnseignant = new DataTable();
            DataColumn ColumnLigneEnseignant = new DataColumn();

           

            ColumnLigneEnseignant = new DataColumn();
            ColumnLigneEnseignant.DataType = System.Type.GetType("System.String");
            ColumnLigneEnseignant.ColumnName = "Nom";
            ColumnLigneEnseignant.ReadOnly = true;
            ColumnLigneEnseignant.Unique = false;
            // Add the Column to the DataColumnCollection.
            CurrentDataTableEnseignant.Columns.Add(ColumnLigneEnseignant);

            ColumnLigneEnseignant = new DataColumn();
            ColumnLigneEnseignant.DataType = System.Type.GetType("System.String");
            ColumnLigneEnseignant.ColumnName = "Prénom";
            ColumnLigneEnseignant.ReadOnly = true;
            ColumnLigneEnseignant.Unique = false;
            // Add the Column to the DataColumnCollection.
            CurrentDataTableEnseignant.Columns.Add(ColumnLigneEnseignant);

            ColumnLigneEnseignant = new DataColumn();
            ColumnLigneEnseignant.DataType = System.Type.GetType("System.String");
            ColumnLigneEnseignant.ColumnName = "Email";
            ColumnLigneEnseignant.ReadOnly = true;
            ColumnLigneEnseignant.Unique = false;
            // Add the Column to the DataColumnCollection.
            CurrentDataTableEnseignant.Columns.Add(ColumnLigneEnseignant);

            ColumnLigneEnseignant = new DataColumn();
            ColumnLigneEnseignant.DataType = System.Type.GetType("System.String");
            ColumnLigneEnseignant.ColumnName = "Departement";
            ColumnLigneEnseignant.ReadOnly = true;
            ColumnLigneEnseignant.Unique = false;
            // Add the Column to the DataColumnCollection.
            CurrentDataTableEnseignant.Columns.Add(ColumnLigneEnseignant);

            ColumnLigneEnseignant = new DataColumn();
            ColumnLigneEnseignant.DataType = System.Type.GetType("System.String");
            ColumnLigneEnseignant.ColumnName = "Code departement";
            ColumnLigneEnseignant.ReadOnly = true;
            ColumnLigneEnseignant.Unique = false;
            // Add the Column to the DataColumnCollection.
            CurrentDataTableEnseignant.Columns.Add(ColumnLigneEnseignant);



            return CurrentDataTableEnseignant;


        }

        public static DataTable AdaptDataTableEnseignant(DataTable CurrentDataTable)
        {

            AllEnseignants = new List<Enseignants>();

            DataTable Datatable = new DataTable();
            Datatable = InitialiseDataGridEnseignant(Datatable);

            //Get All The Rows Of The First DataTable
            foreach (DataRow row in CurrentDataTable.Rows)
            {

                Enseignants CurrentEnseignant = new Enseignants();

                int Id = 0;

                try
                {
                    Id = int.Parse(row["Id"].ToString());
                }
                catch (Exception e)
                {
                    Id = 0;
                }
                string Nom = (row["Nom"].ToString().Length != 0) ? row["Nom"].ToString() : "pas de Nom";

                string PreNom = (row["Prenom"].ToString().Length != 0) ? row["Prenom"].ToString() : "pas de PreNom";
                string Email = (row["Email"].ToString().Length != 0) ? row["Email"].ToString() : "pas de Email";
                string Status = (row["Statut"].ToString().Length != 0) ? row["Statut"].ToString() : "pas de Status";

                string CodeDep = row["CodeDep"].ToString();

                if (CodeDep.Length != 0)
                {

                    Departements CurrentDepartements = new Departements();

                    string NomDep = (row["NomDep"].ToString().Length != 0) ? row["NomDep"].ToString() : "pas de Nom de Departement";
                    CurrentDepartements.PropNom = NomDep;
                    CurrentDepartements.PropCode = CodeDep;

                    CurrentEnseignant = new Enseignants(Nom, PreNom, Email, Status, CurrentDepartements);
                    Datatable.Rows.Add(
                       
                        Nom, PreNom,Email, CurrentDepartements.PropNom,
                        CurrentDepartements.PropCode
                       
                    );
                }
                else
                {
                    CodeDep = "pas de Departement";
                    CurrentEnseignant = new Enseignants(Nom, PreNom, Email, Status, new Departements("", CodeDep));
                    Datatable.Rows.Add(
                         false,
                         Nom + ' ' + PreNom.Split(' ')[0],
                        "pas de Departement",
                         Status
                     );
                }

                CurrentEnseignant.PropId = Id;
                AllEnseignants.Add(CurrentEnseignant);
            }

            return Datatable;
        }


        public static DataTable AdaptDataTableEnseignant(List<Enseignants> CurrentDataTable)
        {

            AllEnseignants = new List<Enseignants>();

            DataTable Datatable = new DataTable();
            Datatable = InitialiseDataGridEnseignant(Datatable);

            //Get All The Rows Of The First DataTable
            foreach (Enseignants row in CurrentDataTable )
            {

                Enseignants CurrentEnseignant = new Enseignants();

                int Id = 0;

                try
                {
                    Id = row.PropId;
                }
                catch (Exception e)
                {
                    Id = 0;
                }
                string Nom = row.PropNom;

                string PreNom = row.PropPrenom;
                string Email = row.PropEmail;
                string Status = row.PropStatut;

                string CodeDep = row.PropDepartements.PropCode;

                if (CodeDep.Length != 0)
                {

                    Departements CurrentDepartements = new Departements();

                    string NomDep = row.PropDepartements.PropNom;
                    CurrentDepartements.PropNom = NomDep;
                    CurrentDepartements.PropCode = CodeDep;

                    CurrentEnseignant = new Enseignants(Nom, PreNom, Email, Status, CurrentDepartements);
                    Datatable.Rows.Add(

                        Nom, PreNom, Email, CurrentDepartements.PropNom,
                        CurrentDepartements.PropCode

                    );
                }
                else
                {
                    CodeDep = "pas de Departement";
                    CurrentEnseignant = new Enseignants(Nom, PreNom, Email, Status, new Departements("", CodeDep));
                    Datatable.Rows.Add(
                         false,
                         Nom + ' ' + PreNom.Split(' ')[0],
                        "pas de Departement",
                         Status
                     );
                }

                CurrentEnseignant.PropId = Id;
                AllEnseignants.Add(CurrentEnseignant);
            }

            return Datatable;
        }

    }
}
