using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Connections
{
   public  class ConnectionsMeta : BaseClass
    {
        int iD;
        int zakatMainID;
        int restrictedConnesctionNumber;
        int unRestrictedConnectionNumber;
        int extraConnectionNumber;
        int appreciationConnectionNumber;
        int finalConnectionNumber;
        int underStudyingNumber;
        int initialConnectionNumber;

        public int InitialConnectionNumber
        {
            get { return initialConnectionNumber; }
            set { initialConnectionNumber = value; }
        }

        public int UnderStudyingNumber
        {
            get { return underStudyingNumber; }
            set { underStudyingNumber = value; }
        }

        public int FinalConnectionNumber
        {
            get { return finalConnectionNumber; }
            set { finalConnectionNumber = value; }
        }

        public int AppreciationConnectionNumber
        {
            get { return appreciationConnectionNumber; }
            set { appreciationConnectionNumber = value; }
        }

        public int ExtraConnectionNumber
        {
            get { return extraConnectionNumber; }
            set { extraConnectionNumber = value; }
        }


        public int UnRestrictedConnectionNumber
        {
            get { return unRestrictedConnectionNumber; }
            set { unRestrictedConnectionNumber = value; }
        }

        public int RestrictedConnesctionNumber
        {
            get { return restrictedConnesctionNumber; }
            set { restrictedConnesctionNumber = value; }
        }

        public int ZakatMainID
        {
            get { return zakatMainID; }
            set { zakatMainID = value; }
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
