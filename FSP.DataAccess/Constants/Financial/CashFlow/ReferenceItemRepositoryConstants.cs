using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.CashFlow;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.CashFlow
{
    public static class ReferenceItemRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + ReferenceItemConstants.ID;
        public const string CashFlowStatementID = CommonConstants.PreParameter + ReferenceItemConstants.CashFlowStatementID;
        public const string EBITDA = CommonConstants.PreParameter + ReferenceItemConstants.EBITDA;
        public const string NetCashPaidForAcquisitions = CommonConstants.PreParameter + ReferenceItemConstants.NetCashPaidForAcquisitions;
        public const string FreeCashFlow = CommonConstants.PreParameter + ReferenceItemConstants.FreeCashFlow;
        public const string FreeCashFlowToFirm = CommonConstants.PreParameter + ReferenceItemConstants.FreeCashFlowToFirm;
        public const string FreeCashFlowEquity = CommonConstants.PreParameter + ReferenceItemConstants.FreeCashFlowEquity;
        public const string FreeCashFlowBasicShare = CommonConstants.PreParameter + ReferenceItemConstants.FreeCashFlowBasicShare;
        public const string PriceFreeCashFlow = CommonConstants.PreParameter + ReferenceItemConstants.PriceFreeCashFlow;
        public const string CashFlowNetIncome = CommonConstants.PreParameter + ReferenceItemConstants.CashFlowNetIncome;

        public const string SP_Insert = "ReferenceItemInsert";
        public const string SP_Update = "ReferenceItemUpdate";
        public const string SP_Delete = "ReferenceItemDelete";
        public const string SP_FindAll = "ReferenceItemFindAll";
        public const string SP_FindByID = "ReferenceItemFindByID";
    }
}
