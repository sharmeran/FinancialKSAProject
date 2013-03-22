using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Administration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Administration
{
   public static class PermissionRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + PermissionConstants.ID;
       public const string Name = CommonConstants.PreParameter + PermissionConstants.Name;
       public const string Description = CommonConstants.PreParameter + PermissionConstants.Description;

       public const string SP_Insert = "PermissionsInsert";
       public const string SP_Update = "PermissionsUpdate";
       public const string SP_Delete = "PermissionsDelete";
       public const string SP_FindAll = "PermissionsFindAll";
       public const string SP_FindByID = "PermissionsFindByID";
    }
}
