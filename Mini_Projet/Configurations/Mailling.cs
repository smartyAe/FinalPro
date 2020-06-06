using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Projet
{
    class Mailling
    {

        private string adresse;
        private string subject = "Programme de surveillance";
        private string message;
        private string join;
        static string folderPath = Application.StartupPath;
        DataTable CurrentDataReportEnseignant = new DataTable();
        DataTable CurrentDataReportProgrammes = new DataTable();
        Configurations.Configurations Conf = new Configurations.Configurations( );

        public string Propadresses
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public string Propsubject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Propmessage
        {
            get { return message; }
            set { message = value; }
        }
        public string Propjoin
        {
            get { return join; }
            set { join = value; }
        }
        public void SendMail(string adrss, string joinPdf, string nom)
        {

            MailMessage mail = new MailMessage();
            //ajouter le  destinataire 
            mail.To.Add(adrss);
            mail.Subject = "Programme de surveillance DS";
            mail.Body = "\n Bonjour " + nom + "\n\n Vous venez de recevoir par attachement votre programme de surveillance.\n Veillez s'il vous plaît consulter le document joint ";
            //définir l'expéditeur
            mail.From = new MailAddress(Conf.LireInfo().PropEmail);


            // Attach a document.  
            mail.Attachments.Add(new Attachment(joinPdf, MediaTypeNames.Application.Pdf));

            //définir les paramètres smtp pour l'envoi
            SmtpClient smtpServer = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Conf.LireInfo().PropEmail, Conf.LireInfo().PropPass)
            };
            //envoi du mail
            smtpServer.Send(mail);
        }

        public void FillMailEnseignants()
        {
            CurrentDataReportEnseignant = new Dal_Enseignant().GetAllEnseignantsDataTable();
            CurrentDataReportEnseignant = ReportData.AdaptDataTableEnseignant(CurrentDataReportEnseignant);

            foreach (DataRow row in CurrentDataReportEnseignant.Rows)
            {
                //MessageBox.Show( row[0].ToString()+ " "+ row[1].ToString()+" "+row[2].ToString());
                FillReportProgrames(Int32.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString());
            }
        }

        public void FillMailEnseignants(DataTable selected )
        {
            
            CurrentDataReportEnseignant = ReportData.AdaptDataTableEnseignant(selected);

            foreach (DataRow row in CurrentDataReportEnseignant.Rows)
            {
                 //MessageBox.Show( row[0].ToString()+ " "+ row[1].ToString()+" "+row[2].ToString());
                FillReportProgrames(Int32.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString());
            }
        }

        


        string MaillingDataTableToPdf(DataTable dtblTable, string Name, string Dept)
        {

            string folder  = Conf.LireInfo().PropDirPath;
            if (!Directory.Exists(folder ))
            {
                folder = @"C:\Users\LMIJ\Downloads\";
                Directory.CreateDirectory(folder );
            }

            //File Name
            int fileCount = Directory.GetFiles(folder).Length;
            string strFileName = "Programmes" + (fileCount + 1) + ".pdf";
            System.IO.FileStream fs = new FileStream(folder  + strFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4, 55f, 30f, 45f, 0f);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            #region Section-Image

            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);
            string imageURL = @"" + folderPath + "\\Logo FSM - Small.png";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

            //Resize image depend upon your need
            jpg.ScaleToFit(90f, 80f);
            //Give space before image
            jpg.SpacingBefore = 45f;
            jpg.IndentationLeft = 55f;
            //Give some space after the image
            jpg.SpacingAfter = 20f;
            document.Add(jpg);
            document.Add(new Chunk("\n", fntHead));
            document.Add(new Chunk("\n", fntHead));
            jpg.Alignment = Element.ALIGN_LEFT;
            #endregion
            //Report Header

            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk("Programme de surveillance".ToUpper(), fntHead));
            document.Add(prgHeading);

            document.Add(new Chunk("\n", fntHead));
            document.Add(new Chunk("\n", fntHead));
            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 12, 2, BaseColor.GRAY);
            prgAuthor.Alignment = Element.ALIGN_LEFT;
            prgAuthor.IndentationLeft = 45f;
            prgAuthor.Add(new Chunk("NOM & PRENOM :" + Name, fntAuthor));
            prgAuthor.Add(new Chunk("\nDEPARTEMENT :" + Dept, fntAuthor));
            document.Add(prgAuthor);


            document.Add(new Chunk("\n", fntHead));
            Paragraph prgMsg = new Paragraph();
            prgMsg.Alignment = Element.ALIGN_CENTER;
            prgMsg.Add(new Chunk("Vous êtes prié de vous présenter aux séances de surveillances ci-dessous", fntAuthor));
            document.Add(prgMsg);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            // Footer Section
            Paragraph prgfooter = new Paragraph();
            BaseFont btnfooter = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntfooter = fntAuthor;
            prgfooter.Alignment = Element.ALIGN_RIGHT;
            prgfooter.IndentationLeft = 45f;
            prgfooter.Add(new Chunk("Fait le " + DateTime.Now.ToShortDateString(), fntAuthor));

            //End Of Footer Section

            document.Add(table);
            document.AddCreationDate();
            document.Add(prgfooter);
            document.NewPage();
            document.Close();
            writer.Close();
            fs.Close();
            return folder + strFileName;
        }


        public void FillReportProgrames(int IdEns, string Name, string Dept)
        {
            CurrentDataReportProgrammes = new Dal_Surveillance().GetSurveillancesByEnseignant(IdEns);
            string adress = CurrentDataReportProgrammes.Rows[0]["Email"].ToString();
            CurrentDataReportProgrammes = ReportData.AdaptDataTableProgrammes(CurrentDataReportProgrammes);
            string pjoint = MaillingDataTableToPdf(CurrentDataReportProgrammes, Name, Dept);
            SendMail(adress, pjoint, Name);
           System.Diagnostics.Process.Start(pjoint);
            
        }


    }
}
