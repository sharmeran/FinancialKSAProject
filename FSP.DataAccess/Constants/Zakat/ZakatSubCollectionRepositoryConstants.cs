using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Zakat;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Zakat
{
   public static class ZakatSubCollectionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ZakatSubCollectionConstants.ID;
        public const string Year = CommonConstants.PreParameter + ZakatSubCollectionConstants.Year;
        public const string Value = CommonConstants.PreParameter + ZakatSubCollectionConstants.Value;
        public const string ZakatMetaID = CommonConstants.PreParameter + ZakatSubCollectionConstants.ZakatMetaID;
        public const string CompanyID = CommonConstants.PreParameter + ZakatSubCollectionConstants.CompanyID;

        public const string SP_Insert = "ZakatSubCollectionInsert";
        public const string SP_DeleteByZakatMetaID = "ZakatSubCollectionDeleteByZakatMetaID";
        public const string SP_FindByZakatMetaID = "ZakatSubCollectionFindByZakatMetaID";
    }
}
