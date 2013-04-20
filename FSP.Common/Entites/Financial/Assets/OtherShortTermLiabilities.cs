using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class OtherShortTermLiabilities : BaseClass
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
        float otherShortTerm;

        public float OtherShortTerm
        {
            get { return otherShortTerm; }
            set { otherShortTerm = value; }
        }
        float otherShortTermNonIslamic;

        public float OtherShortTermNonIslamic
        {
            get { return otherShortTermNonIslamic; }
            set { otherShortTermNonIslamic = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
