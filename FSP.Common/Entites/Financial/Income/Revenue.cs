using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class Revenue:BaseClass
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
        float revenueValue;

        public float RevenueValue
        {
            get { return revenueValue; }
            set { revenueValue = value; }
        }
        float costOfRevenue;

        public float CostOfRevenue
        {
            get { return costOfRevenue; }
            set { costOfRevenue = value; }
        }
        IncomeStatment incomeStatment;

        public IncomeStatment IncomeStatment
        {
            get { return incomeStatment; }
            set { incomeStatment = value; }
        }
    }
}
