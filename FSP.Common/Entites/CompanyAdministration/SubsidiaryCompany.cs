using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.CompanyAdministration
{
   public class SubsidiaryCompany: BaseClass
    {
        int iD;
        string name;
        string description;
        string nameEnglish;
        string descriptionEnglish;
        DateTime followDate;
        string place;
        string placeEnglish;
        float ownPercentage;
        string note;
        string noteEnglish;
        int companyID;
        bool isOutKSA;
        DateTime establishDate;
        Sector sector;

        public Sector Sector
        {
            get { return sector; }
            set { sector = value; }
        }

        public DateTime EstablishDate
        {
            get { return establishDate; }
            set { establishDate = value; }
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

        public string NoteEnglish
        {
            get { return noteEnglish; }
            set { noteEnglish = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public float OwnPercentage
        {
            get { return ownPercentage; }
            set { ownPercentage = value; }
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

        public DateTime FollowDate
        {
            get { return followDate; }
            set { followDate = value; }
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
