using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;
using FSP.Common.Entites.CompanyAdministration;
using FSP.Common.Entites.Administration;

namespace FSP.Common.Entites.Financial
{
    public class CompanyFinancialModel:BaseClass
    {
        int iD;
        int companyID;
        int year;
        int userID;
        DateTime createdDate;
        int reviewedUserID;
        bool isApproved;
        bool isReviewed;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public bool IsReviewed
        {
            get { return isReviewed; }
            set { isReviewed = value; }
        }

        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public int ReviewedUserID
        {
            get { return reviewedUserID; }
            set { reviewedUserID = value; }
        }

        public bool IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }

        Company company;

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        User reviewedUser;

        public User ReviewedUser
        {
            get { return reviewedUser; }
            set { reviewedUser = value; }
        }
    }
}
