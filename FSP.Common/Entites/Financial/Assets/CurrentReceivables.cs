using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class CurrentReceivables : BaseClass
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
        float inventories;

        public float Inventories
        {
            get { return inventories; }
            set { inventories = value; }
        }
        float advancedPaymentsToSuppliers;

        public float AdvancedPaymentsToSuppliers
        {
            get { return advancedPaymentsToSuppliers; }
            set { advancedPaymentsToSuppliers = value; }
        }
        float otherCurrentAssets;

        public float OtherCurrentAssets
        {
            get { return otherCurrentAssets; }
            set { otherCurrentAssets = value; }
        }
        float otherCurrentAssetsNonIslamic;

        public float OtherCurrentAssetsNonIslamic
        {
            get { return otherCurrentAssetsNonIslamic; }
            set { otherCurrentAssetsNonIslamic = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
