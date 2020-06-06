using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Projet
{
    class Dal_Enseignant
    {

        private static OleDbCommand MyOleDbCommand;
        
        private static DataTable dt = new DataTable();

        static Enseignants ConvertRowToEnseignants(DataRow row)
        {

            Enseignants CurrentEnseignants = new Enseignants();

            int Id = int.Parse(row["Id"].ToString());
            CurrentEnseignants.PropId = Id;

            string Nom = (row["Nom"].ToString().Length != 0) ? row["Nom"].ToString() : "pas de Nom";
            CurrentEnseignants.PropNom = Nom;

            string Prenom = (row["Prenom"].ToString().Length != 0) ? row["Prenom"].ToString() : "pas de Prenom ";
            CurrentEnseignants.PropPrenom = Prenom;

            string Email = (row["Email"].ToString().Length != 0) ? row["Email"].ToString() : "pas d'Email";
            CurrentEnseignants.PropEmail = Email;

            string Statut = (row["Statut"].ToString().Length != 0) ? row["Statut"].ToString() : "pas de statut";
            CurrentEnseignants.PropStatut = Statut;

            string CodeDep = row["CodeDep"].ToString();

            if (CodeDep.Length != 0)
            {

                Departements CurrentDepartements = new Departements();

                string NomDep = (row["NomDep"].ToString().Length != 0) ? row["NomDep"].ToString() : "pas de Nom de Departement";
                CurrentDepartements.PropNom = NomDep;
                CurrentDepartements.PropCode = CodeDep;

                CurrentEnseignants.PropDepartements = new Departements(CurrentDepartements);
            }
            else
            {
                CodeDep = "pas de Departement";
                CurrentEnseignants.PropDepartements = null;
            }

            return CurrentEnseignants;

        }
        
        public List<Enseignants> GetAllEnseignantsList()
        {
            List<Enseignants> AllEnseignants = new List<Enseignants>();

            MyOleDbCommand = new OleDbCommand("select E.Id, E.Nom, E.Prenom, E.Email, E.Statut, E.CodeDep, D.Nom as NomDep from [Enseignants] as E, Departements as D where D.Code = E.CodeDep");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                AllEnseignants.Add(ConvertRowToEnseignants(row));
            }

            return AllEnseignants;
        }

        public DataTable GetAllEnseignantsDataTable()
        {

            MyOleDbCommand = new OleDbCommand("select E.Id, E.Nom, E.Prenom, E.Email, E.Statut, E.CodeDep, D.Nom as NomDep from [Enseignants] as E, Departements as D where D.Code = E.CodeDep");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            return dt;

        }
        
        public Enseignants GetEnseignantByEmail(string Email)
        {
            Enseignants EnseignantsSearched = new Enseignants();

            MyOleDbCommand = new OleDbCommand("select E.id, E.Nom, E.Prenom, E.Email, E.Statut, E.CodeDep, D.Nom as NomDep from [Enseignants] as E, Departements as D where Email = @Email and D.Code = E.CodeDep");

            MyOleDbCommand.Parameters.Add("@Email", OleDbType.VarChar).Value =Email;

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                EnseignantsSearched = ConvertRowToEnseignants(row);
            }

            if (dt.Rows.Count == 0)
                return null;
            else
                return EnseignantsSearched;
        }

        public DataTable GetEnseignantByEmail2(string Email)
        {
             

            MyOleDbCommand = new OleDbCommand("select E.id, E.Nom, E.Prenom, E.Email, E.Statut, E.CodeDep, D.Nom as NomDep from [Enseignants] as E, Departements as D where Email = @Email and D.Code = E.CodeDep");

            MyOleDbCommand.Parameters.Add("@Email", OleDbType.VarChar).Value = Email;

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            return dt;
        }

        public void AddEnseignant(Enseignants newEnseignant )
        {

            MyOleDbCommand = new OleDbCommand("insert into [Enseignants]( Nom,Prenom,Email,Statut, CodeDep )" +
                                         "values ( @Nom,@Prenom,@Email,@Statut, @CodeDep )");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newEnseignant.PropNom;
            MyOleDbCommand.Parameters.Add("@Prenom", OleDbType.VarChar).Value = newEnseignant.PropPrenom;
            MyOleDbCommand.Parameters.Add("@Email", OleDbType.VarChar).Value = newEnseignant.PropEmail;
            MyOleDbCommand.Parameters.Add("@Statut", OleDbType.VarChar).Value = "En cours";
            MyOleDbCommand.Parameters.Add("@CodeDep", OleDbType.VarChar).Value = newEnseignant.PropDepartements.PropCode;


            DBConnection.FunctionToWrite(MyOleDbCommand);

        }
         
        public int UpdateEnseignant(string Email, Enseignants newEnseignant)
        {

            MyOleDbCommand = new OleDbCommand("update [Enseignants] set Nom = @Nom, Prenom = @Prenom, Statut=@Statut , Email = @Email, " +
                                          " CodeDep = @CodeDep where Email = @OldEmail ");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newEnseignant.PropNom;
            MyOleDbCommand.Parameters.Add("@Prenom", OleDbType.VarChar).Value = newEnseignant.PropPrenom;
            MyOleDbCommand.Parameters.Add("@Statut", OleDbType.VarChar).Value = newEnseignant.PropStatut;
            MyOleDbCommand.Parameters.Add("@Email", OleDbType.VarChar).Value = newEnseignant.PropEmail;
            MyOleDbCommand.Parameters.Add("@CodeDep", OleDbType.VarChar).Value = newEnseignant.PropDepartements.PropCode;

            MyOleDbCommand.Parameters.Add("@OldEmail", OleDbType.VarChar).Value = Email;

            return DBConnection.FunctionToWrite(MyOleDbCommand);

        }
        public void DeleteEnseignant(Enseignants Individu)
        { 
            MyOleDbCommand = new OleDbCommand("delete from [Enseignants] where Email= @Email ");
            MyOleDbCommand.Parameters.Add("@Email", OleDbType.VarChar).Value = Individu.PropEmail;
            DBConnection.FunctionToWrite(MyOleDbCommand);


        }

        public bool CheckUniqueMail(string Email)
        {
            dt = GetAllEnseignantsDataTable();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Email"].ToString() ==Email)
                {
                    return false;
                }
            }

            return true;
        }

        public void GetDataFromExcelFile(string FileName, out string[] DataTabx, out string[] DataTaby, out string[] DataTaba, out string[] DataTabb, out string[] DataTabc)
        {
            Microsoft.Office.Interop.Excel.Application oXL = null;
            Microsoft.Office.Interop.Excel._Workbook oWB = null;
            Microsoft.Office.Interop.Excel._Worksheet oSheet = null;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oWB = oXL.Workbooks.Open(FileName);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
                // oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.Sheets[1];
                object[,] xlRange = oSheet.UsedRange.Columns[1, Type.Missing].Value;
                object[,] ylRange = oSheet.UsedRange.Columns[2, Type.Missing].Value;
                object[,] alRange = oSheet.UsedRange.Columns[3, Type.Missing].Value;
                object[,] blRange = oSheet.UsedRange.Columns[4, Type.Missing].Value;
                object[,] clRange = oSheet.UsedRange.Columns[4, Type.Missing].Value;
                int LastLine = oSheet.UsedRange.Rows.Count;
                int LastColumn = oSheet.UsedRange.Columns.Count;
                DataTabx = new string[LastLine];
                DataTaby = new string[LastLine];
                DataTaba = new string[LastLine];
                DataTabb = new string[LastLine];
                DataTabc = new string[LastLine];


                for (int line = 1; line <= xlRange.Length; line++)
                {
                    // this line does only one COM interop call for the whole column
                    object[,] currentColumn = xlRange;
                    object val = currentColumn[line, 1];
                    DataTabx[line - 1] =  val.ToString() ;


                }
                for (int line = 1; line <= ylRange.GetLength(0); line++)
                {
                    // this line does only one COM interop call for the whole column

                    object[,] currentColumnb = ylRange;
                    object val = currentColumnb[line, 1];
                    DataTaby[line - 1] =  val.ToString() ;

                }
                for (int line = 1; line <= alRange.GetLength(0); line++)
                {
                    // this line does only one COM interop call for the whole column
                    object[,] currentColumna = alRange;
                    object val = currentColumna[line, 1];
                    DataTaba[line - 1] =  val.ToString() ;


                }
                for (int line = 1; line <= blRange.GetLength(0); line++)
                {
                    // this line does only one COM interop call for the whole column
                    object[,] currentColumnc = blRange;
                    object val = currentColumnc[line, 1];
                    DataTabb[line - 1] =  val.ToString() ;


                }
                for (int line = 1; line <= clRange.GetLength(0); line++)
                {
                    // this line does only one COM interop call for the whole column
                    object[,] currentColumnc = clRange;
                    object val = currentColumnc[line, 1];
                    DataTabc[line - 1] = val.ToString();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DataTaby = null;
                DataTabx = null;
                DataTaba = null;
                DataTabb = null;
                DataTabc = null;
            }
            finally
            {
                if (oWB != null)
                    oWB.Close();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oWB);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oXL);
            }
        }
    }
}
