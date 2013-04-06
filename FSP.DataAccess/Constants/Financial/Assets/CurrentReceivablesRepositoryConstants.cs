using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class CurrentReceivablesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CurrentReceivablesConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + CurrentReceivablesConstants.AssetsID;
        public const string Inventories = CommonConstants.PreParameter + CurrentReceivablesConstants.Inventories;
        public const string AdvancedPaymentsToSuppliers = CommonConstants.PreParameter + CurrentReceivablesConstants.AdvancedPaymentsToSuppliers;
        public const string OtherCurrentAssets = CommonConstants.PreParameter + CurrentReceivablesConstants.OtherCurrentAssets;
        public const string OtherCurrentAssetsNonIslamic = CommonConstants.PreParameter + CurrentReceivablesConstants.OtherCurrentAssetsNonIslamic;

        public const string SP_Insert = "CurrentReceivablesInsert";
        public const string SP_Update = "CurrentReceivablesUpdate";
        public const string SP_Delete = "CurrentReceivablesDelete";
        public const string SP_FindAll = "CurrentReceivablesFindAll";
        public const string SP_FindByID = "CurrentReceivablesFindByID";
    }
}
