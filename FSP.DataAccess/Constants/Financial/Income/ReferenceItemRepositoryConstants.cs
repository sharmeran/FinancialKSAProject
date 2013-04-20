using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class ReferenceItemRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + ReferenceItemConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + ReferenceItemConstants.IncomeStatmentID;
        public const string EBITDA = CommonConstants.PreParameter + ReferenceItemConstants.EBITDA;
        public const string GrossMargin = CommonConstants.PreParameter + ReferenceItemConstants.GrossMargin;
        public const string OperatingMargin = CommonConstants.PreParameter + ReferenceItemConstants.OperatingMargin;
        public const string ProfitMargin = CommonConstants.PreParameter + ReferenceItemConstants.ProfitMargin;
        public const string ActualSalesPerEmployee = CommonConstants.PreParameter + ReferenceItemConstants.ActualSalesPerEmployee;
        public const string DividendsPerShare = CommonConstants.PreParameter + ReferenceItemConstants.DividendsPerShare;
        public const string TotalCashCommonDividends = CommonConstants.PreParameter + ReferenceItemConstants.TotalCashCommonDividends;
        public const string SalesGrowth = CommonConstants.PreParameter + ReferenceItemConstants.SalesGrowth;
        public const string BasicEPSBeforeXOGrowth = CommonConstants.PreParameter + ReferenceItemConstants.BasicEPSBeforeXOGrowth;
        public const string InterestIncome = CommonConstants.PreParameter + ReferenceItemConstants.InterestIncome;
        public const string CapitalizedInterestExpense = CommonConstants.PreParameter + ReferenceItemConstants.CapitalizedInterestExpense;
        public const string ResearchDevelopmentExpense = CommonConstants.PreParameter + ReferenceItemConstants.ResearchDevelopmentExpense;
        public const string DepreciationExpense = CommonConstants.PreParameter + ReferenceItemConstants.DepreciationExpense;
        public const string PartialRecordIndicator = CommonConstants.PreParameter + ReferenceItemConstants.PartialRecordIndicator;

        public const string SP_Insert = "ReferenceItemsInsert";
        public const string SP_Update = "ReferenceItemsUpdate";
        public const string SP_Delete = "ReferenceItemsDelete";
        public const string SP_FindAll = "ReferenceItemsFindAll";
        public const string SP_FindByID = "ReferenceItemsFindByID";
        public const string SP_FindBYIncomeStatmentID = "ReferenceItemsFindByIncomeStatmentID";
        public const string SP_DeleteBYIncomeStatmentID = "ReferenceItemsDeleteByIncomeStatmentID";
    }
}
