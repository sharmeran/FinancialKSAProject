using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Zakat;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Zakat
{
   public static class ZakatMetaRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ZakatMetaConstants.ID;
       public const string ZakatMainID = CommonConstants.PreParameter + ZakatMetaConstants.ZakatMainID;
       public const string ZakatCollectionNumber = CommonConstants.PreParameter + ZakatMetaConstants.ZakatCollectionNumber;
       public const string ZakatCustomCollectionNumber = CommonConstants.PreParameter + ZakatMetaConstants.ZakatCustomCollectionNumber;
       public const string ZacatSubCollectionNumber = CommonConstants.PreParameter + ZakatMetaConstants.ZacatSubCollectionNumber;
       public const string ZakatSubCustomCollectionNumber = CommonConstants.PreParameter + ZakatMetaConstants.ZakatSubCustomCollectionNumber;

       public const string SP_Insert = "ZakatMetaInsert";
       public const string SP_DeleteByZakatMainID = "ZakatMetaDeleteByZakatMainID";
       public const string SP_FindByZakatMainID = "ZakatMetaFindByZakatMainID";
    }
}
