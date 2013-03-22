using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Administration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Administration
{
  public static class AccessListRepositoryConstants
    {
      public const string ID = CommonConstants.PreParameter + AccessListConstants.ID;
      public const string Name = CommonConstants.PreParameter + AccessListConstants.Name;
      public const string Description = CommonConstants.PreParameter + AccessListConstants.Description;

      public const string SP_Insert = "AccessListInsert";
      public const string SP_Update = "AccessListUpdate";
      public const string SP_Delete = "AccessListDelete";
      public const string SP_FindAll = "AccessListFindAll";
      public const string SP_FindByID = "AccessListFindByID";
    }
}
