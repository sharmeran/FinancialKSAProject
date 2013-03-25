using FSP.Common.Constants.Adoptions;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Adoptions
{
   public static class ViolationAdoptionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + ViolationAdoptionConstants.ID;
       public const string AdoptionMetaID = CommonConstants.PreParameter + ViolationAdoptionConstants.AdoptionMetaID;
       public const string ViolationAdoptionValue = CommonConstants.PreParameter + ViolationAdoptionConstants.ViolationAdoptionValue;
       public const string Year = CommonConstants.PreParameter + ViolationAdoptionConstants.Year;

       public const string SP_Insert = "ViolationAdoptionInsert";
       public const string SP_DeleteByAdoptionMetaID = "ViolationAdoptionDeleteByAdoptionMetaID";
       public const string SP_FindByAdoptionMetaID = "ViolationAdoptionFindByAdoptionMetaID";
    }
}
