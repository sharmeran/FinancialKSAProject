using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class TotalFinancialIncomeRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + TotalFinancialIncomeConstants.ID;
        public const string IncomeStatmentID = CommonConstants.PreParameter + TotalFinancialIncomeConstants.IncomeStatmentID;
        public const string TotalFinancialIncomeValue = CommonConstants.PreParameter + TotalFinancialIncomeConstants.TotalFinancialIncomeValue;
        public const string NetProfit = CommonConstants.PreParameter + TotalFinancialIncomeConstants.NetProfit;
        public const string IncomeTaxZakat = CommonConstants.PreParameter + TotalFinancialIncomeConstants.IncomeTaxZakat;
        public const string TaxZakatProvision = CommonConstants.PreParameter + TotalFinancialIncomeConstants.TaxZakatProvision;
        public const string ZakatRate = CommonConstants.PreParameter + TotalFinancialIncomeConstants.ZakatRate;

        public const string SP_Insert = "TotalFinancialIncomeInsert";
        public const string SP_Update = "TotalFinancialIncomeUpdate";
        public const string SP_Delete = "TotalFinancialIncomeDelete";
        public const string SP_FindAll = "TotalFinancialIncomeFindAll";
        public const string SP_FindByID = "TotalFinancialIncomeFindByID";
    }
}
