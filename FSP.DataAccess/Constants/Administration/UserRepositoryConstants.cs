using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Administration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Administration
{
   public static class UserRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + UserConstants.ID;
       public const string Username = CommonConstants.PreParameter + UserConstants.Username;
       public const string Password = CommonConstants.PreParameter + UserConstants.Password;
       public const string FullName = CommonConstants.PreParameter + UserConstants.FullName;
       public const string Group = CommonConstants.PreParameter + UserConstants.Group;
       public const string Phone = CommonConstants.PreParameter + UserConstants.Phone;
       public const string Email = CommonConstants.PreParameter + UserConstants.Email;

       public const string SP_Insert = "UsersInsert";
       public const string SP_Update = "UsersUpdate";
       public const string SP_Delete = "UsersDelete";
       public const string SP_FindAll = "UsersFindAll";
       public const string SP_FindByID = "UsersFindByID";
       public const string SP_CheckUserLogin = "UsersCheckLogin";
    }
}
