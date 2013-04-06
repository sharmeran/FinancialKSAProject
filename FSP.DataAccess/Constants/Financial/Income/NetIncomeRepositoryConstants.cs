using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class NetIncomeRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + NetIncomeConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + NetIncomeConstants.IncomeStatmentID;
        public const string TotalCashPreferredDividends = CommonConstants.PreParameter + NetIncomeConstants.TotalCashPreferredDividends;
        public const string TotalCashPreferredDividendsNonIslamic = CommonConstants.PreParameter + NetIncomeConstants.TotalCashPreferredDividendsNonIslamic;
        public const string OtherAdjustments = CommonConstants.PreParameter + NetIncomeConstants.OtherAdjustments;
        public const string NetIncAvailtoCommonShareholders = CommonConstants.PreParameter + NetIncomeConstants.NetIncAvailtoCommonShareholders;
        public const string AbnormalLoss = CommonConstants.PreParameter + NetIncomeConstants.AbnormalLoss;
        public const string TaxEffectOnAbnormalItems = CommonConstants.PreParameter + NetIncomeConstants.TaxEffectOnAbnormalItems;
        public const string NormalizedIncome = CommonConstants.PreParameter + NetIncomeConstants.NormalizedIncome;
        public const string ComprehensiveIncome = CommonConstants.PreParameter + NetIncomeConstants.ComprehensiveIncome;
        public const string ComprehensiveIncomePerShare = CommonConstants.PreParameter + NetIncomeConstants.ComprehensiveIncomePerShare;
        public const string BasicEPSBeforeAbnormalItems = CommonConstants.PreParameter + NetIncomeConstants.BasicEPSBeforeAbnormalItems;
        public const string BasicEPSBeforeXOItems = CommonConstants.PreParameter + NetIncomeConstants.BasicEPSBeforeXOItems;
        public const string BasicEPS = CommonConstants.PreParameter + NetIncomeConstants.BasicEPS;
        public const string BasicWeightedAvgShares = CommonConstants.PreParameter + NetIncomeConstants.BasicWeightedAvgShares;
        public const string DilutedEPSBeforeAbnormalItems = CommonConstants.PreParameter + NetIncomeConstants.DilutedEPSBeforeAbnormalItems;
        public const string DilutedEPSBeforeXOItems = CommonConstants.PreParameter + NetIncomeConstants.DilutedEPSBeforeXOItems;
        public const string DilutedEPS = CommonConstants.PreParameter + NetIncomeConstants.DilutedEPS;
        public const string DilutedWeightedAvgShares = CommonConstants.PreParameter + NetIncomeConstants.DilutedWeightedAvgShares;

        public const string SP_Insert = "NetIncomeInsert";
        public const string SP_Update = "NetIncomeUpdate";
        public const string SP_Delete = "NetIncomeDelete";
        public const string SP_FindAll = "NetIncomeFindAll";
        public const string SP_FindByID = "NetIncomeFindByID";
    }
}
