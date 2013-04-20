using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class IncomeBeforeXORepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + IncomeBeforeXOConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + IncomeBeforeXOConstants.IncomeStatmentID;
        public const string IncomeBeforeXOItems = CommonConstants.PreParameter + IncomeBeforeXOConstants.IncomeBeforeXOItems;
        public const string ExtraordinaryLossNetof = CommonConstants.PreParameter + IncomeBeforeXOConstants.ExtraordinaryLossNetof;
        public const string NetProfitBeforeMinority = CommonConstants.PreParameter + IncomeBeforeXOConstants.NetProfitBeforeMinority;
        public const string MinorityInterests = CommonConstants.PreParameter + IncomeBeforeXOConstants.MinorityInterests;

        public const string SP_Insert = "IncomeBeforeXOInsert";
        public const string SP_Update = "IncomeBeforeXOUpdate";
        public const string SP_Delete = "IncomeBeforeXODelete";
        public const string SP_FindAll = "IncomeBeforeXOFindAll";
        public const string SP_FindByID = "IncomeBeforeXOFindByID";
        public const string SP_FindBYIncomeStatmentID = "IncomeBeforeXOFindByIncomeStatmentID";
        public const string SP_DeleteBYIncomeStatmentID = "IncomeBeforeXODeleteByIncomeStatmentID";
    }
}
