using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class OtherShortTermLiabilitiesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + OtherShortTermLiabilitiesConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + OtherShortTermLiabilitiesConstants.AssetsID;
        public const string OtherShortTerm = CommonConstants.PreParameter + OtherShortTermLiabilitiesConstants.OtherShortTerm;
        public const string OtherShortTermNonIslamic = CommonConstants.PreParameter + OtherShortTermLiabilitiesConstants.OtherShortTermNonIslamic;

        public const string SP_Insert = "OtherShortTermLiabilitiesInsert";
        public const string SP_Update = "OtherShortTermLiabilitiesUpdate";
        public const string SP_Delete = "OtherShortTermLiabilitiesDelete";
        public const string SP_FindAll = "OtherShortTermLiabilitiesFindAll";
        public const string SP_FindByID = "OtherShortTermLiabilitiesFindByID";
    }
}
