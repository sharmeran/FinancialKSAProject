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

        List<RestrictedConnections> restrictedConnectionsList;
        List<UnRestrictedConnections> unRestrictedConnectionsList;
        List<ExtraConnections> extraConnectionsList;
        List<AppreciationConnections> appreciationConnectionsList;
        List<FinalConnections> finalConnectionsList;
        List<UnderStudyingConnections> underStudyingConnectionsList;
        List<InitialConnections> initialConnectionsList;

        public List<InitialConnections> InitialConnectionsList
        {
            get { return initialConnectionsList; }
            set { initialConnectionsList = value; }
        }

        public List<UnderStudyingConnections> UnderStudyingConnectionsList
        {
            get { return underStudyingConnectionsList; }
            set { underStudyingConnectionsList = value; }
        }

        public List<FinalConnections> FinalConnectionsList
        {
            get { return finalConnectionsList; }
            set { finalConnectionsList = value; }
        }

        public List<AppreciationConnections> AppreciationConnectionsList
        {
            get { return appreciationConnectionsList; }
            set { appreciationConnectionsList = value; }
        }

        public List<ExtraConnections> ExtraConnectionsList
        {
            get { return extraConnectionsList; }
            set { extraConnectionsList = value; }
        }

        public List<UnRestrictedConnections> UnRestrictedConnectionsList
        {
            get { return unRestrictedConnectionsList; }
            set { unRestrictedConnectionsList = value; }
        }

        public List<RestrictedConnections> RestrictedConnectionsList
        {
            get { return restrictedConnectionsList; }
            set { restrictedConnectionsList = value; }
        }

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
