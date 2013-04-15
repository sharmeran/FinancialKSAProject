using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class NetReceivablesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + NetReceivablesConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + NetReceivablesConstants.AssetsID;
        public const string AccountsReceivables = CommonConstants.PreParameter + NetReceivablesConstants.AccountsReceivables;
        public const string ProvisionForDoubtfulReceivables = CommonConstants.PreParameter + NetReceivablesConstants.ProvisionForDoubtfulReceivables;
        public const string OtherReceivables = CommonConstants.PreParameter + NetReceivablesConstants.OtherReceivables;

        public const string SP_Insert = "NetReceivablesInsert";
        public const string SP_Update = "NetReceivablesUpdate";
        public const string SP_Delete = "NetReceivablesDelete";
        public const string SP_FindAll = "NetReceivablesFindAll";
        public const string SP_FindByID = "NetReceivablesFindByID";
        public const string SP_FindBYAssetsID = "NetReceivablesFindByAssetsID";
        public const string SP_DeleteBYAssetsID = "NetReceivablesDeleteByAssetsID";
    }
}
