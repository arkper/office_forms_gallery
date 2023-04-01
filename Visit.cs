using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace OfficeForms
{
    class Visit
    {
        private string visitorName;

        public string VisitorName
        {
            get { return visitorName; }
            set { visitorName = value; }
        }

        private DateTime timeIn;

        public DateTime TimeIn
        {
            get { return timeIn; }
            set { timeIn = value; }
        }

        private DateTime timeOut;

        public DateTime TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        private string toBeSeenBy;

        public string ToBeSeenBy
        {
            get { return toBeSeenBy; }
            set { toBeSeenBy = value; }
        }

        private byte[] signinImage;

        public byte[] SigninImage
        {
            get { return signinImage; }
            set { signinImage = value; }
        }


        public void Save(OleDbConnection Connection)
        {
            string sql = "insert into office_forms_db..SigninSheet(VisitorName,DateTimeIn,DateTimeOut,SigninImage,ToBeSeenBy) " +
                "values(?,?,?,?,?)";
            OleDbCommand cmd = new OleDbCommand(sql, Connection);

            OleDbParameter param = cmd.CreateParameter();

            cmd.Parameters.Add("@VisitorName", OleDbType.VarChar);
            cmd.Parameters[cmd.Parameters.Count - 1].Value = VisitorName;

            cmd.Parameters.Add("@DateTimeIn", OleDbType.Date);
            cmd.Parameters[cmd.Parameters.Count - 1].Value = TimeIn;

            cmd.Parameters.Add("@DateTimeOut", OleDbType.Date);
            cmd.Parameters[cmd.Parameters.Count - 1].Value = TimeOut;

            cmd.Parameters.Add("@SigninImage", OleDbType.Binary);
            cmd.Parameters[cmd.Parameters.Count - 1].Value = SigninImage;

            cmd.Parameters.Add("@ToBeSeenBy", OleDbType.VarChar);
            cmd.Parameters[cmd.Parameters.Count - 1].Value = ToBeSeenBy;

            cmd.ExecuteNonQuery();
 
        }

        public void UpdateAppointmentStatus (int ApptNo, int Status, OleDbConnection Connection)
        {
            string sql = "update AppSch_Appointment set appt_show_ind=" + Status.ToString() +
                " where appt_no=" + ApptNo.ToString();
            OleDbCommand cmd = new OleDbCommand(sql, Connection);

            cmd.ExecuteNonQuery();

        }

    }
}
