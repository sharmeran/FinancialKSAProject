using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class CashAndCashEquivalent : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int assetsID;

        public int AssetsID
        {
            get { return assetsID; }
            set { assetsID = value; }
        }
        float cash;

        public float Cash
        {
            get { return cash; }
            set { cash = value; }
        }
        float dueAmountFromRelatedParties;

        public float DueAmountFromRelatedParties
        {
            get { return dueAmountFromRelatedParties; }
            set { dueAmountFromRelatedParties = value; }
        }
        float cashEquivalentConventional;

        public float CashEquivalentConventional
        {
            get { return cashEquivalentConventional; }
            set { cashEquivalentConventional = value; }
        }
        float cashCollateral;

        public float CashCollateral
        {
            get { return cashCollateral; }
            set { cashCollateral = value; }
        }
        DateTime timeDepositIslamic;

        public DateTime TimeDepositIslamic
        {
            get { return timeDepositIslamic; }
            set { timeDepositIslamic = value; }
        }
        DateTime timeDepositConventional;

        public DateTime TimeDepositConventional
        {
            get { return timeDepositConventional; }
            set { timeDepositConventional = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
