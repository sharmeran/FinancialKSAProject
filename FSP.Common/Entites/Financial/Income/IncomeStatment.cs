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

        List<GrossProfit> grossProfitList;

        public List<GrossProfit> GrossProfitList
        {
            get { return grossProfitList; }
            set { grossProfitList = value; }
        }
        List<IncomeBeforeXO> incomeBeforeXOList;

        public List<IncomeBeforeXO> IncomeBeforeXOList
        {
            get { return incomeBeforeXOList; }
            set { incomeBeforeXOList = value; }
        }
        List<NetIncome> netIncomeList;

        public List<NetIncome> NetIncomeList
        {
            get { return netIncomeList; }
            set { netIncomeList = value; }
        }
        List<OperatingIncome> operatingIncomeList;

        public List<OperatingIncome> OperatingIncomeList
        {
            get { return operatingIncomeList; }
            set { operatingIncomeList = value; }
        }
        List<ReferenceItem> referenceItemList;

        public List<ReferenceItem> ReferenceItemList
        {
            get { return referenceItemList; }
            set { referenceItemList = value; }
        }
        List<Revenue> revenueList;

        public List<Revenue> RevenueList
        {
            get { return revenueList; }
            set { revenueList = value; }
        }
        List<TotalFinancialIncome> totalFinancialIncomeList;

        public List<TotalFinancialIncome> TotalFinancialIncomeList
        {
            get { return totalFinancialIncomeList; }
            set { totalFinancialIncomeList = value; }
        }
    }
}
