using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.CashFlow;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.CashFlow
{
    public static class CashFlowStatementRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CashFlowStatementConstants.ID;
        public const string CompanyFinancialModelID = CommonConstants.PreParameter + CashFlowStatementConstants.CompanyFinancialModelID;

        public const string SP_Insert = "CashFlowStatementInsert";
        public const string SP_FindBYCompanyFinancialModelID = "CashFlowStatementFindByCompanyFinancialModelID";
        public const string SP_DeleteByCompanyFinancialModelID = "CashFlowStatementDeleteByCompanyFinancialModelID";
    }
}
