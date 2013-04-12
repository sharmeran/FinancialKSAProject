using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial.Assets;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Financial.Assets
{
    public static class TotalCurrentAssetsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + TotalCurrentAssetsConstants.ID;
        public const string AssetsID = CommonConstants.PreParameter + TotalCurrentAssetsConstants.AssetsID;
        public const string LongTermInvestments = CommonConstants.PreParameter + TotalCurrentAssetsConstants.LongTermInvestments;
        public const string GrossFixedAssets = CommonConstants.PreParameter + TotalCurrentAssetsConstants.GrossFixedAssets;
        public const string LandAndBuildings = CommonConstants.PreParameter + TotalCurrentAssetsConstants.LandAndBuildings;
        public const string LeaseholdImprovements = CommonConstants.PreParameter + TotalCurrentAssetsConstants.LeaseholdImprovements;
        public const string CellSitesInfrastructure = CommonConstants.PreParameter + TotalCurrentAssetsConstants.CellSitesInfrastructure;
        public const string FurnitureAndEquipment = CommonConstants.PreParameter + TotalCurrentAssetsConstants.FurnitureAndEquipment;
        public const string OtherFixedAssets = CommonConstants.PreParameter + TotalCurrentAssetsConstants.OtherFixedAssets;
        public const string AccumulatedDepreciation = CommonConstants.PreParameter + TotalCurrentAssetsConstants.AccumulatedDepreciation;
        public const string CapitalWorkingInProgress = CommonConstants.PreParameter + TotalCurrentAssetsConstants.CapitalWorkingInProgress;
        public const string NetFixedAssets = CommonConstants.PreParameter + TotalCurrentAssetsConstants.NetFixedAssets;

        public const string SP_Insert = "TotalCurrentAssetsInsert";
        public const string SP_Update = "TotalCurrentAssetsUpdate";
        public const string SP_Delete = "TotalCurrentAssetsDelete";
        public const string SP_FindAll = "TotalCurrentAssetsFindAll";
        public const string SP_FindByID = "TotalCurrentAssetsFindByID";
        public const string SP_FindBYAssetsID = "TotalCurrentAssetsFindByAssetsID";
    }
}
