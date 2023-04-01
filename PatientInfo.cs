using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
namespace OfficeForms
{
    public partial class PatientInfo : Form
    {
        private Patient patient;
        internal Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }
        
        int patientId = 0;
        public PatientInfo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Boolean isEdocsEnabled = ConfigurationManager.AppSettings["eDocumentsEnabled"].Equals("true");

            this.btnViewEditEDoc.Enabled = isEdocsEnabled;
            this.bntNewEdoc.Enabled = isEdocsEnabled;
            this.cmbEDocs.Enabled = isEdocsEnabled;

            this.dgPatients.DataSource = GetPatientList();
            this.cmbHipaa.SelectedIndex = 0;
            this.cmbEDocs.SelectedIndex = 0;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgPatients.DataSource = GetPatientList();
        }

        private DataTable GetPatientList()
        {
            string sql = "SELECT TOP " + lastN.Value.ToString() +
                " patient.patient_no AS ID, patient.last_name AS [Last Name], " +
                " patient.first_name AS [First Name], patient.ss_no AS SSN, " +
                " patient.entry_date AS [Entry Date], " +
                " address.address1, address.address2, " +
                " address.city, address.state, address.zip, " +
                " address.phone1, address.phone2 " +
                " FROM (patient INNER JOIN address " +
                " ON patient.address_no = address.address_no) Where 1=1 ";

            if (lastName.Text != "")
            {
                sql += " and patient.last_name Like '" + lastName.Text + "%'";
            }

            if (txtBithdate.Text != "")
            {
                try
                {
                    DateTime temp = DateTime.ParseExact(txtBithdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    sql += " and patient.birth_date = '" + temp.ToString("yyyy-MM-dd") + "'";
                }
                catch (Exception e)
                {
                    MessageBox.Show("The date must be in format mm/dd/yyyy");
                }

            }

            if (txtPatientNo.Text != "")
            {

                sql += " and patient.patient_no = '" + txtPatientNo.Text + "'";
            }

            sql += " ORDER BY patient.patient_no DESC ";

            OleDbCommand cmd = new OleDbCommand(sql, Utility.GetConnection());

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            return ds.Tables[0];

        }

        private void dgPatients_CellContentClick(object sender, EventArgs e)
        {
            if (dgPatients.SelectedRows.Count > 0)
                patientId = Int32.Parse (dgPatients.SelectedRows[0].Cells[0].Value.ToString());


            patient = Patient.GetPatient(patientId, Utility.GetConnection());
            this.txtAddress1.Text = patient.Address1;
            this.txtAddress2.Text = patient.Address2;
            this.txtCity.Text = patient.City;
            this.txtState.Text = patient.State;
            this.txtZip.Text = patient.Zip;
            this.txtPhone1.Text = patient.Phone1;
            this.txtPhone2.Text = patient.Phone2;

            RefreshEDocs();

            RefreshHipaaDocs();
        }

        private void RefreshHipaaDocs()
        {
            this.dgHipaa.Rows.Clear();
            foreach (Document doc in patient.HipaaDocuments)
            {
                if (Utility.DocTypes.ContainsKey(((int)doc.DocTypeCode).ToString()))
                {
                    this.dgHipaa.Rows.Add(
                        new object[]
                        {
                            doc.Id,
                            Utility.DocTypes [((int)doc.DocTypeCode).ToString()],
                            doc.ExpirationDate.ToShortDateString() ,
                            doc.DocLink
                        }
                    );
                }
            }
        }

        private void RefreshEDocs()
        {
            this.dgEDocs.Rows.Clear();
            foreach (Document doc in patient.EDocuments)
            {
                if (Utility.DocTypes.ContainsKey(((int)doc.DocTypeCode).ToString()))
                {
                    this.dgEDocs.Rows.Add(
                        new object[]
                        {
                            doc.Id,
                            Utility.DocTypes [((int)doc.DocTypeCode).ToString()],
                            doc.ExpirationDate.ToShortDateString(),
                            doc.DocLink
                        }
                    );
                }

            }
        }

        private void patientBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dgPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgEDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgHipaa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bntNewEdoc_Click(object sender, EventArgs e)
        {
            if (cmbEDocs.SelectedIndex < 0)
                return;
            GetNewForm(Document.FormTypes.EDocs, cmbEDocs);
        }

        private void GetNewForm(Document.FormTypes formType, ComboBox cBox)
        {

            DynamicForm df = new DynamicForm();

            Document doc = new Document();
            doc.DocTypeCode = Utility.GetDocTypeCode(cBox.SelectedItem.ToString());
            doc.FormTypeCode = formType;
            df.Document = doc;


            df.Patient = Patient;
            df.Top = 0; df.Left = 0; 
            df.Height = 768;
            df.Width = 1024;
            df.ShowDialog();

            df = null;

            patient = Patient.GetPatient(patientId, Utility.GetConnection());

            RefreshEDocs();
            RefreshHipaaDocs();

        }


        
        private void btnNewHipaa_Click(object sender, EventArgs e)
        {
            if (cmbHipaa.SelectedIndex < 0)
                return;
            GetNewForm(Document.FormTypes.HIPAA, cmbHipaa);
        }

        private void GetTempForm(Document doc)
        {

            DynamicForm df = new DynamicForm();

            df.Document = doc;

            df.Patient = Patient;
            df.Top = 0; df.Left = 0;
            df.Height = 768;
            df.Width = 1024;
            
            df.ShowDialog();
           
            df = null;

            patient = Patient.GetPatient(patientId, Utility.GetConnection());

            RefreshEDocs();
            RefreshHipaaDocs();

        }

        private void btnViewEditHipaa_Click(object sender, EventArgs e)
        {
            if (dgHipaa.SelectedRows.Count == 0)
                return;
            string docId = dgHipaa.SelectedRows[0].Cells[0].Value.ToString();
            GetTempForm(Patient.GetHipaaDocument(Int32.Parse(docId)));

        }

        private void btnViewEditEDoc_Click(object sender, EventArgs e)
        {
            if (dgEDocs.SelectedRows.Count == 0)
                return;

            string docId = dgEDocs.SelectedRows[0].Cells[0].Value.ToString();
            GetTempForm(Patient.GetEDocument(Int32.Parse(docId)));

        }

        private void cmbHipaa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    
    }
}
