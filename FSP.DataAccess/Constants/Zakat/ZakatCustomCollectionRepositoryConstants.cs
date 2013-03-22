using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Zakat;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Zakat
{
   public static class ZakatCustomCollectionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ZakatCustomCollectionConstants.ID;
        public const string Year = CommonConstants.PreParameter + ZakatCustomCollectionConstants.Year;
        public const string Value = CommonConstants.PreParameter + ZakatCustomCollectionConstants.Value;
        public const string ZakatMetaID = CommonConstants.PreParameter + ZakatCustomCollectionConstants.ZakatMetaID;

        public const string SP_Insert = "ZakatCustomCollectionInsert";
        public const string SP_DeleteByZakatMetaID = "ZakatCustomCollectionDeleteByZakatMetaID";
        public const string SP_FindByZakatMetaID = "ZakatCustomCollectionFindByZakatMetaID";
    }
}
