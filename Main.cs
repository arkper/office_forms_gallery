using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OfficeForms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        
        }
        

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientInfo pi = new PatientInfo();
            pi.MdiParent = this;
            pi.Show();
            //Form1 f = new Form1();
            //f.MdiParent = this;
            //f.Show();

        }

        private void correspondenceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportView ri = new ReportView();
            ri.MdiParent = this;
            ri.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void signinSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SigninSheetView ssv = new SigninSheetView();
            ssv.MdiParent = this;
            ssv.Show();

        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SigninSheet ss = new SigninSheet();
            ss.MdiParent = this;
            ss.Show();

        }

        private void signinSheetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SigninSheetView ssv = new SigninSheetView();
            ssv.MdiParent = this;
            ssv.Show();

        }

        private void releaseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicForm df = new DynamicForm();

            Document doc = new Document();
            doc.DocTypeCode = Document.DocTypes.ReleaseOfMedicalInfo;

            doc.FormTypeCode = Document.FormTypes.EDocs;

            df.Document = doc;


            df.Patient = new Patient();

            df.Top = 0; df.Left = 0;
            df.Height = 768;
            df.Width = 1024;
            df.ShowDialog();

            df = null;


        }

        private void consentToExaminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicForm df = new DynamicForm();

            Document doc = new Document();
            doc.DocTypeCode = Document.DocTypes.Consent;

            doc.FormTypeCode = Document.FormTypes.EDocs;

            df.Document = doc;


            df.Patient = new Patient();

            df.Top = 0; df.Left = 0;
            df.Height = 768;
            df.Width = 1024;
            df.ShowDialog();

            df = null;
        }

        private void medicaidEyeglassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicForm df = new DynamicForm();

            Document doc = new Document();
            doc.DocTypeCode = Document.DocTypes.MedicaidEyeglasses;

            doc.FormTypeCode = Document.FormTypes.EDocs;

            df.Document = doc;


            df.Patient = new Patient();

            df.Top = 0; df.Left = 0;
            df.Height = 768;
            df.Width = 1024;
            df.ShowDialog();

            df = null;
        }

        private void transportationApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicForm df = new DynamicForm();

            Document doc = new Document();
            doc.DocTypeCode = Document.DocTypes.TransportationApproval;

            doc.FormTypeCode = Document.FormTypes.EDocs;

            df.Document = doc;


            df.Patient = new Patient();

            df.Top = 0; df.Left = 0;
            df.Height = 768;
            df.Width = 1024;
            df.ShowDialog();

            df = null;
        }
    }
}
