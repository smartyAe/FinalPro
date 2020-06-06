using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Projet
{
    class Dal_Seance
    {
        private static OleDbCommand MyOleDbCommand;
         

        private static DataTable dt = new DataTable();

        static Seances ConvertRowToSeances(DataRow row)
        {

            Seances CurrentSeances = new Seances();

            string Nom = (row["Nom"].ToString().Length != 0) ? row["Nom"].ToString() : "pas de Nom";
            CurrentSeances.PropNom = Nom;

            string Code = (row["Code"].ToString().Length != 0) ? row["Code"].ToString() : "pas de Code";
            CurrentSeances.PropCode = Code;

            string HeureD = (row["HeureDebut"].ToString().Length != 0) ? row["HeureDebut"].ToString() : "pas d'heure";
            CurrentSeances.PropHeureDebut = HeureD;

            string HeureF = (row["HeureFin"].ToString().Length != 0) ? row["HeureFin"].ToString() : "pas d'heure";
            CurrentSeances.PropHeureFin= HeureF;
            
            return CurrentSeances;

        }


        public List<Seances> GetAllSeancesList()
        {
            List<Seances> AllSeances = new List<Seances>();

            MyOleDbCommand = new OleDbCommand("select * from [Seances]");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                AllSeances.Add(ConvertRowToSeances(row));
            }

            return AllSeances;
        }

        public DataTable GetAllSeancesDataTable()
        {
            MyOleDbCommand = new OleDbCommand("select * from [Seances]");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            return dt;
        }


        public Seances GetSeanceByNom(string Nom)
        {
            Seances SeancesSearched = new Seances();

            MyOleDbCommand = new OleDbCommand("select * from [Seances] where Nom = @Nom");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = Nom;

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                SeancesSearched = ConvertRowToSeances(row);
            }

            if (dt.Rows.Count == 0)
                return null;
            else
                return SeancesSearched;
        }

        public void AddSeance(Seances newSeance)
        {

            MyOleDbCommand = new OleDbCommand("insert into [Seances]( Nom,Code, HeureDebut, HeureFin  )" +
                                         "values ( @Nom,@Code, @HeureDebut, @HeureFin )");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newSeance.PropNom;
            MyOleDbCommand.Parameters.Add("@Code", OleDbType.VarChar).Value = newSeance.PropCode; 
            MyOleDbCommand.Parameters.Add("@HeureDebut", OleDbType.VarChar).Value = newSeance.PropHeureDebut;
            MyOleDbCommand.Parameters.Add("@HeureFin", OleDbType.VarChar).Value = newSeance.PropHeureFin;


            DBConnection.FunctionToWrite(MyOleDbCommand);

        }

        public int UpdateSeance(string OldNom, Seances newSeance)
        {

            MyOleDbCommand = new OleDbCommand("update [Seances] set Nom = @Nom, Code = @Code, HeureDebut = @HeureDebut, " +
                                          "HeureFin = @HeureFin where Nom ='"+OldNom+"'" );
            
            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newSeance.PropNom;
            MyOleDbCommand.Parameters.Add("@Code", OleDbType.VarChar).Value = newSeance.PropCode;
            MyOleDbCommand.Parameters.Add("@HeureDebut", OleDbType.VarChar).Value = newSeance.PropHeureDebut;
            MyOleDbCommand.Parameters.Add("@HeureFin", OleDbType.VarChar).Value = newSeance.PropHeureFin;

            return DBConnection.FunctionToWrite(MyOleDbCommand);

        }

        public void DeleteSeance(Seances Seance)
        {
            MyOleDbCommand = new OleDbCommand("delete from [Seances] where Nom= @Nom ");
            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = Seance.PropNom;
            DBConnection.FunctionToWrite(MyOleDbCommand);


        }

    }
}
