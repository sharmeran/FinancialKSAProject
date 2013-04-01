using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Income
{
    public class NetIncome : BaseClass
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
        float totalCashPreferredDividends;

        public float TotalCashPreferredDividends
        {
            get { return totalCashPreferredDividends; }
            set { totalCashPreferredDividends = value; }
        }
        float totalCashPreferredDividendsNonIslamic;

        public float TotalCashPreferredDividendsNonIslamic
        {
            get { return totalCashPreferredDividendsNonIslamic; }
            set { totalCashPreferredDividendsNonIslamic = value; }
        }
        float otherAdjustments;

        public float OtherAdjustments
        {
            get { return otherAdjustments; }
            set { otherAdjustments = value; }
        }
        float netIncAvailtoCommonShareholders;

        public float NetIncAvailtoCommonShareholders
        {
            get { return netIncAvailtoCommonShareholders; }
            set { netIncAvailtoCommonShareholders = value; }
        }
        float abnormalLoss;

        public float AbnormalLoss
        {
            get { return abnormalLoss; }
            set { abnormalLoss = value; }
        }
        float taxEffectOnAbnormalItems;

        public float TaxEffectOnAbnormalItems
        {
            get { return taxEffectOnAbnormalItems; }
            set { taxEffectOnAbnormalItems = value; }
        }
        float normalizedIncome;

        public float NormalizedIncome
        {
            get { return normalizedIncome; }
            set { normalizedIncome = value; }
        }
        float comprehensiveIncome;

        public float ComprehensiveIncome
        {
            get { return comprehensiveIncome; }
            set { comprehensiveIncome = value; }
        }
        float comprehensiveIncomePerShare;

        public float ComprehensiveIncomePerShare
        {
            get { return comprehensiveIncomePerShare; }
            set { comprehensiveIncomePerShare = value; }
        }
        float basicEPSBeforeAbnormalItems;

        public float BasicEPSBeforeAbnormalItems
        {
            get { return basicEPSBeforeAbnormalItems; }
            set { basicEPSBeforeAbnormalItems = value; }
        }
        float basicEPSBeforeXOItems;

        public float BasicEPSBeforeXOItems
        {
            get { return basicEPSBeforeXOItems; }
            set { basicEPSBeforeXOItems = value; }
        }
        float basicEPS;

        public float BasicEPS
        {
            get { return basicEPS; }
            set { basicEPS = value; }
        }
        float basicWeightedAvgShares;

        public float BasicWeightedAvgShares
        {
            get { return basicWeightedAvgShares; }
            set { basicWeightedAvgShares = value; }
        }
        float dilutedEPSBeforeAbnormalItems;

        public float DilutedEPSBeforeAbnormalItems
        {
            get { return dilutedEPSBeforeAbnormalItems; }
            set { dilutedEPSBeforeAbnormalItems = value; }
        }
        float dilutedEPSBeforeXOItems;

        public float DilutedEPSBeforeXOItems
        {
            get { return dilutedEPSBeforeXOItems; }
            set { dilutedEPSBeforeXOItems = value; }
        }
        float dilutedEPS;

        public float DilutedEPS
        {
            get { return dilutedEPS; }
            set { dilutedEPS = value; }
        }
        float dilutedWeightedAvgShares;

        public float DilutedWeightedAvgShares
        {
            get { return dilutedWeightedAvgShares; }
            set { dilutedWeightedAvgShares = value; }
        }
        IncomeStatment incomeStatment;

        public IncomeStatment IncomeStatment
        {
            get { return incomeStatment; }
            set { incomeStatment = value; }
        }
    }
}
