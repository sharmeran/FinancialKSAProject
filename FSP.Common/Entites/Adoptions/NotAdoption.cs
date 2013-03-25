using FSP.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Common.Entites.Adoptions
{
   public  class NotAdoption :BaseClass
    {
        int iD;
        int adoptionMetaID;
        bool isNoNeedAdoption;
        int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public bool IsNoNeedAdoption
        {
            get { return isNoNeedAdoption; }
            set { isNoNeedAdoption = value; }
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
