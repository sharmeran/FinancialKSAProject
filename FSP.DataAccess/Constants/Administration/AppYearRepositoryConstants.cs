using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Administration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Administration
{
  public static class AppYearRepositoryConstants
    {
      public const string SP_Insert = "AppYearInsert";
      public const string SP_Update = "AppYearUpdate";
      public const string SP_Delete = "AppYearDelete";
      public const string SP_FindByID = "AppYearFindByID";
      public const string SP_FindAll = "AppYearFindAll";

      public const string ID = CommonConstants.PreParameter + AppYearConstants.ID;
      public const string Year = CommonConstants.PreParameter + AppYearConstants.Year;
      public const string Quarter = CommonConstants.PreParameter + AppYearConstants.Quarter;
    }
}
