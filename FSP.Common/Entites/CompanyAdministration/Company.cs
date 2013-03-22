using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.CompanyAdministration
{
    public class Company : BaseClass
    {
        int iD;
        string name;
        string description;        
        string information;
        Sector sector;
        DateTime establishYear;
        string nameEnglish;
        string descriptionEnglish;
        string informationEnglish;
        float capital;
        DateTime withLimitedLiability;
        DateTime closedJointStockCompany;
        DateTime iPO;
        DateTime generalCompany;
        List<Behaviour> behaviourList;
        List<SubsidiaryCompany> subsidiaryCompanyList;
        List<SisterCompany> sisterCompanyList;
        int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public List<SisterCompany> SisterCompanyList
        {
            get { return sisterCompanyList; }
            set { sisterCompanyList = value; }
        }

        public List<SubsidiaryCompany> SubsidiaryCompanyList
        {
            get { return subsidiaryCompanyList; }
            set { subsidiaryCompanyList = value; }
        }

        public List<Behaviour> BehaviourList
        {
            get { return behaviourList; }
            set { behaviourList = value; }
        }


        public DateTime GeneralCompany
        {
            get { return generalCompany; }
            set { generalCompany = value; }
        }

        public DateTime IPO
        {
            get { return iPO; }
            set { iPO = value; }
        }

        public DateTime ClosedJointStockCompany
        {
            get { return closedJointStockCompany; }
            set { closedJointStockCompany = value; }
        }

        public DateTime WithLimitedLiability
        {
            get { return withLimitedLiability; }
            set { withLimitedLiability = value; }
        }

        public float Capital
        {
            get { return capital; }
            set { capital = value; }
        }

        public string InformationEnglish
        {
            get { return informationEnglish; }
            set { informationEnglish = value; }
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


        public DateTime EstablishYear
        {
            get { return establishYear; }
            set { establishYear = value; }
        }

        public Sector Sector
        {
            get { return sector; }
            set { sector = value; }
        }

        public string Information
        {
            get { return information; }
            set { information = value; }
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
