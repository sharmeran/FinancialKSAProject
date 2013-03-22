using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.CompanyAdministration
{
   public class SisterCompany :BaseClass
    {

        int iD;
        string name;
        string description;
        string nameEnglish;
        string descriptionEnglish;
        string place;
        string placeEnglish;
        DateTime establishDate;
        int companyID;
        bool isOutKSA;
        Sector sector;

        public Sector Sector
        {
            get { return sector; }
            set { sector = value; }
        }

        public bool IsOutKSA
        {
            get { return isOutKSA; }
            set { isOutKSA = value; }
        }

        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        public DateTime EstablishDate
        {
            get { return establishDate; }
            set { establishDate = value; }
        }

        public string PlaceEnglish
        {
            get { return placeEnglish; }
            set { placeEnglish = value; }
        }

        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        public string DescriptionEnglish
        {
            get { return descriptionEnglish; }
            set { descriptionEnglish = value; }
        }

        public string NameEnglish
        {
            get { return nameEnglish; }
            set { nameEnglish = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
