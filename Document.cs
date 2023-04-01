using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace OfficeForms
{
    class Document
    {
        private static string SQL_SAVE_EDOC = 
            "insert into eDocuments (ExpiresOn,Patient_no,RecordedOn,FormType,EDocLink,CodeId) " +
            "values (?,?,?,?,?,?)";

        private static string SQL_SAVE_HIPAA =
            "insert into HIPAAForms (ExpiresOn,Patient_no,RecordedOn,FormType,EDocLink) " + 
            "values (?,?,?,?,?)";

        private static string SQL_UPDATE_EDOC =
            "update eDocuments EDocLink=@EDocLink where SysID=@DocId";
     
        
        public void Save(OleDbConnection connection, Patient patient)
        {
            if (Id > 0)
            {
                UpdateLink(connection);
                return;
            }

        
            OleDbCommand command = new OleDbCommand();
            if (FormTypeCode == FormTypes.EDocs)
            {
                command.CommandText = SQL_SAVE_EDOC;
                command.Parameters.AddWithValue("@ExpiresOn", ExpirationDate);
                command.Parameters.AddWithValue("@Patient_no",  patient.Id);
                command.Parameters.AddWithValue("@RecordedOn", RecordedDate);
                command.Parameters.AddWithValue("@FormType", Utility.DocTypes[((int)DocTypeCode).ToString()]);
                command.Parameters.AddWithValue("@EDocLink", DocLink);
                command.Parameters.AddWithValue("@CodeId", (int)DocTypeCode);
            }
            else
            {
                command.CommandText = SQL_SAVE_HIPAA;
                command.Parameters.AddWithValue("@ExpiresOn", ExpirationDate);
                command.Parameters.AddWithValue("@Patient_no", patient.Id);
                command.Parameters.AddWithValue("@RecordedOn", RecordedDate);
                command.Parameters.AddWithValue("@FormType", Utility.DocTypes[((int)DocTypeCode).ToString()]);
                command.Parameters.AddWithValue("@EDocLink", DocLink);

        
            }

            command.Connection = Utility.GetConnection();

            command.ExecuteNonQuery();

        }

        public void UpdateLink(OleDbConnection connection)
        {
            string sql = null;
            if (FormTypeCode == FormTypes.EDocs)
            {
                sql =
                "update eDocuments set EDocLink='" + DocLink + "'" +
                " where sysid=" + Id;
            }
            else
            {
                sql =
                "update HIPAAForms set EDocLink='" + DocLink + "'" +
                " where sysid=" + Id;
            }

            OleDbCommand command = new OleDbCommand(sql, connection);

            command.ExecuteNonQuery();

        }

        
        
        public enum FormTypes
        {
            EDocs = 81,
            HIPAA = 93
        };
        public enum DocTypes
        {
            Unknown = 0,
            Misc = 1169,
            Topography = 1162,
            LabResults = 1164,
            ReleaseOfMedicalInfo = 1279,
            TransportationApproval = 1280,
            MedicaidEyeglasses = 1281,
            Privacy = 1106,
            Consent = 1107,
            Complaint = 1108,
            ConsentToExam = 1282,
            Other = 1109
        };


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private FormTypes formTypeCode;

        internal FormTypes FormTypeCode
        {
            get { return formTypeCode; }
            set { formTypeCode = value; }
        }

        private DateTime expirationDate;

        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        private string docLink;

        public string DocLink
        {
            get { return docLink; }
            set { docLink = value; }
        }

        private DocTypes docTypeCode;

        internal DocTypes DocTypeCode
        {
            get { return docTypeCode; }
            set { docTypeCode = value; }
        }


        private DateTime recordedDate;

        public DateTime RecordedDate
        {
            get { return recordedDate; }
            set { recordedDate = value; }
        }

        private string notes;

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public string DocTypeName
        {
            get { return Utility.DocTypes[((int)docTypeCode).ToString()]; }
        }



    }
}
