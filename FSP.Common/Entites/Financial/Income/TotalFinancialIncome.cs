using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class TotalFinancialIncome : BaseClass
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
        float totalFinancialIncomeValue;

        public float TotalFinancialIncomeValue
        {
            get { return totalFinancialIncomeValue; }
            set { totalFinancialIncomeValue = value; }
        }
        float netProfit;

        public float NetProfit
        {
            get { return netProfit; }
            set { netProfit = value; }
        }
        float incomeTaxZakat;

        public float IncomeTaxZakat
        {
            get { return incomeTaxZakat; }
            set { incomeTaxZakat = value; }
        }
        float taxZakatProvision;

        public float TaxZakatProvision
        {
            get { return taxZakatProvision; }
            set { taxZakatProvision = value; }
        }
        float zakatRate;

        public float ZakatRate
        {
            get { return zakatRate; }
            set { zakatRate = value; }
        }
        IncomeStatment incomeStatment;

        public IncomeStatment IncomeStatment
        {
            get { return incomeStatment; }
            set { incomeStatment = value; }
        }
    }
}
