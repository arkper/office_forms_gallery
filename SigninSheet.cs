using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Configuration;

namespace OfficeForms
{
    public partial class SigninSheet : Form
    {
        public SigninSheet()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            try
            {
                timer1.Enabled = true;
                Utility.SetupSigPad(sigPlusNET1, ConfigurationManager.AppSettings["Signin Pad Image"]);
                sigPlusNET1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed communicating with the signature pad! Exception is " + ex.Message);
                // FinalizeDoc();
                return;
            }            
        }

        private void SigninSheet_Load(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            cmbProvider.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;

            txtFirstName.Text = "";
            txtLastName.Text = "";

            cmbProvider.SelectedIndex = -1;

            dgAppoints.DataSource = null;
            dgAppoints.Refresh();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" && txtLastName.Text == "")
                return;

            Patient patient = Patient.GetPatientByName
                (txtLastName.Text, txtFirstName.Text, Utility.GetConnection());

            if (patient != null)
            {
                txtFirstName.Text = patient.FirstName;
                txtLastName.Text = patient.LastName;

                DataTable dt = patient.GetAppointments(DateTime.MinValue, null, Utility.GetConnection());
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgAppoints.DataSource = dt;
                    dgAppoints.Refresh();
                    cmbProvider.Enabled = false;
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;

                }
                else
                {
                    cmbProvider.Enabled = true;
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Patient not found!");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAppoint_Click(object sender, EventArgs e)
        {
            dgAppoints.DataSource = Patient.GetAppointmentsByName (
                txtLastName.Text, 
                txtFirstName.Text,
                dtDate.Value,
                cmbProvider.Text,
                Utility.GetConnection());

            dgAppoints.Refresh();
        }

        private void dgAppoints_RowClick (object sender, EventArgs e)
        {
            if (dgAppoints.SelectedRows.Count == 0)
                return;

            string fullName = dgAppoints.SelectedRows[0].Cells[0].Value.ToString();

            string[] firstLast = fullName.Split(new char[] { ' ', ',' });

            if (firstLast.Length > 1)
            {
                txtFirstName.Text = firstLast[0];
                txtLastName.Text = firstLast[1];
            }
            else
            {
                txtLastName.Text = firstLast[0];
            }

            string provider = dgAppoints.SelectedRows[0].Cells[4].Value.ToString();
            cmbProvider.Text = provider;
        }

        private void btnShowSheet_Click(object sender, EventArgs e)
        {
            SigninSheetView ssv = new SigninSheetView();
            ssv.MdiParent = this.MdiParent;
            ssv.Show();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sigPlusNET1.KeyPadQueryHotSpot(0) > 0) //clear chosen
            {
                timer1.Enabled = false;
                sigPlusNET1.ClearSigWindow(1);
                sigPlusNET1.ClearTablet();
                sigPlusNET1.LCDRefresh(1, 32, 153, 37, 15); //invert px at CLEAR so user knows its been tapped
                System.Threading.Thread.Sleep(600);
                sigPlusNET1.LCDRefresh(2, 0, 150, 320, 90); //refresh lcd with background ONLY at bottom of LCD
                sigPlusNET1.ClearSigWindow(1);
                timer1.Enabled = true;
            }

            if (sigPlusNET1.KeyPadQueryHotSpot(1) > 0) //OK chosen
            {
                timer1.Enabled = false;
                sigPlusNET1.ClearSigWindow(1);
                sigPlusNET1.LCDRefresh(1, 250, 153, 34, 15);
                System.Threading.Thread.Sleep(500);
                sigPlusNET1.LCDRefresh(1, 250, 153, 34, 15);

                if (sigPlusNET1.NumberOfTabletPoints() > 0) //if there is a signature
                {
                    sigPlusNET1.LCDRefresh(0, 0, 0, 320, 240);
                    sigPlusNET1.SetTabletState(0);
                    sigPlusNET1.SetJustifyMode(5); //zoom signature within sigplus

                    Font my10font = new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Regular);

                    sigPlusNET1.GetSigImage().Save(ConfigurationManager.AppSettings["Signature Image File"]);

                    sigPlusNET1.SetTabletState(1);

                    Font my13font = new System.Drawing.Font("Arial", 13.0F, System.Drawing.FontStyle.Regular);

                    sigPlusNET1.LCDWriteString(0, 2, 63, 180, my13font, "Welcome To Modern Optica!");
                    System.Threading.Thread.Sleep(1000);
                    sigPlusNET1.LCDRefresh(0, 0, 0, 320, 240);
                    sigPlusNET1.SetLCDCaptureMode(1);
                    sigPlusNET1.SetTabletState(0);
                    sigPlusNET1.Visible = false;
                    FinalizeDoc();
                }
            }

        }

        private void FinalizeDoc()
        {
            Visit visit = new Visit();
            visit.VisitorName = txtFirstName.Text + " " + txtLastName.Text;

            visit.TimeIn = DateTime.Now;

            FileInfo fi = new FileInfo(ConfigurationManager.AppSettings["Signature Image File"]);

            BinaryReader fs = new BinaryReader(new FileStream(ConfigurationManager.AppSettings["Signature Image File"], FileMode.Open));
            visit.SigninImage = fs.ReadBytes((int)fi.Length);

            fs.Close();

            visit.ToBeSeenBy = cmbProvider.Text;

            visit.Save(Utility.GetConnection());

            if (dgAppoints.SelectedRows.Count > 0)
            {
                int apptNo = Int32.Parse(dgAppoints.SelectedRows[0].Cells[5].Value.ToString());

                visit.UpdateAppointmentStatus(apptNo, 1, Utility.GetConnection());


            }

            Clear();

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "resources/fsrecv.wav";
            player.Play();

        }

    
    }
}
