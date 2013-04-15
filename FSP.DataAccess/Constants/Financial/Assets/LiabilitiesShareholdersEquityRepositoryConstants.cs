using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class LiabilitiesShareholdersEquityRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.AssetsID;
        public const string TotalShortTermDebt = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.TotalShortTermDebt;
        public const string ShortTermIslamicFinance = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.ShortTermIslamicFinance;
        public const string SaudiIndustrialDevelopmentFund = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.SaudiIndustrialDevelopmentFund;
        public const string ShortTermNonIslamicFinance = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.ShortTermNonIslamicFinance;
        public const string PublicInvestmentFund = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.PublicInvestmentFund;
        public const string Percentageofownershipofgovernment = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.Percentageofownershipofgovernment;
        public const string OwnershipofcompanyExecludeGovernment = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.OwnershipofcompanyExecludeGovernment;
        public const string DrawnuptodateFullAmount = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.DrawnuptodateFullAmount;
        public const string PercentageofDrawnofgovernment = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.PercentageofDrawnofgovernment;
        public const string DrawnuptodateExecludeGovrnemnt = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.DrawnuptodateExecludeGovrnemnt;
        public const string ConventionalFinance = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.ConventionalFinance;
        public const string CurrentPortionofLongTermDebt = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermDebt;
        public const string CurrentPortionofLongTermDebtNonIslamic = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermDebtNonIslamic;
        public const string CurrentPortionofLongTermLease = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermLease;
        public const string CurrentPortionofLongTermLeaseNonIslamic = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermLeaseNonIslamic;
        public const string DueToOtherCommercialParties = CommonConstants.PreParameter + LiabilitiesShareholdersEquityConstants.DueToOtherCommercialParties;

        public const string SP_Insert = "LiabilitiesShareholdersEquityInsert";
        public const string SP_Update = "LiabilitiesShareholdersEquityUpdate";
        public const string SP_Delete = "LiabilitiesShareholdersEquityDelete";
        public const string SP_FindAll = "LiabilitiesShareholdersEquityFindAll";
        public const string SP_FindByID = "LiabilitiesShareholdersEquityFindByID";
        public const string SP_FindBYAssetsID = "LiabilitiesShareholdersEquityFindByAssetsID";
        public const string SP_DeleteBYAssetsID = "LiabilitiesShareholdersEquityDeleteByAssetsID";
    }
}
