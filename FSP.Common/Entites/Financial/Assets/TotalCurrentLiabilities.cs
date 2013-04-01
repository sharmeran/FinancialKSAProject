using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class TotalCurrentLiabilities : BaseClass
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
        float governmentCharge;

        public float GovernmentCharge
        {
            get { return governmentCharge; }
            set { governmentCharge = value; }
        }
        float accountsPayable;

        public float AccountsPayable
        {
            get { return accountsPayable; }
            set { accountsPayable = value; }
        }
        float accruedExpense;

        public float AccruedExpense
        {
            get { return accruedExpense; }
            set { accruedExpense = value; }
        }
        float downPayment;

        public float DownPayment
        {
            get { return downPayment; }
            set { downPayment = value; }
        }
        float taxesPayable;

        public float TaxesPayable
        {
            get { return taxesPayable; }
            set { taxesPayable = value; }
        }
        float zakatPayable;

        public float ZakatPayable
        {
            get { return zakatPayable; }
            set { zakatPayable = value; }
        }
        float dividendsPayable;

        public float DividendsPayable
        {
            get { return dividendsPayable; }
            set { dividendsPayable = value; }
        }
        float dueToSisterCompanies;

        public float DueToSisterCompanies
        {
            get { return dueToSisterCompanies; }
            set { dueToSisterCompanies = value; }
        }
        float otherCurrentLiabilities;

        public float OtherCurrentLiabilities
        {
            get { return otherCurrentLiabilities; }
            set { otherCurrentLiabilities = value; }
        }
        float otherCurrentLiabilitiesNonIslamic;

        public float OtherCurrentLiabilitiesNonIslamic
        {
            get { return otherCurrentLiabilitiesNonIslamic; }
            set { otherCurrentLiabilitiesNonIslamic = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
