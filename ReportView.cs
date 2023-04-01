using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;
using System.IO;
namespace OfficeForms
{
    public partial class ReportView : Form
    {

        static Dictionary<string, string> insuranceCompanies;
        static Dictionary<string, string> recallTypes;

        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {

            if (insuranceCompanies == null)
            {
                Utility.GetInsuranceCompanies(ref insuranceCompanies);
            }
            if (recallTypes == null)
                Utility.GetRecallTypes(ref recallTypes);


            PopulateComboBoxes();

            string[] entries = null;
            try
            {
                TextReader tr = new StreamReader(Application.StartupPath + "/correspondence.txt");
                string allEntries = tr.ReadToEnd();
                tr.Close();
                entries = allEntries.Split(new char[] { ',' });
            }
            catch (Exception ex1) { }

            if (entries != null)
            {
                dateTimePicker1.Value = DateTime.Parse (entries[0]);
                dateTimePicker2.Value = DateTime.Parse(entries[1]);
                dateTimePicker3.Value = DateTime.Parse(entries[2]);
                dateTimePicker4.Value = DateTime.Parse(entries[3]);
                dateTimePicker5.Value = DateTime.Parse(entries[4]);
                dateTimePicker6.Value = DateTime.Parse(entries[5]);
                recalls.Text = entries[6];
                insurance1.Text = entries[7];
                insurance2.Text = entries[8];
            }
            
        }

        private void PopulateComboBoxes()
        {
            insurance1.Items.Clear();
            insurance2.Items.Clear();
            recalls.Items.Clear();
            foreach (string key in insuranceCompanies.Keys)
            {
                insurance1.Items.Add(key);
                insurance2.Items.Add(key);
            }
            foreach (string key in recallTypes.Keys)
            {
                recalls.Items.Add(key);
            }


        }

        private void refresh_Click(object sender, EventArgs e)
        {
            TextWriter tr = new StreamWriter(Application.StartupPath + "/correspondence.txt");

            tr.Write(dateTimePicker1.Value.ToString() + ",");
            tr.Write(dateTimePicker2.Value.ToString() + ",");
            tr.Write(dateTimePicker3.Value.ToString() + ",");
            tr.Write(dateTimePicker4.Value.ToString() + ",");
            tr.Write(dateTimePicker5.Value.ToString() + ",");
            tr.Write(dateTimePicker6.Value.ToString() + ",");
            tr.Write(recalls.Text + ",");
            tr.Write(insurance1.Text + ",");
            tr.Write(insurance2.Text);

            tr.Flush();
            tr.Close();

            string Sql = "SELECT distinct patient.patient_no, patient.last_name, patient.first_name, address.address1, address.address2, address.city, code.description AS state, address.zip, " +
                         "address.phone1, address.phone2, patient.eMail_address, patient.last_exam_date, patient.birth_date, insurance_name " +
                         "FROM (((((address INNER JOIN " +
                         "patient ON address.address_no = patient.address_no) INNER JOIN " +
                         "patient_insurances ON patient.patient_no = patient_insurances.patient_no) INNER JOIN " +
                         "insurance ON patient_insurances.insurance_no = insurance.insurance_no) INNER JOIN " +
                         "code ON address.state = code.code) Inner Join patient_recalls on patient.patient_no = patient_recalls.patient_no) " +
                         "WHERE patient.last_exam_date between '" + dateTimePicker3.Value.ToShortDateString() + "' and '" + dateTimePicker4.Value.ToShortDateString() + "' " +
                         "and patient.birth_date between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' " +
                         "and patient_recalls.recall_dt between '" + dateTimePicker5.Value.ToShortDateString() + "' and '" + dateTimePicker6.Value.ToShortDateString() + "' ";

            if (insurance1.Text != "" && insurance2.Text != "")
                Sql += "and patient_insurances.insurance_no IN (" + insuranceCompanies[insurance1.Text] + "," + insuranceCompanies[insurance2.Text] + ") ";
            else if (insurance1.Text != "" && insurance2.Text == "")
                Sql += "and patient_insurances.insurance_no = " + insuranceCompanies[insurance1.Text] + " ";
            else if (insurance1.Text == "" && insurance2.Text != "")
                Sql += "and patient_insurances.insurance_no = " + insuranceCompanies[insurance2.Text] + " ";

            if (recalls.Text != "")
                Sql += "and recall_type_no = " + recallTypes[recalls.Text];
            
            Sql += " Order By patient.last_name";

            OleDbCommand cmd = new OleDbCommand(Sql, Utility.GetConnection());


            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter param1 = new ReportParameter("birthdate1", "01/01/2000");
            parameters.Add(param1);
            ReportParameter param2 = new ReportParameter("birthdate2", "01/01/2010");
            parameters.Add(param2);
            this.reportViewer1.LocalReport.DataSources.RemoveAt(0);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("OfficeMateData_PatientQuery", ds.Tables[0]));

            this.reportViewer1.RefreshReport();
        }
    }
}
