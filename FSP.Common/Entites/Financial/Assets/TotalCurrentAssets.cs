using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class TotalCurrentAssets : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int assetsID;

        public int AssetsID
        {
            get { return assetsID; }
            set { assetsID = value; }
        }
        float longTermInvestments;

        public float LongTermInvestments
        {
            get { return longTermInvestments; }
            set { longTermInvestments = value; }
        }
        float grossFixedAssets;

        public float GrossFixedAssets
        {
            get { return grossFixedAssets; }
            set { grossFixedAssets = value; }
        }
        float landAndBuildings;

        public float LandAndBuildings
        {
            get { return landAndBuildings; }
            set { landAndBuildings = value; }
        }
        float leaseholdImprovements;

        public float LeaseholdImprovements
        {
            get { return leaseholdImprovements; }
            set { leaseholdImprovements = value; }
        }
        float cellSitesInfrastructure;

        public float CellSitesInfrastructure
        {
            get { return cellSitesInfrastructure; }
            set { cellSitesInfrastructure = value; }
        }
        float furnitureAndEquipment;

        public float FurnitureAndEquipment
        {
            get { return furnitureAndEquipment; }
            set { furnitureAndEquipment = value; }
        }
        float otherFixedAssets;

        public float OtherFixedAssets
        {
            get { return otherFixedAssets; }
            set { otherFixedAssets = value; }
        }
        float accumulatedDepreciation;

        public float AccumulatedDepreciation
        {
            get { return accumulatedDepreciation; }
            set { accumulatedDepreciation = value; }
        }
        float capitalWorkingInProgress;

        public float CapitalWorkingInProgress
        {
            get { return capitalWorkingInProgress; }
            set { capitalWorkingInProgress = value; }
        }
        float netFixedAssets;

        public float NetFixedAssets
        {
            get { return netFixedAssets; }
            set { netFixedAssets = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
