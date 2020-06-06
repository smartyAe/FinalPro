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
    public partial class Configuration : MetroFramework.Forms.MetroForm 
    {

        private Configurations.Configurations Conf;
        public Configuration()
        {
            InitializeComponent();
            Conf = new Configurations.Configurations( );
        }
        private void Configuration_Load(object sender, EventArgs e)
        {
            try
            {
                Txt_Email.Text = Conf.LireInfo().PropEmail;
                Txt_Pass.Text = Conf.LireInfo().PropPass;
                Txt_Folder.Text = Conf.LireInfo().PropDirPath+@"\";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Validate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Txt_Email.Text) && !string.IsNullOrWhiteSpace(Txt_Folder.Text))
                {
                    Conf.PropDirPath = Txt_Folder.Text.ToString()+@"\";
                    Conf.PropEmail = Txt_Email.Text.ToString();
                    Conf.PropPass = Txt_Pass.Text.ToString();
                    Conf.EnregisterInfo();
                    MessageBox.Show("Modification réussie", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Browser_Click(object sender, EventArgs e)
        {

            using (var Fbd = new FolderBrowserDialog())
            {
                DialogResult result = Fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(Fbd.SelectedPath))
                {
                    Txt_Folder.Text = Fbd.SelectedPath;

                }
            }
        }
    }
}
