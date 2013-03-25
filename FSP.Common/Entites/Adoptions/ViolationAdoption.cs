using FSP.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Common.Entites.Adoptions
{
    public class ViolationAdoption : BaseClass
    {
        int iD;
        int adoptionMetaID;
        float violationAdoptionValue;
        int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public float ViolationAdoptionValue
        {
            get { return violationAdoptionValue; }
            set { violationAdoptionValue = value; }
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
