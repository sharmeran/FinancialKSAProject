using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class OperatingIncomeRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + OperatingIncomeConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + OperatingIncomeConstants.IncomeStatmentID;
        public const string OperatingIncomevalue = CommonConstants.PreParameter + OperatingIncomeConstants.OperatingIncomevalue;
        public const string InterestExpense = CommonConstants.PreParameter + OperatingIncomeConstants.InterestExpense;
        public const string InterestExpenseNonIslamic = CommonConstants.PreParameter + OperatingIncomeConstants.InterestExpenseNonIslamic;
        public const string InterestIncome = CommonConstants.PreParameter + OperatingIncomeConstants.InterestIncome;
        public const string InterestIncomeNonIslamic = CommonConstants.PreParameter + OperatingIncomeConstants.InterestIncomeNonIslamic;
        public const string InvestmentIncome = CommonConstants.PreParameter + OperatingIncomeConstants.InvestmentIncome;
        public const string InvestmentIncomeNonIslamic = CommonConstants.PreParameter + OperatingIncomeConstants.InvestmentIncomeNonIslamic;
        public const string IncomeFromSister = CommonConstants.PreParameter + OperatingIncomeConstants.IncomeFromSister;
        public const string IncomeFromSisterNonIslamic = CommonConstants.PreParameter + OperatingIncomeConstants.IncomeFromSisterNonIslamic;
        public const string OtherIncome = CommonConstants.PreParameter + OperatingIncomeConstants.OtherIncome;
        public const string OtherExpenses = CommonConstants.PreParameter + OperatingIncomeConstants.OtherExpenses;
        public const string OtherIncomeNonIslamic = CommonConstants.PreParameter + OperatingIncomeConstants.OtherIncomeNonIslamic;
        public const string OtherExpensesNonIslamic = CommonConstants.PreParameter + OperatingIncomeConstants.OtherExpensesNonIslamic;

        public const string SP_Insert = "OperatingIncomeInsert";
        public const string SP_Update = "OperatingIncomeUpdate";
        public const string SP_Delete = "OperatingIncomeDelete";
        public const string SP_FindAll = "OperatingIncomeFindAll";
        public const string SP_FindByID = "OperatingIncomeFindByID";
    }
}
