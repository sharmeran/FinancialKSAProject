using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class RevenueRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + RevenueConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + RevenueConstants.IncomeStatmentID;
        public const string RevenueValue = CommonConstants.PreParameter + RevenueConstants.RevenueValue;
        public const string CostOfRevenue = CommonConstants.PreParameter + RevenueConstants.CostOfRevenue;

        public const string SP_Insert = "RevenueInsert";
        public const string SP_Update = "RevenueUpdate";
        public const string SP_Delete = "RevenueDelete";
        public const string SP_FindAll = "RevenueFindAll";
        public const string SP_FindByID = "RevenueFindByID";
        public const string SP_FindBYIncomeStatmentID = "RevenueFindByIncomeStatmentID";
        public const string SP_DeleteBYIncomeStatmentID = "RevenueDeleteByIncomeStatmentID";
    }
}
