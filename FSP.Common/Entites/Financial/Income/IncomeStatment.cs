using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class IncomeStatment:BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int companyFinancialModelID;

        public int CompanyFinancialModelID
        {
            get { return companyFinancialModelID; }
            set { companyFinancialModelID = value; }
        }
        CompanyFinancialModel companyFinancialModel;

        public CompanyFinancialModel CompanyFinancialModel
        {
            get { return companyFinancialModel; }
            set { companyFinancialModel = value; }
        }
    }
}
