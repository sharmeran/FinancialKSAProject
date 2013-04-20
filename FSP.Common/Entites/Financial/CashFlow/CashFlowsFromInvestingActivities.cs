using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.CashFlow
{
    public class CashFlowsFromInvestingActivities : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int cashFlowStatementID;

        public int CashFlowStatementID
        {
            get { return cashFlowStatementID; }
            set { cashFlowStatementID = value; }
        }
        float disposalOfFixedAssets;

        public float DisposalOfFixedAssets
        {
            get { return disposalOfFixedAssets; }
            set { disposalOfFixedAssets = value; }
        }
        float capitalExpenditures;

        public float CapitalExpenditures
        {
            get { return capitalExpenditures; }
            set { capitalExpenditures = value; }
        }
        float decInPropertyPlant;

        public float DecInPropertyPlant
        {
            get { return decInPropertyPlant; }
            set { decInPropertyPlant = value; }
        }
        float increaseInInvestments;

        public float IncreaseInInvestments
        {
            get { return increaseInInvestments; }
            set { increaseInInvestments = value; }
        }
        float decreaseInInvestments;

        public float DecreaseInInvestments
        {
            get { return decreaseInInvestments; }
            set { decreaseInInvestments = value; }
        }
        float otherCashInflow;

        public float OtherCashInflow
        {
            get { return otherCashInflow; }
            set { otherCashInflow = value; }
        }
        CashFlowStatement cashFlowStatement;

        public CashFlowStatement CashFlowStatement
        {
            get { return cashFlowStatement; }
            set { cashFlowStatement = value; }
        }
    }
}
