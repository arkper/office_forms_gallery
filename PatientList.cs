using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeForms
{
    class PatientList
    {
        private List<Patient> patients;

        public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
    }
}
