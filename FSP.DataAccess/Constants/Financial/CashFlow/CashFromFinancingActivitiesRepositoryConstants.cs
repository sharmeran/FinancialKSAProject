using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.CashFlow;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.CashFlow
{
    public static class CashFromFinancingActivitiesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.ID;
        public const string CashFlowStatmentID = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.CashFlowStatmentID;
        public const string DividendsPaidDuringTheYear = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.DividendsPaidDuringTheYear;
        public const string IssuancesPurchasesEquityShares = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.IssuancesPurchasesEquityShares;
        public const string ChangeInShortTermBorrowings = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.ChangeInShortTermBorrowings;
        public const string CompanyFinancialModelID = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.CompanyFinancialModelID;
        public const string InLongTermBorrowings = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.InLongTermBorrowings;
        public const string InCapitalStocks = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.InCapitalStocks;
        public const string InLoans = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.InLoans;
        public const string EffectOfExchangeRatesOnCash = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.EffectOfExchangeRatesOnCash;
        public const string OtherFinInflow = CommonConstants.PreParameter + CashFromFinancingActivitiesConstants.OtherFinInflow;

        public const string SP_Insert = "CashFromFinancingActivitiesInsert";
        public const string SP_Update = "CashFromFinancingActivitiesUpdate";
        public const string SP_Delete = "CashFromFinancingActivitiesDelete";
        public const string SP_FindAll = "CashFromFinancingActivitiesFindAll";
        public const string SP_FindByID = "CashFromFinancingActivitiesFindByID";
        public const string SP_FindBYCashFlowStatmentID = "CashFromFinancingActivitiesFindByCashFlowStatmentID";
        public const string SP_DeleteBYCashFlowStatmentID = "CashFromFinancingActivitiesDeleteByCashFlowStatementID";
    }
}
