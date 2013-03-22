using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Zakat;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Zakat
{
   public static class ZakatCustomSubCollectionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ZakatCustomSubCollectionConstants.ID;
        public const string Year = CommonConstants.PreParameter + ZakatCustomSubCollectionConstants.Year;
        public const string Value = CommonConstants.PreParameter + ZakatCustomSubCollectionConstants.Value;
        public const string ZakatMetaID = CommonConstants.PreParameter + ZakatCustomSubCollectionConstants.ZakatMetaID;
        public const string CompanyID = CommonConstants.PreParameter + ZakatCustomSubCollectionConstants.CompanyID;

        public const string SP_Insert = "ZakatCustomSubCollectionInsert";
        public const string SP_DeleteByZakatMetaID = "ZakatCustomSubCollectionDeleteByZakatMetaID";
        public const string SP_FindByZakatMetaID = "ZakatCustomSubCollectionFindByZakatMetaID";
    }
}
