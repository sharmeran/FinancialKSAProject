using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.CashFlow;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.CashFlow
{
    public static class CashCashEquivalentPeriodEndRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CashCashEquivalentPeriodEndConstants.ID;
        public const string CashFlowStatementID = CommonConstants.PreParameter + CashCashEquivalentPeriodEndConstants.CashFlowStatementID;
        public const string NetChangeCashCashEquivalents = CommonConstants.PreParameter + CashCashEquivalentPeriodEndConstants.NetChangeCashCashEquivalents;
        public const string CashCashEquivalentAtStartOfPeriod = CommonConstants.PreParameter + CashCashEquivalentPeriodEndConstants.CashCashEquivalentAtStartOfPeriod;

        public const string SP_Insert = "CashCashEquivalentPeriodEndInsert";
        public const string SP_Update = "CashCashEquivalentPeriodEndUpdate";
        public const string SP_Delete = "CashCashEquivalentPeriodEndDelete";
        public const string SP_FindAll = "CashCashEquivalentPeriodEndFindAll";
        public const string SP_FindByID = "CashCashEquivalentPeriodEndFindByID";
    }
}
