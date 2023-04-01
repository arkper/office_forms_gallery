using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace OfficeForms
{
    public partial class SigninSheetView : Form
    {
        public SigninSheetView()
        {
            InitializeComponent();
        }

        private void SigninSheetView_Load(object sender, EventArgs e)
        {
            ShowSheet();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSheet();
        }

        private void ShowSheet()
        {
            DateTime theDate = dateTimePicker1.Value;

            string sql = "SELECT ID, VisitorName, DateTimeIn, DateTimeOut, SigninImage, ToBeSeenBy " +
                "FROM office_forms_db..SigninSheet " +
                "WHERE DateTimeIn Between '" + theDate.ToShortDateString() +
                "' and '" + theDate.AddDays(1).ToShortDateString() + "'";

            DataSet ds = new DataSet();
            OleDbCommand command = new OleDbCommand(sql, Utility.GetConnection());
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);
            ReportParameter param = new ReportParameter("TheDate", theDate.ToShortDateString());
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(param);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.RemoveAt(0);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_SigninSheet", ds.Tables[0]));

            this.reportViewer1.RefreshReport();


        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
