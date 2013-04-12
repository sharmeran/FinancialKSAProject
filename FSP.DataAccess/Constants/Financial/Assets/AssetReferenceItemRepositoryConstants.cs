using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class AssetReferenceItemRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + AssetReferenceItemConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + AssetReferenceItemConstants.AssetsID;
        public const string SharesOutstandIng = CommonConstants.PreParameter + AssetReferenceItemConstants.SharesOutstandIng;
        public const string NumberofTreasuryShares = CommonConstants.PreParameter + AssetReferenceItemConstants.NumberofTreasuryShares;
        public const string AmountofTreasuryShares = CommonConstants.PreParameter + AssetReferenceItemConstants.AmountofTreasuryShares;
        public const string PensionObligations = CommonConstants.PreParameter + AssetReferenceItemConstants.PensionObligations;
        public const string OperatIngLeases = CommonConstants.PreParameter + AssetReferenceItemConstants.OperatIngLeases;
        public const string CapitalLeasesShortTerm = CommonConstants.PreParameter + AssetReferenceItemConstants.CapitalLeasesShortTerm;
        public const string CapitalLeasesLongTerm = CommonConstants.PreParameter + AssetReferenceItemConstants.CapitalLeasesLongTerm;
        public const string CapitalLeasesTotal = CommonConstants.PreParameter + AssetReferenceItemConstants.CapitalLeasesTotal;
        public const string OptionsGrantedDurIngPeriod = CommonConstants.PreParameter + AssetReferenceItemConstants.OptionsGrantedDurIngPeriod;
        public const string OptionsOutstandIngatPeriodEnd = CommonConstants.PreParameter + AssetReferenceItemConstants.OptionsOutstandIngatPeriodEnd;
        public const string BookValueperShare = CommonConstants.PreParameter + AssetReferenceItemConstants.BookValueperShare;
        public const string TotalDebttoTotalAssets = CommonConstants.PreParameter + AssetReferenceItemConstants.TotalDebttoTotalAssets;
        public const string NetDebt = CommonConstants.PreParameter + AssetReferenceItemConstants.NetDebt;
        public const string NetDebttoEquity = CommonConstants.PreParameter + AssetReferenceItemConstants.NetDebttoEquity;
        public const string TangibleCommonEquityRatio = CommonConstants.PreParameter + AssetReferenceItemConstants.TangibleCommonEquityRatio;
        public const string CurrentRatio = CommonConstants.PreParameter + AssetReferenceItemConstants.CurrentRatio;
        public const string CashConversionCycle = CommonConstants.PreParameter + AssetReferenceItemConstants.CashConversionCycle;
        public const string InventoryWorkInProgress = CommonConstants.PreParameter + AssetReferenceItemConstants.InventoryWorkInProgress;
        public const string InventoryFinishedGoods = CommonConstants.PreParameter + AssetReferenceItemConstants.InventoryFinishedGoods;
        public const string OtherInventory = CommonConstants.PreParameter + AssetReferenceItemConstants.OtherInventory;
        public const string PureRetaInedEarnIngs = CommonConstants.PreParameter + AssetReferenceItemConstants.PureRetaInedEarnIngs;
        public const string NumberofEmployees = CommonConstants.PreParameter + AssetReferenceItemConstants.NumberofEmployees;

        public const string SP_Insert = "AssetsReferenceItemsInsert";
        public const string SP_Update = "AssetsReferenceItemsUpdate";
        public const string SP_Delete = "AssetsReferenceItemsDelete";
        public const string SP_FindAll = "AssetsReferenceItemsFindAll";
        public const string SP_FindByID = "AssetsReferenceItemsFindByID";
        public const string SP_FindBYAssetsID = "AssetsReferenceItemsFindByAssetsID";
    }
}
