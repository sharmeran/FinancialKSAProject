using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class TotalLiabilitiesAndProvisions : BaseClass
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
        float totalShareholdersEquity;

        public float TotalShareholdersEquity
        {
            get { return totalShareholdersEquity; }
            set { totalShareholdersEquity = value; }
        }
        float minorityInterest;

        public float MinorityInterest
        {
            get { return minorityInterest; }
            set { minorityInterest = value; }
        }
        float paidupCapital;

        public float PaidupCapital
        {
            get { return paidupCapital; }
            set { paidupCapital = value; }
        }
        float sharePremium;

        public float SharePremium
        {
            get { return sharePremium; }
            set { sharePremium = value; }
        }
        float legalStatutoryReserve;

        public float LegalStatutoryReserve
        {
            get { return legalStatutoryReserve; }
            set { legalStatutoryReserve = value; }
        }
        float generalVoluntaryReserve;

        public float GeneralVoluntaryReserve
        {
            get { return generalVoluntaryReserve; }
            set { generalVoluntaryReserve = value; }
        }
        float capitalReserve;

        public float CapitalReserve
        {
            get { return capitalReserve; }
            set { capitalReserve = value; }
        }
        float chgInFairValResvTranslationAdj;

        public float ChgInFairValResvTranslationAdj
        {
            get { return chgInFairValResvTranslationAdj; }
            set { chgInFairValResvTranslationAdj = value; }
        }
        float reserves;

        public float Reserves
        {
            get { return reserves; }
            set { reserves = value; }
        }
        float dueToShareholdersAppropriate;

        public float DueToShareholdersAppropriate
        {
            get { return dueToShareholdersAppropriate; }
            set { dueToShareholdersAppropriate = value; }
        }
        float retaInedEarnIngsAccimulatedLosses;

        public float RetaInedEarnIngsAccimulatedLosses
        {
            get { return retaInedEarnIngsAccimulatedLosses; }
            set { retaInedEarnIngsAccimulatedLosses = value; }
        }
        float netProfitofTheYear;

        public float NetProfitofTheYear
        {
            get { return netProfitofTheYear; }
            set { netProfitofTheYear = value; }
        }
        float treasuryStock;

        public float TreasuryStock
        {
            get { return treasuryStock; }
            set { treasuryStock = value; }
        }
        float totalLiabilitiesAndEquity;

        public float TotalLiabilitiesAndEquity
        {
            get { return totalLiabilitiesAndEquity; }
            set { totalLiabilitiesAndEquity = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
