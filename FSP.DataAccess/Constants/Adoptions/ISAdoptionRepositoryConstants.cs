using FSP.Common.Constants.Adoptions;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Adoptions
{
   public static class ISAdoptionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ISAdoptionConstants.ID;
       public const string AdoptionMetaID = CommonConstants.PreParameter + ISAdoptionConstants.AdoptionMetaID;
       public const string Year = CommonConstants.PreParameter + ISAdoptionConstants.Year;

       public const string SP_Insert = "ISAdoptionInsert";
       public const string SP_DeleteByAdoptionMetaID = "ISAdoptionDeleteByAdoptionMetaID";
       public const string SP_FindByAdoptionMetaID = "ISAdoptionFindByAdoptionMetaID";
    }
}
