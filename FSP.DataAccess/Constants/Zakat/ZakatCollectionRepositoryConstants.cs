using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Zakat;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Zakat
{
   public static class ZakatCollectionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ZakatCollectionConstants.ID;
       public const string Year = CommonConstants.PreParameter + ZakatCollectionConstants.Year;
       public const string Value = CommonConstants.PreParameter + ZakatCollectionConstants.Value;
       public const string ZakatMetaID = CommonConstants.PreParameter + ZakatCollectionConstants.ZakatMetaID;


       public const string SP_Insert = "ZakatCollectionInsert";       
       public const string SP_DeleteByZakatMetaID = "ZakatCollectionDeleteByZakatMetaID";
       public const string SP_FindByZakatMetaID = "ZakatCollectionFindByZakatMetaID";
       

    }
}
