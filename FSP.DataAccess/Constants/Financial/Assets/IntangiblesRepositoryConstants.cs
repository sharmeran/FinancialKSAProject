using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class IntangiblesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + IntangiblesConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + IntangiblesConstants.AssetsID;
        public const string Goodwill = CommonConstants.PreParameter + IntangiblesConstants.Goodwill;
        public const string Licences = CommonConstants.PreParameter + IntangiblesConstants.Licences;
        public const string TotalLongTermAssets = CommonConstants.PreParameter + IntangiblesConstants.TotalLongTermAssets;

        public const string SP_Insert = "IntangiblesInsert";
        public const string SP_Update = "IntangiblesUpdate";
        public const string SP_Delete = "IntangiblesDelete";
        public const string SP_FindAll = "IntangiblesFindAll";
        public const string SP_FindByID = "IntangiblesFindByID";
        public const string SP_FindBYAssetsID = "IntangiblesFindByAssetsID";
    }
}
