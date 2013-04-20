using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class NetReceivables : BaseClass
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
        float accountsReceivables;

        public float AccountsReceivables
        {
            get { return accountsReceivables; }
            set { accountsReceivables = value; }
        }
        float provisionForDoubtfulReceivables;

        public float ProvisionForDoubtfulReceivables
        {
            get { return provisionForDoubtfulReceivables; }
            set { provisionForDoubtfulReceivables = value; }
        }
        float otherReceivables;

        public float OtherReceivables
        {
            get { return otherReceivables; }
            set { otherReceivables = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
