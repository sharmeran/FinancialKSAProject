using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.CashFlow
{
    public class CashFromFinancingActivities : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int cashFlowStatmentID;

        public int CashFlowStatmentID
        {
            get { return cashFlowStatmentID; }
            set { cashFlowStatmentID = value; }
        }
        float dividendsPaidDuringTheYear;

        public float DividendsPaidDuringTheYear
        {
            get { return dividendsPaidDuringTheYear; }
            set { dividendsPaidDuringTheYear = value; }
        }
        float issuancesPurchasesEquityShares;

        public float IssuancesPurchasesEquityShares
        {
            get { return issuancesPurchasesEquityShares; }
            set { issuancesPurchasesEquityShares = value; }
        }
        float changeInShortTermBorrowings;

        public float ChangeInShortTermBorrowings
        {
            get { return changeInShortTermBorrowings; }
            set { changeInShortTermBorrowings = value; }
        }
        float inLongTermBorrowings;

        public float InLongTermBorrowings
        {
            get { return inLongTermBorrowings; }
            set { inLongTermBorrowings = value; }
        }
        float inCapitalStocks;

        public float InCapitalStocks
        {
            get { return inCapitalStocks; }
            set { inCapitalStocks = value; }
        }
        float inLoans;

        public float InLoans
        {
            get { return inLoans; }
            set { inLoans = value; }
        }
        float effectOfExchangeRatesOnCash;

        public float EffectOfExchangeRatesOnCash
        {
            get { return effectOfExchangeRatesOnCash; }
            set { effectOfExchangeRatesOnCash = value; }
        }
        float otherFinInflow;

        public float OtherFinInflow
        {
            get { return otherFinInflow; }
            set { otherFinInflow = value; }
        }
        CashFlowStatement cashFlowStatement;

        public CashFlowStatement CashFlowStatement
        {
            get { return cashFlowStatement; }
            set { cashFlowStatement = value; }
        }
    }
}
