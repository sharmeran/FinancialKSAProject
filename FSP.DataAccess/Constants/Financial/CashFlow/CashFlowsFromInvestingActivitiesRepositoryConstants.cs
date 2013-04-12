using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.CashFlow;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.CashFlow
{
    public static class CashFlowsFromInvestingActivitiesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.ID;
        public const string CashFlowStatementID = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.CashFlowStatementID;
        public const string DisposalOfFixedAssets = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.DisposalOfFixedAssets;
        public const string CapitalExpenditures = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.CapitalExpenditures;
        public const string DecInPropertyPlant = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.DecInPropertyPlant;
        public const string IncreaseInInvestments = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.IncreaseInInvestments;
        public const string DecreaseInInvestments = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.DecreaseInInvestments;
        public const string OtherCashInflow = CommonConstants.PreParameter + CashFlowsFromInvestingActivitiesConstants.OtherCashInflow;

        public const string SP_Insert = "CashFlowsFromInvestingActivitiesInsert";
        public const string SP_Update = "CashFlowsFromInvestingActivitiesUpdate";
        public const string SP_Delete = "CashFlowsFromInvestingActivitiesDelete";
        public const string SP_FindAll = "CashFlowsFromInvestingActivitiesFindAll";
        public const string SP_FindByID = "CashFlowsFromInvestingActivitiesFindByID";
        public const string SP_FindBYCashFlowStatmentID = "CashFlowsFromInvestingActivitiesFindByCashFlowStatementID";
    }
}
