using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class OperatingIncome : BaseClass
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
        float operatingIncomevalue;

        public float OperatingIncomevalue
        {
            get { return operatingIncomevalue; }
            set { operatingIncomevalue = value; }
        }
        int interestExpense;

        public int InterestExpense
        {
            get { return interestExpense; }
            set { interestExpense = value; }
        }
        int interestExpenseNonIslamic;

        public int InterestExpenseNonIslamic
        {
            get { return interestExpenseNonIslamic; }
            set { interestExpenseNonIslamic = value; }
        }
        int interestIncome;

        public int InterestIncome
        {
            get { return interestIncome; }
            set { interestIncome = value; }
        }
        int interestIncomeNonIslamic;

        public int InterestIncomeNonIslamic
        {
            get { return interestIncomeNonIslamic; }
            set { interestIncomeNonIslamic = value; }
        }
        float investmentIncome;

        public float InvestmentIncome
        {
            get { return investmentIncome; }
            set { investmentIncome = value; }
        }
        float investmentIncomeNonIslamic;

        public float InvestmentIncomeNonIslamic
        {
            get { return investmentIncomeNonIslamic; }
            set { investmentIncomeNonIslamic = value; }
        }
        float incomeFromSister;

        public float IncomeFromSister
        {
            get { return incomeFromSister; }
            set { incomeFromSister = value; }
        }
        float incomeFromSisterNonIslamic;

        public float IncomeFromSisterNonIslamic
        {
            get { return incomeFromSisterNonIslamic; }
            set { incomeFromSisterNonIslamic = value; }
        }
        float otherIncome;

        public float OtherIncome
        {
            get { return otherIncome; }
            set { otherIncome = value; }
        }
        float otherExpenses;

        public float OtherExpenses
        {
            get { return otherExpenses; }
            set { otherExpenses = value; }
        }
        float otherIncomeNonIslamic;

        public float OtherIncomeNonIslamic
        {
            get { return otherIncomeNonIslamic; }
            set { otherIncomeNonIslamic = value; }
        }
        float otherExpensesNonIslamic;

        public float OtherExpensesNonIslamic
        {
            get { return otherExpensesNonIslamic; }
            set { otherExpensesNonIslamic = value; }
        }
        IncomeStatment incomeStatment;

        public IncomeStatment IncomeStatment
        {
            get { return incomeStatment; }
            set { incomeStatment = value; }
        }
    }
}
