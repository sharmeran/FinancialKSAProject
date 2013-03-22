using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Zakat
{
   public class ZakatMeta : BaseClass
    {
        int iD;
        int zakatMainID;
        int zakatCollectionNumber;
        int zakatCustomCollectionNumber;
        int zacatSubCollectionNumber;
        int zakatSubCustomCollectionNumber;

        
        List<ZakatCollection> zakatCollectionList;
        List<ZakatCustomCollection> zakatCustomCollectionList;
        List<ZakatSubCollection> zakatSubCollectionList;
        List<ZakatCustomSubCollection> zakatCustomSubCollectionList;


        public int ZakatSubCustomCollectionNumber
        {
            get { return zakatSubCustomCollectionNumber; }
            set { zakatSubCustomCollectionNumber = value; }
        }

        public List<ZakatCustomSubCollection> ZakatCustomSubCollectionList
        {
            get { return zakatCustomSubCollectionList; }
            set { zakatCustomSubCollectionList = value; }
        }

        public List<ZakatSubCollection> ZakatSubCollectionList
        {
            get { return zakatSubCollectionList; }
            set { zakatSubCollectionList = value; }
        }

        public List<ZakatCustomCollection> ZakatCustomCollectionList
        {
            get { return zakatCustomCollectionList; }
            set { zakatCustomCollectionList = value; }
        }

        public List<ZakatCollection> ZakatCollectionList
        {
            get { return zakatCollectionList; }
            set { zakatCollectionList = value; }
        }
        

        public int ZacatSubCollectionNumber
        {
            get { return zacatSubCollectionNumber; }
            set { zacatSubCollectionNumber = value; }
        }

        public int ZakatCustomCollectionNumber
        {
            get { return zakatCustomCollectionNumber; }
            set { zakatCustomCollectionNumber = value; }
        }

        public int ZakatCollectionNumber
        {
            get { return zakatCollectionNumber; }
            set { zakatCollectionNumber = value; }
        }

        public int ZakatMainID
        {
            get { return zakatMainID; }
            set { zakatMainID = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
