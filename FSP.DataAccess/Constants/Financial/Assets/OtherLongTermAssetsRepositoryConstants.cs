using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class OtherLongTermAssetsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + OtherLongTermAssetsConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + OtherLongTermAssetsConstants.AssetsID;
        public const string DueAmountfromRelatedParties = CommonConstants.PreParameter + OtherLongTermAssetsConstants.DueAmountfromRelatedParties;
        public const string DueFromOtherTelecomOperatorsLT = CommonConstants.PreParameter + OtherLongTermAssetsConstants.DueFromOtherTelecomOperatorsLT;
        public const string NotesReceivables = CommonConstants.PreParameter + OtherLongTermAssetsConstants.NotesReceivables;
        public const string NotesReceivablesNonIslamic = CommonConstants.PreParameter + OtherLongTermAssetsConstants.NotesReceivablesNonIslamic;
        public const string PrepaidExpensesLT = CommonConstants.PreParameter + OtherLongTermAssetsConstants.PrepaidExpensesLT;
        public const string EmployeesUnionLoan = CommonConstants.PreParameter + OtherLongTermAssetsConstants.EmployeesUnionLoan;
        public const string EmployeesUnionLoanNonIslamic = CommonConstants.PreParameter + OtherLongTermAssetsConstants.EmployeesUnionLoanNonIslamic;
        public const string IncomeReceivables = CommonConstants.PreParameter + OtherLongTermAssetsConstants.IncomeReceivables;
        public const string DueFromTaxAuthority = CommonConstants.PreParameter + OtherLongTermAssetsConstants.DueFromTaxAuthority;
        public const string DueFromSisterCompaniesLT = CommonConstants.PreParameter + OtherLongTermAssetsConstants.DueFromSisterCompaniesLT;
        public const string DueFromSisterCompaniesLTNonIslamic = CommonConstants.PreParameter + OtherLongTermAssetsConstants.DueFromSisterCompaniesLTNonIslamic;

        public const string SP_Insert = "OtherLongTermAssetsInsert";
        public const string SP_Update = "OtherLongTermAssetsUpdate";
        public const string SP_Delete = "OtherLongTermAssetsDelete";
        public const string SP_FindAll = "OtherLongTermAssetsFindAll";
        public const string SP_FindByID = "OtherLongTermAssetsFindByID";
        public const string SP_FindBYAssetsID = "OtherLongTermAssetsFindByAssetsID";
        public const string SP_DeleteBYAssetsID = "OtherLongTermAssetsDeleteByAssetsID";
    }
}
