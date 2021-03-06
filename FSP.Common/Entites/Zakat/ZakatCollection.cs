﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Zakat
{
   public class ZakatCollection:BaseClass
    {
        int iD;
        int year;
        float value;
        int zakatMetaID;


        public int ZakatMetaID
        {
            get { return zakatMetaID; }
            set { zakatMetaID = value; }
        }


        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
