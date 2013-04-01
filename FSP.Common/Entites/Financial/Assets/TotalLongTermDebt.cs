using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class TotalLongTermDebt : BaseClass
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
        float longTermDebt;

        public float LongTermDebt
        {
            get { return longTermDebt; }
            set { longTermDebt = value; }
        }
        float saudiIndustrialDevelopmentFund;

        public float SaudiIndustrialDevelopmentFund
        {
            get { return saudiIndustrialDevelopmentFund; }
            set { saudiIndustrialDevelopmentFund = value; }
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
        float ownershipofcompany;

        public float Ownershipofcompany
        {
            get { return ownershipofcompany; }
            set { ownershipofcompany = value; }
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
        float drawnuptodateExecludeGveronemnt;

        public float DrawnuptodateExecludeGveronemnt
        {
            get { return drawnuptodateExecludeGveronemnt; }
            set { drawnuptodateExecludeGveronemnt = value; }
        }
        float conventionalFinance;

        public float ConventionalFinance
        {
            get { return conventionalFinance; }
            set { conventionalFinance = value; }
        }
        float drawnuptodate;

        public float Drawnuptodate
        {
            get { return drawnuptodate; }
            set { drawnuptodate = value; }
        }
        float grossLongTermDebt;

        public float GrossLongTermDebt
        {
            get { return grossLongTermDebt; }
            set { grossLongTermDebt = value; }
        }
        float longTermIslamicFinancIng;

        public float LongTermIslamicFinancIng
        {
            get { return longTermIslamicFinancIng; }
            set { longTermIslamicFinancIng = value; }
        }
        float longTermDebtNonIslamic;

        public float LongTermDebtNonIslamic
        {
            get { return longTermDebtNonIslamic; }
            set { longTermDebtNonIslamic = value; }
        }
        float capitalLease;

        public float CapitalLease
        {
            get { return capitalLease; }
            set { capitalLease = value; }
        }
        float capitalLeaseNonIslamic;

        public float CapitalLeaseNonIslamic
        {
            get { return capitalLeaseNonIslamic; }
            set { capitalLeaseNonIslamic = value; }
        }
        float governmentSukuk;

        public float GovernmentSukuk
        {
            get { return governmentSukuk; }
            set { governmentSukuk = value; }
        }
        float governmentBondsNonIslamic;

        public float GovernmentBondsNonIslamic
        {
            get { return governmentBondsNonIslamic; }
            set { governmentBondsNonIslamic = value; }
        }
        float corporateSukuk;

        public float CorporateSukuk
        {
            get { return corporateSukuk; }
            set { corporateSukuk = value; }
        }
        float corporateBondsNonIslamic;

        public float CorporateBondsNonIslamic
        {
            get { return corporateBondsNonIslamic; }
            set { corporateBondsNonIslamic = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
