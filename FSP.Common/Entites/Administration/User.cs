using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Administration
{
   public class User : BaseClass
    {
        int iD;
        string username;
        string password;
        string fullName;
        Group group;
        string phone;
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Group Group
        {
            get { return group; }
            set { group = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
