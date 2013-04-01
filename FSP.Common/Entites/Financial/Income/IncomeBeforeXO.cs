using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class IncomeBeforeXO : BaseClass
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
        int incomeBeforeXOItems;

        public int IncomeBeforeXOItems
        {
            get { return incomeBeforeXOItems; }
            set { incomeBeforeXOItems = value; }
        }
        int extraordinaryLossNetof;

        public int ExtraordinaryLossNetof
        {
            get { return extraordinaryLossNetof; }
            set { extraordinaryLossNetof = value; }
        }
        float netProfitBeforeMinority;

        public float NetProfitBeforeMinority
        {
            get { return netProfitBeforeMinority; }
            set { netProfitBeforeMinority = value; }
        }
        int minorityInterests;

        public int MinorityInterests
        {
            get { return minorityInterests; }
            set { minorityInterests = value; }
        }
        IncomeStatment incomeStatment;

        public IncomeStatment IncomeStatment
        {
            get { return incomeStatment; }
            set { incomeStatment = value; }
        }
    }
}
