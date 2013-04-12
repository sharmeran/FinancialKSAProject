using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class CashAndCashEquivalentRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CashAndCashEquivalentConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + CashAndCashEquivalentConstants.AssetsID;
        public const string Cash = CommonConstants.PreParameter + CashAndCashEquivalentConstants.Cash;
        public const string DueAmountFromRelatedParties = CommonConstants.PreParameter + CashAndCashEquivalentConstants.DueAmountFromRelatedParties;
        public const string CashEquivalentConventional = CommonConstants.PreParameter + CashAndCashEquivalentConstants.CashEquivalentConventional;
        public const string CashCollateral = CommonConstants.PreParameter + CashAndCashEquivalentConstants.CashCollateral;
        public const string TimeDepositIslamic = CommonConstants.PreParameter + CashAndCashEquivalentConstants.TimeDepositIslamic;
        public const string TimeDepositConventional = CommonConstants.PreParameter + CashAndCashEquivalentConstants.TimeDepositConventional;

        public const string SP_Insert = "CashAndCashEquivalentInsert";
        public const string SP_Update = "CashAndCashEquivalentUpdate";
        public const string SP_Delete = "CashAndCashEquivalentDelete";
        public const string SP_FindAll = "CashAndCashEquivalentFindAll";
        public const string SP_FindByID = "CashAndCashEquivalentFindByID";
        public const string SP_FindBYAssetsID = "CashAndCashEquivalentFindByAssetsID";
    }
}
