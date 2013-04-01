using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.CashFlow
{
    public class CashCashEquivalentPeriodEnd : BaseClass
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
        float netChangeCashCashEquivalents;

        public float NetChangeCashCashEquivalents
        {
            get { return netChangeCashCashEquivalents; }
            set { netChangeCashCashEquivalents = value; }
        }
        float cashCashEquivalentAtStartOfPeriod;

        public float CashCashEquivalentAtStartOfPeriod
        {
            get { return cashCashEquivalentAtStartOfPeriod; }
            set { cashCashEquivalentAtStartOfPeriod = value; }
        }
        CashFlowStatement cashFlowStatement;

        public CashFlowStatement CashFlowStatement
        {
            get { return cashFlowStatement; }
            set { cashFlowStatement = value; }
        }
    }
}
