using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class Asset : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int companyFinancialModelID;

        public int CompanyFinancialModelID
        {
            get { return companyFinancialModelID; }
            set { companyFinancialModelID = value; }
        }
        CompanyFinancialModel companyFinancialModel;

        public CompanyFinancialModel CompanyFinancialModel
        {
            get { return companyFinancialModel; }
            set { companyFinancialModel = value; }
        }

        List<AssetReferenceItem> assetReferenceItemList;

        public List<AssetReferenceItem> AssetReferenceItemList
        {
            get { return assetReferenceItemList; }
            set { assetReferenceItemList = value; }
        }
        List<CashAndCashEquivalent> cashAndCashEquivalentList;

        public List<CashAndCashEquivalent> CashAndCashEquivalentList
        {
            get { return cashAndCashEquivalentList; }
            set { cashAndCashEquivalentList = value; }
        }
        List<CurrentReceivables> currentReceivablesList;

        public List<CurrentReceivables> CurrentReceivablesList
        {
            get { return currentReceivablesList; }
            set { currentReceivablesList = value; }
        }
        List<Intangibles> intangiblesList;

        public List<Intangibles> IntangiblesList
        {
            get { return intangiblesList; }
            set { intangiblesList = value; }
        }
        List<LiabilitiesShareholdersEquity> liabilitiesShareholdersEquityList;

        public List<LiabilitiesShareholdersEquity> LiabilitiesShareholdersEquityList
        {
            get { return liabilitiesShareholdersEquityList; }
            set { liabilitiesShareholdersEquityList = value; }
        }
        List<NetReceivables> netReceivablesList;

        public List<NetReceivables> NetReceivablesList
        {
            get { return netReceivablesList; }
            set { netReceivablesList = value; }
        }
        List<OtherLongTermAssets> otherLongTermAssetsList;

        public List<OtherLongTermAssets> OtherLongTermAssetsList
        {
            get { return otherLongTermAssetsList; }
            set { otherLongTermAssetsList = value; }
        }
        List<OtherLongTermLiabilities> otherLongTermLiabilitiesList;

        public List<OtherLongTermLiabilities> OtherLongTermLiabilitiesList
        {
            get { return otherLongTermLiabilitiesList; }
            set { otherLongTermLiabilitiesList = value; }
        }
        List<OtherShortTermLiabilities> otherShortTermLiabilitiesList;

        public List<OtherShortTermLiabilities> OtherShortTermLiabilitiesList
        {
            get { return otherShortTermLiabilitiesList; }
            set { otherShortTermLiabilitiesList = value; }
        }
        List<ShortTermInvestments> shortTermInvestmentsList;

        public List<ShortTermInvestments> ShortTermInvestmentsList
        {
            get { return shortTermInvestmentsList; }
            set { shortTermInvestmentsList = value; }
        }
        List<TotalCurrentAssets> totalCurrentAssetsList;

        public List<TotalCurrentAssets> TotalCurrentAssetsList
        {
            get { return totalCurrentAssetsList; }
            set { totalCurrentAssetsList = value; }
        }
        List<TotalCurrentLiabilities> totalCurrentLiabilitiesList;

        public List<TotalCurrentLiabilities> TotalCurrentLiabilitiesList
        {
            get { return totalCurrentLiabilitiesList; }
            set { totalCurrentLiabilitiesList = value; }
        }
        List<TotalLiabilitiesAndProvisions> totalLiabilitiesAndProvisionsList;

        public List<TotalLiabilitiesAndProvisions> TotalLiabilitiesAndProvisionsList
        {
            get { return totalLiabilitiesAndProvisionsList; }
            set { totalLiabilitiesAndProvisionsList = value; }
        }
        List<TotalLongTermDebt> totalLongTermDebtList;

        public List<TotalLongTermDebt> TotalLongTermDebtList
        {
            get { return totalLongTermDebtList; }
            set { totalLongTermDebtList = value; }
        }
        List<TotalLongTermInvestment> totalLongTermInvestmentList;

        public List<TotalLongTermInvestment> TotalLongTermInvestmentList
        {
            get { return totalLongTermInvestmentList; }
            set { totalLongTermInvestmentList = value; }
        }
    }
}
