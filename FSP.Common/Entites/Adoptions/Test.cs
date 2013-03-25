using FSP.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Common.Entites.Adoptions
{
   public  class Test :BaseClass
    {
        int iD;
        int adoptionMetaID;
        int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int AdoptionMetaID
        {
            get { return adoptionMetaID; }
            set { adoptionMetaID = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
