using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class AssetRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + AssetConstants.ID;
        public const string CompanyFinancialModelID = CommonConstants.PreParameter + AssetConstants.CompanyFinancialModelID;

        public const string SP_Insert = "AssetsInsert";
        public const string SP_FindBYCompanyFinancialModelID = "AssetsFindByCompanyFinancialModelID";
        public const string SP_DeleteByCompanyFinancialModelID = "AssetsDeleteByCompanyFinancialModelID";
    }
}
