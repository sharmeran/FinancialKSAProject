using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class ReferenceItem : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int incomeStatmentID;

        public int IncomeStatmentID
        {
            get { return incomeStatmentID; }
            set { incomeStatmentID = value; }
        }
        int eBITDA;

        public int EBITDA
        {
            get { return eBITDA; }
            set { eBITDA = value; }
        }
        int grossMargin;

        public int GrossMargin
        {
            get { return grossMargin; }
            set { grossMargin = value; }
        }
        int operatingMargin;

        public int OperatingMargin
        {
            get { return operatingMargin; }
            set { operatingMargin = value; }
        }
        int profitMargin;

        public int ProfitMargin
        {
            get { return profitMargin; }
            set { profitMargin = value; }
        }
        float actualSalesPerEmployee;

        public float ActualSalesPerEmployee
        {
            get { return actualSalesPerEmployee; }
            set { actualSalesPerEmployee = value; }
        }
        float dividendsPerShare;

        public float DividendsPerShare
        {
            get { return dividendsPerShare; }
            set { dividendsPerShare = value; }
        }
        float totalCashCommonDividends;

        public float TotalCashCommonDividends
        {
            get { return totalCashCommonDividends; }
            set { totalCashCommonDividends = value; }
        }
        int salesGrowth;

        public int SalesGrowth
        {
            get { return salesGrowth; }
            set { salesGrowth = value; }
        }
        int basicEPSBeforeXOGrowth;

        public int BasicEPSBeforeXOGrowth
        {
            get { return basicEPSBeforeXOGrowth; }
            set { basicEPSBeforeXOGrowth = value; }
        }
        int interestIncome;

        public int InterestIncome
        {
            get { return interestIncome; }
            set { interestIncome = value; }
        }
        float capitalizedInterestExpense;

        public float CapitalizedInterestExpense
        {
            get { return capitalizedInterestExpense; }
            set { capitalizedInterestExpense = value; }
        }
        float researchDevelopmentExpense;

        public float ResearchDevelopmentExpense
        {
            get { return researchDevelopmentExpense; }
            set { researchDevelopmentExpense = value; }
        }
        float depreciationExpense;

        public float DepreciationExpense
        {
            get { return depreciationExpense; }
            set { depreciationExpense = value; }
        }
        int partialRecordIndicator;

        public int PartialRecordIndicator
        {
            get { return partialRecordIndicator; }
            set { partialRecordIndicator = value; }
        }
        IncomeStatment incomeStatment;

        public IncomeStatment IncomeStatment
        {
            get { return incomeStatment; }
            set { incomeStatment = value; }
        }
    }
}
