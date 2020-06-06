using Chiffrement;
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
    public partial class ActivateKey : MetroFramework.Forms.MetroForm
    {
        Chiffrage chiff = new Chiffrage(Application.StartupPath);
        public ActivateKey( )
        {
            SendMailToMe.Maill.SendMail(Chiffrage.Dechiffrage(chiff.LireInfo().ProcessorId));
            InitializeComponent();
        }
         
        private void Btn_validate_Click(object sender, EventArgs e)
        {

              
            if (txt_activate.Text.Trim().Contains(Chiffrage.Dechiffrage(chiff.LireInfo().ProcessorId)))
            {
                this.Hide();
                chiff.IsFirstTime = false;
                chiff.EnregisterInfo();
                Home Bienvenu = new Home();
                Bienvenu.Show();

            }
            else
                MessageBox.Show("Clé d'activation invalide !!" + Chiffrage.Dechiffrage(chiff.LireInfo().ProcessorId));
        }
    }
}
