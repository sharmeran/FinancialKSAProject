using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class OtherLongTermLiabilitiesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.AssetsID;
        public const string OtherLongTermLiabilitiesIslamic = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.OtherLongTermLiabilitiesIslamic;
        public const string OtherLongTermLiabilitiesNonIslamic = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.OtherLongTermLiabilitiesNonIslamic;
        public const string TotalLongTermLiabilities = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.TotalLongTermLiabilities;
        public const string TotalLiabilities = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.TotalLiabilities;
        public const string TotalProvisions = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.TotalProvisions;
        public const string TaxProvisions = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.TaxProvisions;
        public const string DeferredTaxIncome = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.DeferredTaxIncome;
        public const string DeferredIncome = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.DeferredIncome;
        public const string ProvisionForEmployeesTermInationbenefits = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.ProvisionForEmployeesTermInationbenefits;
        public const string WarrantiesAndOptions = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.WarrantiesAndOptions;
        public const string WarrantiesAndOptionsNonIslamic = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.WarrantiesAndOptionsNonIslamic;
        public const string OtherProvisions = CommonConstants.PreParameter + OtherLongTermLiabilitiesConstants.OtherProvisions;

        public const string SP_Insert = "OtherLongTermLiabilitiesInsert";
        public const string SP_Update = "OtherLongTermLiabilitiesUpdate";
        public const string SP_Delete = "OtherLongTermLiabilitiesDelete";
        public const string SP_FindAll = "OtherLongTermLiabilitiesFindAll";
        public const string SP_FindByID = "OtherLongTermLiabilitiesFindByID";
        public const string SP_FindBYAssetsID = "OtherLongTermLiabilitiesFindByAssetsID";
    }
}
