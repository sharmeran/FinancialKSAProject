using FSP.Common.Constants.Adoptions;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Adoptions
{
   public static class TestRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + TestConstants.ID;
       public const string AdoptionMetaID = CommonConstants.PreParameter + TestConstants.AdoptionMetaID;
       public const string Year = CommonConstants.PreParameter + TestConstants.Year;

       public const string SP_Insert = "TestInsert";
       public const string SP_DeleteByAdoptionMetaID = "TestDeleteByAdoptionMetaID";
       public const string SP_FindByAdoptionMetaID = "TestFindByAdoptionMetaID";
    }
}
