using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class TotalLiabilitiesAndProvisionsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.AssetsID;
        public const string TotalShareholdersEquity = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.TotalShareholdersEquity;
        public const string MinorityInterest = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.MinorityInterest;
        public const string PaidupCapital = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.PaidupCapital;
        public const string SharePremium = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.SharePremium;
        public const string LegalStatutoryReserve = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.LegalStatutoryReserve;
        public const string GeneralVoluntaryReserve = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.GeneralVoluntaryReserve;
        public const string CapitalReserve = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.CapitalReserve;
        public const string ChgInFairValResvTranslationAdj = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.ChgInFairValResvTranslationAdj;
        public const string Reserves = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.Reserves;
        public const string DueToShareholdersAppropriate = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.DueToShareholdersAppropriate;
        public const string RetaInedEarnIngsAccimulatedLosses = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.RetaInedEarnIngsAccimulatedLosses;
        public const string NetProfitofTheYear = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.NetProfitofTheYear;
        public const string TreasuryStock = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.TreasuryStock;
        public const string TotalLiabilitiesAndEquity = CommonConstants.PreParameter + TotalLiabilitiesAndProvisionsConstants.TotalLiabilitiesAndEquity;

        public const string SP_Insert = "TotalLiabilitiesAndProvisionsInsert";
        public const string SP_Update = "TotalLiabilitiesAndProvisionsUpdate";
        public const string SP_Delete = "TotalLiabilitiesAndProvisionsDelete";
        public const string SP_FindAll = "TotalLiabilitiesAndProvisionsFindAll";
        public const string SP_FindByID = "TotalLiabilitiesAndProvisionsFindByID";
    }
}
