using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial
{
    public static class CompanyFinancialModelRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CompanyFinancialModelConstants.ID;
        public const string CompanyID = CommonConstants.PreParameter + CompanyFinancialModelConstants.CompanyID;
        public const string IsReviewed = CommonConstants.PreParameter + CompanyFinancialModelConstants.IsReviewed;
        public const string Year = CommonConstants.PreParameter + CompanyFinancialModelConstants.Year;
        public const string UserID = CommonConstants.PreParameter + CompanyFinancialModelConstants.UserID;
        public const string CreatedDate = CommonConstants.PreParameter + CompanyFinancialModelConstants.CreatedDate;
        public const string ReviewedUserID = CommonConstants.PreParameter + CompanyFinancialModelConstants.ReviewedUserID;
        public const string IsApproved = CommonConstants.PreParameter + CompanyFinancialModelConstants.IsApproved;

        public const string SP_Insert = "CompanyFinancialModelInsert";
        public const string SP_Update = "CompanyFinancialModelUpdate";
        public const string SP_Delete = "CompanyFinancialModelDelete";
        public const string SP_FindAll = "CompanyFinancialModelFindAll";
        public const string SP_FindByID = "CompanyFinancialModelFindByID";
    }
}
