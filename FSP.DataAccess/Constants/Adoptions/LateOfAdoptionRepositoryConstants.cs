using FSP.Common.Constants.Adoptions;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Adoptions
{
   public static class LateOfAdoptionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + LateOfAdoptionConstants.ID;
       public const string AdoptionMetaID = CommonConstants.PreParameter + LateOfAdoptionConstants.AdoptionMetaID;
       public const string LateOfAdoptionValue = CommonConstants.PreParameter + LateOfAdoptionConstants.LateOfAdoptionValue;
       public const string Year = CommonConstants.PreParameter + LateOfAdoptionConstants.Year;

       public const string SP_Insert = "LateOfAdoptionInsert";
       public const string SP_DeleteByAdoptionMetaID = "LateOfAdoptionDeleteByAdoptionMetaID";
       public const string SP_FindByAdoptionMetaID = "LateOfAdoptionFindByAdoptionMetaID";

    }
}
