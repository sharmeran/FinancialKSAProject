using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class LiabilitiesShareholdersEquity : BaseClass
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
        float totalShortTermDebt;

        public float TotalShortTermDebt
        {
            get { return totalShortTermDebt; }
            set { totalShortTermDebt = value; }
        }
        float shortTermIslamicFinance;

        public float ShortTermIslamicFinance
        {
            get { return shortTermIslamicFinance; }
            set { shortTermIslamicFinance = value; }
        }
        float saudiIndustrialDevelopmentFund;

        public float SaudiIndustrialDevelopmentFund
        {
            get { return saudiIndustrialDevelopmentFund; }
            set { saudiIndustrialDevelopmentFund = value; }
        }
        float shortTermNonIslamicFinance;

        public float ShortTermNonIslamicFinance
        {
            get { return shortTermNonIslamicFinance; }
            set { shortTermNonIslamicFinance = value; }
        }
        float publicInvestmentFund;

        public float PublicInvestmentFund
        {
            get { return publicInvestmentFund; }
            set { publicInvestmentFund = value; }
        }
        float percentageofownershipofgovernment;

        public float Percentageofownershipofgovernment
        {
            get { return percentageofownershipofgovernment; }
            set { percentageofownershipofgovernment = value; }
        }
        float ownershipofcompanyExecludeGovernment;

        public float OwnershipofcompanyExecludeGovernment
        {
            get { return ownershipofcompanyExecludeGovernment; }
            set { ownershipofcompanyExecludeGovernment = value; }
        }
        float drawnuptodateFullAmount;

        public float DrawnuptodateFullAmount
        {
            get { return drawnuptodateFullAmount; }
            set { drawnuptodateFullAmount = value; }
        }
        float percentageofDrawnofgovernment;

        public float PercentageofDrawnofgovernment
        {
            get { return percentageofDrawnofgovernment; }
            set { percentageofDrawnofgovernment = value; }
        }
        float drawnuptodateExecludeGovrnemnt;

        public float DrawnuptodateExecludeGovrnemnt
        {
            get { return drawnuptodateExecludeGovrnemnt; }
            set { drawnuptodateExecludeGovrnemnt = value; }
        }
        float conventionalFinance;

        public float ConventionalFinance
        {
            get { return conventionalFinance; }
            set { conventionalFinance = value; }
        }
        float currentPortionofLongTermDebt;

        public float CurrentPortionofLongTermDebt
        {
            get { return currentPortionofLongTermDebt; }
            set { currentPortionofLongTermDebt = value; }
        }
        float currentPortionofLongTermDebtNonIslamic;

        public float CurrentPortionofLongTermDebtNonIslamic
        {
            get { return currentPortionofLongTermDebtNonIslamic; }
            set { currentPortionofLongTermDebtNonIslamic = value; }
        }
        float currentPortionofLongTermLease;

        public float CurrentPortionofLongTermLease
        {
            get { return currentPortionofLongTermLease; }
            set { currentPortionofLongTermLease = value; }
        }
        float currentPortionofLongTermLeaseNonIslamic;

        public float CurrentPortionofLongTermLeaseNonIslamic
        {
            get { return currentPortionofLongTermLeaseNonIslamic; }
            set { currentPortionofLongTermLeaseNonIslamic = value; }
        }
        float dueToOtherCommercialParties;

        public float DueToOtherCommercialParties
        {
            get { return dueToOtherCommercialParties; }
            set { dueToOtherCommercialParties = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
