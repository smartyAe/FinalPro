using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Projet
{
    class Dal_Departement
    {
        private static OleDbCommand MyOleDbCommand;

        private static DataTable dt = new DataTable();

        static Departements ConvertRowToDepartements(DataRow row)
        {

            Departements CurrentDepartements = new Departements();

            string Nom = (row["Nom"].ToString().Length != 0) ? row["Nom"].ToString() : "pas de Nom";
            CurrentDepartements.PropNom = Nom;

            string Code = (row["Code"].ToString().Length != 0) ? row["Code"].ToString() : "pas de Code";
            CurrentDepartements.PropCode =Code;


            return CurrentDepartements;

        }


        public List<Departements> GetAllDepartementsList()
        {
            List<Departements> AllDepartements = new List<Departements>();

            MyOleDbCommand = new OleDbCommand("select * from [Departements]");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                AllDepartements.Add(ConvertRowToDepartements(row));
            }

            return AllDepartements;
        }

        public DataTable GetAllDepartementsDataTable()
        {
            MyOleDbCommand = new OleDbCommand("select * from [Departements]");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            return dt;
        }


        public Departements GetDepartementByNom(string Nom)
        {
            Departements DepartementsSearched = new Departements();

            MyOleDbCommand = new OleDbCommand("select * from [Departements] where Nom = @Nom");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = Nom;

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                DepartementsSearched = ConvertRowToDepartements(row);
            }

            if (dt.Rows.Count == 0)
                return null;
            else
                return DepartementsSearched;
        }

        public void AddDepartement(Departements newDepartement)
        {

            MyOleDbCommand = new OleDbCommand("insert into [Departements]( Nom,Code  )" +
                                         "values ( @Nom,@Code )");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newDepartement.PropNom;
            MyOleDbCommand.Parameters.Add("@Code", OleDbType.VarChar).Value = newDepartement.PropCode;


            DBConnection.FunctionToWrite(MyOleDbCommand);

        }

        public int UpdateDepartement(string OldNom, Departements newDepartement)
        {

            MyOleDbCommand = new OleDbCommand("update [Departements] set Nom = @Nom, Code = @Code where Nom ='" + OldNom + "'");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newDepartement.PropNom;
            MyOleDbCommand.Parameters.Add("@Code", OleDbType.VarChar).Value = newDepartement.PropCode;
           

            return DBConnection.FunctionToWrite(MyOleDbCommand);

        }

        public void DeleteDepartement(Departements Dept)
        {
            MyOleDbCommand = new OleDbCommand("delete from [Departements] where Nom= @Nom ");
            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = Dept.PropNom;
            DBConnection.FunctionToWrite(MyOleDbCommand);
            
        }

        
    }
}
