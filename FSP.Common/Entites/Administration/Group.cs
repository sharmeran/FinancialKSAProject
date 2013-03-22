using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Administration
{
   public class Group : BaseClass
    {
        int iD;
        string name;
        string description;
        List<AccessList> accessList;
        List<Permission> permissions;

        public List<Permission> Permissions
        {
            get { return permissions; }
            set { permissions = value; }
        }

        public List<AccessList> AccessList
        {
            get { return accessList; }
            set { accessList = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
