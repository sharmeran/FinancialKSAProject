using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Income;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Income
{
    public static class IncomeStatmentRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + IncomeStatmentConstants.ID;
        public const string CompanyFinancialModelID = CommonConstants.PreParameter + IncomeStatmentConstants.CompanyFinancialModelID;

        public const string SP_Insert = "IncomeStatmentInsert";
        public const string SP_FindBYCompanyFinancialModelID = "IncomeStatmentFindByCompanyFinancialModelID";
        public const string SP_DeleteByCompanyFinancialModelID = "IncomeStatmentDeleteByCompanyFinancialModelID";
    }
}
