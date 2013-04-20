using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class TotalLongTermInvestment : BaseClass
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
        float investmentInMutualFunds;

        public float InvestmentInMutualFunds
        {
            get { return investmentInMutualFunds; }
            set { investmentInMutualFunds = value; }
        }
        float investmentInMutualFundsNonIslamic;

        public float InvestmentInMutualFundsNonIslamic
        {
            get { return investmentInMutualFundsNonIslamic; }
            set { investmentInMutualFundsNonIslamic = value; }
        }
        float investmentInShares;

        public float InvestmentInShares
        {
            get { return investmentInShares; }
            set { investmentInShares = value; }
        }
        float investmentInSharesNonIslamic;

        public float InvestmentInSharesNonIslamic
        {
            get { return investmentInSharesNonIslamic; }
            set { investmentInSharesNonIslamic = value; }
        }
        float investmentInAssocaites;

        public float InvestmentInAssocaites
        {
            get { return investmentInAssocaites; }
            set { investmentInAssocaites = value; }
        }
        float investmentInAssocaitesNonIslamic;

        public float InvestmentInAssocaitesNonIslamic
        {
            get { return investmentInAssocaitesNonIslamic; }
            set { investmentInAssocaitesNonIslamic = value; }
        }
        float investmentInSubsidiaries;

        public float InvestmentInSubsidiaries
        {
            get { return investmentInSubsidiaries; }
            set { investmentInSubsidiaries = value; }
        }
        float investmentInSubsidiariesNonIslamic;

        public float InvestmentInSubsidiariesNonIslamic
        {
            get { return investmentInSubsidiariesNonIslamic; }
            set { investmentInSubsidiariesNonIslamic = value; }
        }
        float otherLongTermInvestment;

        public float OtherLongTermInvestment
        {
            get { return otherLongTermInvestment; }
            set { otherLongTermInvestment = value; }
        }
        float otherLongTermInvestmentNonIslamic;

        public float OtherLongTermInvestmentNonIslamic
        {
            get { return otherLongTermInvestmentNonIslamic; }
            set { otherLongTermInvestmentNonIslamic = value; }
        }
        float governmentBonds;

        public float GovernmentBonds
        {
            get { return governmentBonds; }
            set { governmentBonds = value; }
        }
        float governmentBondsNonIslamic;

        public float GovernmentBondsNonIslamic
        {
            get { return governmentBondsNonIslamic; }
            set { governmentBondsNonIslamic = value; }
        }
        float governmentSukuk;

        public float GovernmentSukuk
        {
            get { return governmentSukuk; }
            set { governmentSukuk = value; }
        }
        float corporateSukuk;

        public float CorporateSukuk
        {
            get { return corporateSukuk; }
            set { corporateSukuk = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
