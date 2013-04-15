using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.CashFlow;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.CashFlow
{
    public static class CashFlowsFromOperatingActivitiesRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.ID;
        public const string CashFlowStatmentID = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.CashFlowStatmentID;
        public const string NetIncomeBeforeTaxMinorityInterest = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.NetIncomeBeforeTaxMinorityInterest;
        public const string DepreciationAmortization = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.DepreciationAmortization;
        public const string InterestedPaid = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.InterestedPaid;
        public const string InterestReceived = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.InterestReceived;
        public const string TaxAndZakatPaid = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.TaxAndZakatPaid;
        public const string MovementOnWoekingCapital = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.MovementOnWoekingCapital;
        public const string ChangeInOperatingActivities = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.ChangeInOperatingActivities;
        public const string ChangeInProvisions = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.ChangeInProvisions;
        public const string Others = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.Others;
        public const string OtherNonCashAdjustments = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.OtherNonCashAdjustments;
        public const string ChangesInNonCashCapital = CommonConstants.PreParameter + CashFlowsFromOperatingActivitiesConstants.ChangesInNonCashCapital;

        public const string SP_Insert = "CashFlowsFromOperatingActivitiesInsert";
        public const string SP_Update = "CashFlowsFromOperatingActivitiesUpdate";
        public const string SP_Delete = "CashFlowsFromOperatingActivitiesDelete";
        public const string SP_FindAll = "CashFlowsFromOperatingActivitiesFindAll";
        public const string SP_FindByID = "CashFlowsFromOperatingActivitiesFindByID";
        public const string SP_FindBYCashFlowStatmentID = "CashFlowsFromOperatingActivitiesFindByCashFlowStatmentID";
        public const string SP_DeleteBYCashFlowStatmentID = "CashFlowsFromOperatingActivitiesDeleteByCashFlowStatementID";
    }
}
