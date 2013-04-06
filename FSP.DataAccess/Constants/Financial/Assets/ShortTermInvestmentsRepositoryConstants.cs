using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class ShortTermInvestmentsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + ShortTermInvestmentsConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + ShortTermInvestmentsConstants.AssetsID;
        public const string MoneyMarketFundIslamic = CommonConstants.PreParameter + ShortTermInvestmentsConstants.MoneyMarketFundIslamic;
        public const string MoneyMarketFundConventional = CommonConstants.PreParameter + ShortTermInvestmentsConstants.MoneyMarketFundConventional;
        public const string ConventionalBonds = CommonConstants.PreParameter + ShortTermInvestmentsConstants.ConventionalBonds;
        public const string Sukuk = CommonConstants.PreParameter + ShortTermInvestmentsConstants.Sukuk;

        public const string SP_Insert = "ShortTermInvestmentsInsert";
        public const string SP_Update = "ShortTermInvestmentsUpdate";
        public const string SP_Delete = "ShortTermInvestmentsDelete";
        public const string SP_FindAll = "ShortTermInvestmentsFindAll";
        public const string SP_FindByID = "ShortTermInvestmentsFindByID";
    }
}
