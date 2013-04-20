using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class AssetReferenceItem : BaseClass
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
        float sharesOutstandIng;

        public float SharesOutstandIng
        {
            get { return sharesOutstandIng; }
            set { sharesOutstandIng = value; }
        }
        float numberofTreasuryShares;

        public float NumberofTreasuryShares
        {
            get { return numberofTreasuryShares; }
            set { numberofTreasuryShares = value; }
        }
        float amountofTreasuryShares;

        public float AmountofTreasuryShares
        {
            get { return amountofTreasuryShares; }
            set { amountofTreasuryShares = value; }
        }
        float pensionObligations;

        public float PensionObligations
        {
            get { return pensionObligations; }
            set { pensionObligations = value; }
        }
        float operatIngLeases;

        public float OperatIngLeases
        {
            get { return operatIngLeases; }
            set { operatIngLeases = value; }
        }
        float capitalLeasesShortTerm;

        public float CapitalLeasesShortTerm
        {
            get { return capitalLeasesShortTerm; }
            set { capitalLeasesShortTerm = value; }
        }
        float capitalLeasesLongTerm;

        public float CapitalLeasesLongTerm
        {
            get { return capitalLeasesLongTerm; }
            set { capitalLeasesLongTerm = value; }
        }
        float capitalLeasesTotal;

        public float CapitalLeasesTotal
        {
            get { return capitalLeasesTotal; }
            set { capitalLeasesTotal = value; }
        }
        float optionsGrantedDurIngPeriod;

        public float OptionsGrantedDurIngPeriod
        {
            get { return optionsGrantedDurIngPeriod; }
            set { optionsGrantedDurIngPeriod = value; }
        }
        float optionsOutstandIngatPeriodEnd;

        public float OptionsOutstandIngatPeriodEnd
        {
            get { return optionsOutstandIngatPeriodEnd; }
            set { optionsOutstandIngatPeriodEnd = value; }
        }
        float bookValueperShare;

        public float BookValueperShare
        {
            get { return bookValueperShare; }
            set { bookValueperShare = value; }
        }
        float totalDebttoTotalAssets;

        public float TotalDebttoTotalAssets
        {
            get { return totalDebttoTotalAssets; }
            set { totalDebttoTotalAssets = value; }
        }
        float netDebt;

        public float NetDebt
        {
            get { return netDebt; }
            set { netDebt = value; }
        }
        float netDebttoEquity;

        public float NetDebttoEquity
        {
            get { return netDebttoEquity; }
            set { netDebttoEquity = value; }
        }
        float tangibleCommonEquityRatio;

        public float TangibleCommonEquityRatio
        {
            get { return tangibleCommonEquityRatio; }
            set { tangibleCommonEquityRatio = value; }
        }
        float currentRatio;

        public float CurrentRatio
        {
            get { return currentRatio; }
            set { currentRatio = value; }
        }
        float cashConversionCycle;

        public float CashConversionCycle
        {
            get { return cashConversionCycle; }
            set { cashConversionCycle = value; }
        }
        float inventoryWorkInProgress;

        public float InventoryWorkInProgress
        {
            get { return inventoryWorkInProgress; }
            set { inventoryWorkInProgress = value; }
        }
        float inventoryFinishedGoods;

        public float InventoryFinishedGoods
        {
            get { return inventoryFinishedGoods; }
            set { inventoryFinishedGoods = value; }
        }
        float otherInventory;

        public float OtherInventory
        {
            get { return otherInventory; }
            set { otherInventory = value; }
        }
        float pureRetaInedEarnIngs;

        public float PureRetaInedEarnIngs
        {
            get { return pureRetaInedEarnIngs; }
            set { pureRetaInedEarnIngs = value; }
        }
        int numberofEmployees;

        public int NumberofEmployees
        {
            get { return numberofEmployees; }
            set { numberofEmployees = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
