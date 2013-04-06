using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class GrossProfitRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + GrossProfitConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + GrossProfitConstants.IncomeStatmentID;
        public const string GrossProfitValue = CommonConstants.PreParameter + GrossProfitConstants.GrossProfitValue;
        public const string Selling = CommonConstants.PreParameter + GrossProfitConstants.Selling;

        public const string SP_Insert = "GrossProfitInsert";
        public const string SP_Update = "GrossProfitUpdate";
        public const string SP_Delete = "GrossProfitDelete";
        public const string SP_FindAll = "GrossProfitFindAll";
        public const string SP_FindByID = "GrossProfitFindByID";
    }
}
