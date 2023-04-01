using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeForms
{
    class InsurancePolicy
    {
        private string carrier;

        public string Carrier
        {
            get { return carrier; }
            set { carrier = value; }
        }
        private string memberId;

        public string MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        private string relationship;

        public string Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        private int insuredId;

        public int InsuredId
        {
            get { return insuredId; }
            set { insuredId = value; }
        }
    }
}
