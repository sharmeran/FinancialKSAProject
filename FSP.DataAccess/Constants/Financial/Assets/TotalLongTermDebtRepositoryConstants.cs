using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class TotalLongTermDebtRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + TotalLongTermDebtConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + TotalLongTermDebtConstants.AssetsID;
        public const string LongTermDebt = CommonConstants.PreParameter + TotalLongTermDebtConstants.LongTermDebt;
        public const string SaudiIndustrialDevelopmentFund = CommonConstants.PreParameter + TotalLongTermDebtConstants.SaudiIndustrialDevelopmentFund;
        public const string PublicInvestmentFund = CommonConstants.PreParameter + TotalLongTermDebtConstants.PublicInvestmentFund;
        public const string Percentageofownershipofgovernment = CommonConstants.PreParameter + TotalLongTermDebtConstants.Percentageofownershipofgovernment;
        public const string Ownershipofcompany = CommonConstants.PreParameter + TotalLongTermDebtConstants.Ownershipofcompany;
        public const string DrawnuptodateFullAmount = CommonConstants.PreParameter + TotalLongTermDebtConstants.DrawnuptodateFullAmount;
        public const string PercentageofDrawnofgovernment = CommonConstants.PreParameter + TotalLongTermDebtConstants.PercentageofDrawnofgovernment;
        public const string DrawnuptodateExecludeGveronemnt = CommonConstants.PreParameter + TotalLongTermDebtConstants.DrawnuptodateExecludeGveronemnt;
        public const string ConventionalFinance = CommonConstants.PreParameter + TotalLongTermDebtConstants.ConventionalFinance;
        public const string Drawnuptodate = CommonConstants.PreParameter + TotalLongTermDebtConstants.Drawnuptodate;
        public const string GrossLongTermDebt = CommonConstants.PreParameter + TotalLongTermDebtConstants.GrossLongTermDebt;
        public const string LongTermIslamicFinancIng = CommonConstants.PreParameter + TotalLongTermDebtConstants.LongTermIslamicFinancIng;
        public const string LongTermDebtNonIslamic = CommonConstants.PreParameter + TotalLongTermDebtConstants.LongTermDebtNonIslamic;
        public const string CapitalLease = CommonConstants.PreParameter + TotalLongTermDebtConstants.CapitalLease;
        public const string CapitalLeaseNonIslamic = CommonConstants.PreParameter + TotalLongTermDebtConstants.CapitalLeaseNonIslamic;
        public const string GovernmentSukuk = CommonConstants.PreParameter + TotalLongTermDebtConstants.GovernmentSukuk;
        public const string GovernmentBondsNonIslamic = CommonConstants.PreParameter + TotalLongTermDebtConstants.GovernmentBondsNonIslamic;
        public const string CorporateSukuk = CommonConstants.PreParameter + TotalLongTermDebtConstants.CorporateSukuk;
        public const string CorporateBondsNonIslamic = CommonConstants.PreParameter + TotalLongTermDebtConstants.CorporateBondsNonIslamic;

        public const string SP_Insert = "TotalLongTermDebtInsert";
        public const string SP_Update = "TotalLongTermDebtUpdate";
        public const string SP_Delete = "TotalLongTermDebtDelete";
        public const string SP_FindAll = "TotalLongTermDebtFindAll";
        public const string SP_FindByID = "TotalLongTermDebtFindByID";
        public const string SP_FindBYAssetsID = "TotalLongTermDebtFindByAssetsID";
    }
}
