using FSP.Common.Entites.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Windows.UICommon
{
  public static class UISecurity
    {
        private static User userEntity;

        public static User UserEntity
        {
            get { return UISecurity.userEntity; }
            set { UISecurity.userEntity = value; }
        }

      public static bool IsHasPermission(List<Permission>permissionList ,string permissionName)
      {
          var per = from z in permissionList where z.Name == permissionName select z;
          List<Permission> permissons = per.ToList<Permission>();
          if (permissons.Count == 0)
              return false;
          else return true;
      }

      public static bool IsHasAccessList(List<AccessList> accessList, string accessListName)
      {
          var access = from z in accessList where z.Name == accessListName select z;
          List<AccessList> acs = access.ToList<AccessList>();
          if (acs.Count == 0)
              return false;
          else return true;
      }
    }
}
