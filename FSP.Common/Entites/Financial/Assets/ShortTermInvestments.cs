using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class ShortTermInvestments : BaseClass
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
        float moneyMarketFundIslamic;

        public float MoneyMarketFundIslamic
        {
            get { return moneyMarketFundIslamic; }
            set { moneyMarketFundIslamic = value; }
        }
        float moneyMarketFundConventional;

        public float MoneyMarketFundConventional
        {
            get { return moneyMarketFundConventional; }
            set { moneyMarketFundConventional = value; }
        }
        float conventionalBonds;

        public float ConventionalBonds
        {
            get { return conventionalBonds; }
            set { conventionalBonds = value; }
        }
        float sukuk;

        public float Sukuk
        {
            get { return sukuk; }
            set { sukuk = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
