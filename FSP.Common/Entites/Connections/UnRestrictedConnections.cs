using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Connections
{
   public class UnRestrictedConnections : BaseClass
    {
        int iD;
        int connectionMetaID;
        int year;


        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int ConnectionMetaID
        {
            get { return connectionMetaID; }
            set { connectionMetaID = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
