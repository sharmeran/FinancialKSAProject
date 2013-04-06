using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class TotalCurrentLiabilitiesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.AssetsID;
        public const string GovernmentCharge = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.GovernmentCharge;
        public const string AccountsPayable = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.AccountsPayable;
        public const string AccruedExpense = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.AccruedExpense;
        public const string DownPayment = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.DownPayment;
        public const string TaxesPayable = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.TaxesPayable;
        public const string ZakatPayable = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.ZakatPayable;
        public const string DividendsPayable = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.DividendsPayable;
        public const string DueToSisterCompanies = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.DueToSisterCompanies;
        public const string OtherCurrentLiabilities = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.OtherCurrentLiabilities;
        public const string OtherCurrentLiabilitiesNonIslamic = CommonConstants.PreParameter + TotalCurrentLiabilitiesConstants.OtherCurrentLiabilitiesNonIslamic;

        public const string SP_Insert = "TotalCurrentLiabilitiesInsert";
        public const string SP_Update = "TotalCurrentLiabilitiesUpdate";
        public const string SP_Delete = "TotalCurrentLiabilitiesDelete";
        public const string SP_FindAll = "TotalCurrentLiabilitiesFindAll";
        public const string SP_FindByID = "TotalCurrentLiabilitiesFindByID";
    }
}
