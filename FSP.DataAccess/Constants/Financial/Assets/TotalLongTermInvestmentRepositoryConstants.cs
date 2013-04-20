using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class TotalLongTermInvestmentRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.AssetsID;
        public const string InvestmentInMutualFunds = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInMutualFunds;
        public const string InvestmentInMutualFundsNonIslamic = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInMutualFundsNonIslamic;
        public const string InvestmentInShares = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInShares;
        public const string InvestmentInSharesNonIslamic = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInSharesNonIslamic;
        public const string InvestmentInAssocaites = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInAssocaites;
        public const string InvestmentInAssocaitesNonIslamic = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInAssocaitesNonIslamic;
        public const string InvestmentInSubsidiaries = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInSubsidiaries;
        public const string InvestmentInSubsidiariesNonIslamic = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.InvestmentInSubsidiariesNonIslamic;
        public const string OtherLongTermInvestment = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.OtherLongTermInvestment;
        public const string OtherLongTermInvestmentNonIslamic = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.OtherLongTermInvestmentNonIslamic;
        public const string GovernmentBonds = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.GovernmentBonds;
        public const string GovernmentBondsNonIslamic = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.GovernmentBondsNonIslamic;
        public const string GovernmentSukuk = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.GovernmentSukuk;
        public const string CorporateSukuk = CommonConstants.PreParameter + TotalLongTermInvestmentConstants.CorporateSukuk;

        public const string SP_Insert = "TotalLongTermInvestmentInsert";
        public const string SP_Update = "TotalLongTermInvestmentUpdate";
        public const string SP_Delete = "TotalLongTermInvestmentDelete";
        public const string SP_FindAll = "TotalLongTermInvestmentFindAll";
        public const string SP_FindByID = "TotalLongTermInvestmentFindByID";
        public const string SP_FindBYAssetsID = "TotalLongTermInvestmentFindByAssetsID";
        public const string SP_DeleteBYAssetsID = "TotalLongTermInvestmentDeleteByAssetsID";
    }
}
