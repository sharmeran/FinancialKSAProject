using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class Intangibles : BaseClass
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
        float goodwill;

        public float Goodwill
        {
            get { return goodwill; }
            set { goodwill = value; }
        }
        float licences;

        public float Licences
        {
            get { return licences; }
            set { licences = value; }
        }
        float totalLongTermAssets;

        public float TotalLongTermAssets
        {
            get { return totalLongTermAssets; }
            set { totalLongTermAssets = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
