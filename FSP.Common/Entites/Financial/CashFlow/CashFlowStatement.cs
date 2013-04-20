using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.CashFlow
{
    public class CashFlowStatement : BaseClass
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

        List<CashCashEquivalentPeriodEnd> cashCashEquivalentPeriodEndList;

        public List<CashCashEquivalentPeriodEnd> CashCashEquivalentPeriodEndList
        {
            get { return cashCashEquivalentPeriodEndList; }
            set { cashCashEquivalentPeriodEndList = value; }
        }
        List<CashFlowsFromInvestingActivities> cashFlowsFromInvestingActivitiesList;

        public List<CashFlowsFromInvestingActivities> CashFlowsFromInvestingActivitiesList
        {
            get { return cashFlowsFromInvestingActivitiesList; }
            set { cashFlowsFromInvestingActivitiesList = value; }
        }
        List<CashFlowsFromOperatingActivities> cashFlowsFromOperatingActivitiesList;

        public List<CashFlowsFromOperatingActivities> CashFlowsFromOperatingActivitiesList
        {
            get { return cashFlowsFromOperatingActivitiesList; }
            set { cashFlowsFromOperatingActivitiesList = value; }
        }
        List<CashFromFinancingActivities> cashFromFinancingActivitiesList;

        public List<CashFromFinancingActivities> CashFromFinancingActivitiesList
        {
            get { return cashFromFinancingActivitiesList; }
            set { cashFromFinancingActivitiesList = value; }
        }
        List<ReferenceItem> referenceItemList;

        public List<ReferenceItem> ReferenceItemList
        {
            get { return referenceItemList; }
            set { referenceItemList = value; }
        }
    }
}
