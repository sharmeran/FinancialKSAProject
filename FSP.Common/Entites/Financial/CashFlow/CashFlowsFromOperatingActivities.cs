using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.CashFlow
{
    public class CashFlowsFromOperatingActivities : BaseClass
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
        float netIncomeBeforeTaxMinorityInterest;

        public float NetIncomeBeforeTaxMinorityInterest
        {
            get { return netIncomeBeforeTaxMinorityInterest; }
            set { netIncomeBeforeTaxMinorityInterest = value; }
        }
        float depreciationAmortization;

        public float DepreciationAmortization
        {
            get { return depreciationAmortization; }
            set { depreciationAmortization = value; }
        }
        float interestedPaid;

        public float InterestedPaid
        {
            get { return interestedPaid; }
            set { interestedPaid = value; }
        }
        float interestReceived;

        public float InterestReceived
        {
            get { return interestReceived; }
            set { interestReceived = value; }
        }
        float taxAndZakatPaid;

        public float TaxAndZakatPaid
        {
            get { return taxAndZakatPaid; }
            set { taxAndZakatPaid = value; }
        }
        float movementOnWoekingCapital;

        public float MovementOnWoekingCapital
        {
            get { return movementOnWoekingCapital; }
            set { movementOnWoekingCapital = value; }
        }
        float changeInOperatingActivities;

        public float ChangeInOperatingActivities
        {
            get { return changeInOperatingActivities; }
            set { changeInOperatingActivities = value; }
        }
        float changeInProvisions;

        public float ChangeInProvisions
        {
            get { return changeInProvisions; }
            set { changeInProvisions = value; }
        }
        float others;

        public float Others
        {
            get { return others; }
            set { others = value; }
        }
        float otherNonCashAdjustments;

        public float OtherNonCashAdjustments
        {
            get { return otherNonCashAdjustments; }
            set { otherNonCashAdjustments = value; }
        }
        float changesInNonCashCapital;

        public float ChangesInNonCashCapital
        {
            get { return changesInNonCashCapital; }
            set { changesInNonCashCapital = value; }
        }
        CashFlowStatement cashFlowStatement;

        public CashFlowStatement CashFlowStatement
        {
            get { return cashFlowStatement; }
            set { cashFlowStatement = value; }
        }
    }
}
