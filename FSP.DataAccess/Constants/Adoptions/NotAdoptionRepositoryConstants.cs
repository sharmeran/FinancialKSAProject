using FSP.Common.Constants.Adoptions;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Adoptions
{
   public static class NotAdoptionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + NotAdoptionConstants.ID;
       public const string AdoptionMetaID = CommonConstants.PreParameter + NotAdoptionConstants.AdoptionMetaID;
       public const string NoNeedAdoption = CommonConstants.PreParameter + NotAdoptionConstants.NoNeedAdoption;
       public const string Year = CommonConstants.PreParameter + NotAdoptionConstants.Year;

       public const string SP_Insert = "NotAdoptionInsert";
       public const string SP_DeleteByAdoptionMetaID = "NotAdoptionDeleteByAdoptionMetaID";
       public const string SP_FindByAdoptionMetaID = "NotAdoptionFindByAdoptionMetaID";
    }
}
