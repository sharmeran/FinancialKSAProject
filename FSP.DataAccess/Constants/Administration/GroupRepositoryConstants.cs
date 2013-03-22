using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Administration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Administration
{
   public static class GroupRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + GroupConstants.ID;
       public const string Name = CommonConstants.PreParameter + GroupConstants.Name;
       public const string Description = CommonConstants.PreParameter + GroupConstants.Description;
       public const string GroupID = CommonConstants.PreParameter + GroupConstants.GroupID;
       public const string AccessListID = CommonConstants.PreParameter + GroupConstants.AccessListID;
       public const string PermissionID = CommonConstants.PreParameter + GroupConstants.PermissionID;


       public const string SP_Insert = "GroupsInsert";
       public const string SP_Delete = "GroupsDelete";
       public const string SP_Update = "GroupsUpdate";
       public const string SP_FindAll = "GroupsFindAll";
       public const string SP_FindByID = "GroupsFindByID";
       public const string GroupAccessListInsert = "GroupsAccessListInsert";
       public const string GroupAccessListDelete = "GroupsAccessListDelete";
       public const string GroupAccessListFind = "GroupsAccessListFindByGroupID";
       public const string GroupPermissionInsert = "GroupPermissionInsert";
       public const string GroupPermissionDelete = "GroupPermissionsDelete";
       public const string GroupPermissionFind = "GroupPermissionsFindByGroupID";



    }
}
