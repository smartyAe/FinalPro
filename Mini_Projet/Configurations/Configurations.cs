using Chiffrement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Projet.Configurations
{
    [Serializable]
    class Configurations
    {
        private string DirPath;
        private string Email;
        private string Pass;
        private string Key;
        public bool IsFirstTime = false;

        public string PropDirPath
        {
            get { return DirPath; }
            set { DirPath = value; }
        }

        public string PropEmail
        {
            get { return Email; }
            set { Email = value; }
        }
        public string PropPass
        {
            get { return Pass; }
            set { Pass = value; }
        }

        public string PropKey
        {
            get { return Chiffrage.Dechiffrage(Key); }
            set {Key = value; }
        }
        private string folderPath;

        public Configurations( )
        {
              
        }
        public void EnregisterInfo( )
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream output = new FileStream(@""+ Application.StartupPath + "\\Userconfig.dat", FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(output, this);
            output.Close();
        }

        public Configurations LireInfo()
        {
            BinaryFormatter reader = new BinaryFormatter();
            FileStream input = new FileStream(@"" + Application.StartupPath + "\\Userconfig.dat", FileMode.Open, FileAccess.Read);
            Configurations Configurations1 = (Configurations)reader.Deserialize(input);
            input.Close();
            return Configurations1;
        }

    }
}
