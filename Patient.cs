using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace OfficeForms
{
    class Patient
    {
        private static string SQL_GET_LIST = "select top 20 " + 
            "patient_no as ID, " +
            "last_name as [Last Name], " +
            "first_name as [First Name], " +
            "ss_no as SSN, " +
            "entry_date as [Entry Date], " +
            "address1, " +
            "address2, " +
            "city, " +
            "state, " +
            "zip, " +
            "phone1, " +
            "phone2 " +
            "from patient Inner Join address on patient.address_no = address.address_no " +
            "order by patient_no desc ";
        private static string SQL_GET_PATIENT = 
            "select " +
            "patient.patient_no as ID, " +
            "last_name as [Last Name], " +
            "first_name as [First Name], " +
            "ss_no as SSN, " +
            "entry_date as [Entry Date], " +
            "address1, " +
            "address2, " +
            "city, " +
            "[code].description as state, " +
            "zip, " +
            "phone1, " +
            "phone2, sex, birth_date, ss_no " +
            "from (((patient Left Outer Join address on patient.address_no = address.address_no)) " +
            "Left Outer Join [code] on address.state = [code].[code]) " +

            "WHERE patient.patient_no = ?";

        
        private static string SQL_GET_POLICIES =
            "SELECT  insured_id, insurance_name, c.description as relation, insured_no as insuredID, pi.ins_seq " +
            "FROM patient_insurances as pi, insurance as i, code as c " +
            "where i.insurance_no = pi.insurance_no " +
            "and pi.relation_to_insured = c.code " +
            "and (pi.Inactive is null or pi.Inactive = 0) " +
            "and pi.patient_no=? " +
            "Order by pi.ins_seq";

        private static string SQL_GET_EDOCS = "SELECT SysID, ExpiresOn, RecordedOn, FormType, Notes, CodeId, EDocLink " +
            " FROM eDocuments where patient_no=? order by SysID";
        private static string SQL_GET_HIPAA = "SELECT SysID, ExpiresOn, RecordedOn, FormType, Notes, 0 as CodeId, EDocLink " +
            "FROM HIPAAForms where patient_no=?";

        private static string SQL_GET_APPTS = "select first_name + ' ' + last_name as Name, appt_date as [Date]," +
                "appt_start_time as [Start Time], appt_end_time as [End Time], provider_last_name as Provider, appt_no " +
                "FROM AppSch_Appointment INNER JOIN Patient on Appt_Om_No=Patient.patient_no INNER JOIN Provider ON AppSch_Appointment.pro_no = Provider.provider_no " +
                "WHERE last_name like ? and first_name like ?" +
                " and appt_date between ? and ? and provider_last_name like ? " +
                "Order By appt_start_time";


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        
        public string Name
        {
            get
            {
                return firstName + " " + lastName;
            }
        }

        private string address1;

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
        private string address2;

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string zip;

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
        private string phone1;

        public string Phone1
        {
            get { return phone1; }
            set { phone1 = value; }
        }
        private string phone2;

        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }

        private bool isMale;

        public bool IsMale
        {
            get { return isMale; }
            set { isMale = value; }
        }

        private string dateOfBirth;

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string ssn;

        public string Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private string primaryCarrier;

        public string PrimaryCarrier
        {
            get { return primaryCarrier; }
            set { primaryCarrier = value; }
        }
        private string primaryPolicyId;

        public string PrimaryPolicyId
        {
            get { return primaryPolicyId; }
            set { primaryPolicyId = value; }
        }
        private string primaryPolicyRelation;

        public string PrimaryPolicyRelation
        {
            get { return primaryPolicyRelation; }
            set { primaryPolicyRelation = value; }
        }

        private int primaryInsuredId;
        public int PrimaryInsuredId
        {
            get { return primaryInsuredId; }
            set { primaryInsuredId = value; }
        }

        private string primaryInsuredName;
        public string PrimaryInsuredName
        {
            get { return primaryInsuredName; }
            set { primaryInsuredName = value; }
        }
        private string primaryInsuredDob;
        public string PrimaryInsuredDob
        {
            get { return primaryInsuredDob; }
            set { primaryInsuredDob = value; }
        }
        
            
        private List<InsurancePolicy> policies;

        private List<Document> eDocuments;

        internal List<Document> EDocuments
        {
            get { return eDocuments; }
            set { eDocuments = value; }
        }

        private List<Document> hipaaDocuments;

        internal List<Document> HipaaDocuments
        {
            get { return hipaaDocuments; }
            set { hipaaDocuments = value; }
        }
        
        
        public Patient() { }

        public Patient(object id, string address1, string address2, string city, string state, string zip, string phone1, string phone2) {
            this.id = int.Parse(id.ToString());
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone1 = phone1;
            this.phone2 = phone2;

        }

        public static Patient GetPatientByQuery(OleDbCommand command)
        {
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Patient p = new Patient();
                p.Id = reader.GetInt32(0);
                p.FirstName = reader.GetString(2);
                p.LastName = reader.GetString(1);
                p.Address1 = reader.GetString(5);
                p.Address2 = reader.GetString(6);
                p.City = reader.GetString(7);
                if (!reader.IsDBNull(8))
                    p.State = reader.GetString(8);
                p.Zip = reader.GetString(9);
                p.Phone1 = reader.GetString(10);


                // TO Do Check all DB returned fields for possible nulls
                if (!reader.IsDBNull(11))
                    p.Phone2 = reader.GetString(11);

                p.IsMale = reader.GetInt16(12) <= 0 ? true : false;
                if (!reader.IsDBNull(13))
                    p.DateOfBirth = reader.GetDateTime(13).ToShortDateString();
                p.Ssn = reader.GetString(14);

                p.GetPolicies(command.Connection);

                p.GetDocs(command.Connection);

                return p;
            }
            else
                return null;


        }

        public static Patient GetPatient(int id, OleDbConnection Connection)
        {
            OleDbCommand command = new OleDbCommand(SQL_GET_PATIENT, Connection);

            command.Parameters.AddWithValue("@PatentId", id);
             
                
            return GetPatientByQuery(command);
        }

        public static Patient GetPatientByName(string LastName, string FirstName, OleDbConnection Connection)
        {
            string SQL =
                "select " +
                "patient.patient_no as ID, " +
                "last_name as [Last Name], " +
                "first_name as [First Name], " +
                "ss_no as SSN, " +
                "entry_date as [Entry Date], " +
                "address1, " +
                "address2, " +
                "city, " +
                "[code].description as state, " +
                "zip, " +
                "phone1, " +
                "phone2, sex, birth_date, ss_no " +
                "from (((patient Inner Join address on patient.address_no = address.address_no)) " +
                "Inner Join [code] on address.state = [code].[code]) " +

                "WHERE last_name " + (LastName == "" ? "=last_name" : "Like '" + LastName + "%'") +
                " and first_name " + (FirstName == "" ? "=first_name" : "Like '" + FirstName + "%'") +
                " Order By last_name";

            OleDbCommand command = new OleDbCommand(SQL, Connection);
            return GetPatientByQuery(command);

        }

        public DataTable GetAppointments(DateTime TheDate, string Provider, OleDbConnection Connection)
        {
            return GetAppointmentsByName(LastName, FirstName, TheDate, Provider, Connection);       
        
        }

        public static DataTable GetAppointmentsByName(string LastName, string FirstName, DateTime TheDate, string provider, OleDbConnection Connection)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = SQL_GET_APPTS;
            command.Connection = Utility.GetConnection();


            command.Parameters.AddWithValue("@lastName", LastName + "%");
            command.Parameters.AddWithValue("@firstName", FirstName + "%");

            if (TheDate > DateTime.MinValue)
            {

                OleDbParameter param1 = new OleDbParameter("",OleDbType.Date);
                param1.Value = TheDate.Date;

                command.Parameters.Add(param1);

                OleDbParameter param2 = new OleDbParameter("", OleDbType.Date);
                param2.Value = TheDate.AddDays(1).Date.AddMinutes(-1);

                command.Parameters.Add(param2);
            }
            else
            {
                command.Parameters.AddWithValue("@lowLimit", "01/01/1900");
                command.Parameters.AddWithValue("@highLimit","01/01/3000");
            }

            if (provider != null && provider != "")
            {

                String[] provName = provider.Split(',');
                command.Parameters.AddWithValue("@provider", provName[0] + "%");
            }
            else
                command.Parameters.AddWithValue("@provider", "%");

            OleDbDataAdapter adaptor = new OleDbDataAdapter(command);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            return ds.Tables[0];


        }

        public Document GetEDocument(int docId)
        {
            foreach (Document doc in EDocuments)
            {
                if (doc.Id == docId)
                    return doc;
            }
            return null;
        }

        public Document GetHipaaDocument(int docId)
        {
            foreach (Document doc in HipaaDocuments)
            {
                if (doc.Id == docId)
                    return doc;
            }
            return null;
        }

        public void GetPolicies(OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand(SQL_GET_POLICIES, connection);
            command.Parameters.AddWithValue("", id);

            IDataReader reader = command.ExecuteReader();
            policies = new List<InsurancePolicy>();

            while (reader.Read())
            {
                InsurancePolicy p = new InsurancePolicy();
                p.MemberId = reader.GetString(0);
                p.Carrier = reader.GetString(1);
                p.Relationship = reader.GetString(2);
                p.InsuredId = reader.GetInt32(3);
                if (!reader.IsDBNull(4) && reader.GetInt16(4) == 1)
                {
                    this.PrimaryCarrier = p.Carrier;
                    this.PrimaryPolicyId = p.MemberId;
                    this.PrimaryPolicyRelation = p.Relationship;
                    this.PrimaryInsuredId = p.InsuredId;

                    if (PrimaryInsuredId > 0 && PrimaryInsuredId != Id)
                    {
                        Patient insured = Patient.GetPatient(PrimaryInsuredId, connection);
                        PrimaryInsuredName = insured.Name;
                        PrimaryInsuredDob = insured.DateOfBirth;
                    }
                    else
                    {
                        PrimaryInsuredName = Name;
                        PrimaryInsuredDob = DateOfBirth;
                    }
                }
                policies.Add(p);
            }
        }

        public void GetDocs(OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand(SQL_GET_EDOCS, connection);
            command.Parameters.AddWithValue ("", id);
            IDataReader reader = command.ExecuteReader();
            eDocuments = new List<Document>();

            while (reader.Read())
            {
                Document doc = new Document();
                doc.Id = reader.GetInt32(0);
                doc.FormTypeCode = Document.FormTypes.EDocs;
                if (!reader.IsDBNull(1))
                    doc.ExpirationDate = reader.GetDateTime(1);
                doc.DocLink = reader.GetString(6);
                doc.DocTypeCode =(Document.DocTypes) reader.GetInt32(5);
                eDocuments.Add(doc);
            }


            command = new OleDbCommand(SQL_GET_HIPAA, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@patientId", id);
            reader = command.ExecuteReader();

            hipaaDocuments = new List<Document>();
            while (reader.Read())
            {
                Document doc = new Document();
                doc.Id = reader.GetInt32(0);
                doc.FormTypeCode = Document.FormTypes.HIPAA;
                doc.DocTypeCode = Utility.GetDocTypeCode(reader.GetString(3));
                if (!reader.IsDBNull(1))
                    doc.ExpirationDate = reader.GetDateTime(1);
                doc.DocLink = reader.GetString(6);
                hipaaDocuments.Add(doc);
            }

        }
    }
}
