using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EAH.DataModel;
using EDT_EAH_Algorithm;

namespace EDT_EAH
{
    public partial class Form1 : Form
    {
        private const string cSourceFile = @".\EDT_EAH.xlsx";

        private const string cStudentFile = @".\Meilleur_planning_eleves.xlsx";

        private const string cTeacherFile = @".\Meilleur_planning_profs.xlsx";

        public Form1()
        {
            InitializeComponent();
        }

        private void Manage_Click(object sender, EventArgs e)
        {
            if (File.Exists(cSourceFile))
            {
                if (this.CheckFileIsOpened(cSourceFile) == false)
                {
                    System.Diagnostics.Process.Start(cSourceFile);
                }
            }
            else
            {
                MessageBox.Show("Impossible de trouver le fichier EDT_EAH.xslx", "Erreur");
            }
            
        }

        private void Compute_Click(object sender, EventArgs e)
        {

            if (this.CheckFileIsOpened(cStudentFile))
            {
                MessageBox.Show("Veuillez fermer le fichier Meilleur_planning_eleves.xlsx", "Erreur");
                return;
            }

            if (this.CheckFileIsOpened(cTeacherFile))
            {
                MessageBox.Show("Veuillez fermer le fichier Meilleur_planning_profs.xlsx", "Erreur");
                return;
            }


            Database lDatabase = new Database();
            lDatabase.Initialize(cSourceFile);

            SimpleAlgorithm lAlgorithm = new SimpleAlgorithm();
            List<string> lResult = lAlgorithm.Compute(lDatabase);

            DateTime lDate = DateTime.Parse(lDatabase.Date);

            StudentPlanningExporter lExporter = new StudentPlanningExporter();
            lExporter.Write(@".\", "Meilleur_planning_eleves", lResult, lDate, lDatabase);

            TeacherPlanningExporter lExporter2 = new TeacherPlanningExporter();
            lExporter2.Write(@".\", "Meilleur_planning_profs", lResult, lDate, lDatabase);
        }

        private void DisplayStudent_Click(object sender, EventArgs e)
        {
            if (File.Exists(cStudentFile))
            {
                if (this.CheckFileIsOpened(cStudentFile) == false)
                {
                    System.Diagnostics.Process.Start(cStudentFile);
                }
            }
            else
            {
                MessageBox.Show("Impossible de trouver le fichier Meilleur_planning_eleves.xslx", "Erreur");
            }
        }

        private void DisplayTeachers_Click(object sender, EventArgs e)
        {
            if (File.Exists(cTeacherFile))
            {
                if (this.CheckFileIsOpened(cTeacherFile) == false)
                {
                    System.Diagnostics.Process.Start(cTeacherFile);
                }
            }
            else
            {
                MessageBox.Show("Impossible de trouver le fichier Meilleur_planning_profs.xslx", "Erreur");
            }
        }

        bool CheckFileIsOpened(string pFilepath)
        {
            bool lIsReady = true;
            if (File.Exists(pFilepath))
            {
                try
                {
                    File.Open(pFilepath, FileMode.Open, FileAccess.Write, FileShare.None).Dispose();
                    lIsReady = false;
                }
                catch (IOException)
                {

                }
            }
            return lIsReady;
        }
    }
}
