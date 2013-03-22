using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Administration
{
   public class AppYear:BaseClass
    {
        int iD;
        string year;
        int quarter;

        public int Quarter
        {
            get { return quarter; }
            set { quarter = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
