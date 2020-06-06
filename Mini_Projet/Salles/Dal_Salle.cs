using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Projet
{
    class Dal_Salle
    {
        private static OleDbCommand MyOleDbCommand;

        private static DataTable dt = new DataTable();

        static Salles ConvertRowToSalles(DataRow row)
        {

            Salles CurrentSalles = new Salles();

            string Nom = (row["Nom"].ToString().Length != 0) ? row["Nom"].ToString() : "pas de Nom";
            CurrentSalles.PropNom = Nom;

            string Type = (row["Type"].ToString().Length != 0) ? row["Type"].ToString() : "pas de Type";
            CurrentSalles.PropType = Type;


            return CurrentSalles;

        }


        public List<Salles> GetAllSallesList()
        {
            List<Salles> AllSalles = new List<Salles>();

            MyOleDbCommand = new OleDbCommand("select * from [Salles]");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                AllSalles.Add(ConvertRowToSalles(row));
            }

            return AllSalles;
        }

        public DataTable GetAllSallesDataTable()
        {
            MyOleDbCommand = new OleDbCommand("select * from [Salles]");

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            return dt;
        }


        public Salles GetSalleByNom(string Nom)
        {
            Salles SallesSearched = new Salles();

            MyOleDbCommand = new OleDbCommand("select * from [Salles] where Nom = @Nom");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = Nom;

            dt = DBConnection.FunctionToRead(MyOleDbCommand);

            foreach (DataRow row in dt.Rows)
            {
                SallesSearched = ConvertRowToSalles(row);
            }

            if (dt.Rows.Count == 0)
                return null;
            else
                return SallesSearched;
        }

        public void AddSalle(Salles newSalle)
        {

            MyOleDbCommand = new OleDbCommand("insert into [Salles]( Nom,Type  )" +
                                         "values ( @Nom,@Type )");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newSalle.PropNom;
            MyOleDbCommand.Parameters.Add("@Type", OleDbType.VarChar).Value = newSalle.PropType;


            DBConnection.FunctionToWrite(MyOleDbCommand);

        }

        public int UpdateSalle(string OldNom, Salles newSalle)
        {

            MyOleDbCommand = new OleDbCommand("update [Salles] set Nom = @Nom, Type = @Type where Nom ='" + OldNom + "'");

            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = newSalle.PropNom;
            MyOleDbCommand.Parameters.Add("@Type", OleDbType.VarChar).Value = newSalle.PropType;


            return DBConnection.FunctionToWrite(MyOleDbCommand);

        }

        public void DeleteSalle(Salles Salle)
        {
            MyOleDbCommand = new OleDbCommand("delete from [Salles] where Nom= @Nom ");
            MyOleDbCommand.Parameters.Add("@Nom", OleDbType.VarChar).Value = Salle.PropNom;

            DBConnection.FunctionToWrite(MyOleDbCommand);


        }

    }
}
