using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.CompanyAdministration
{
   public static class CompanyRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + CompanyConstants.ID;
       public const string Name = CommonConstants.PreParameter + CompanyConstants.Name;
       public const string Description = CommonConstants.PreParameter + CompanyConstants.Description;
       public const string EstablishDate = CommonConstants.PreParameter + CompanyConstants.EstablishDate;
       public const string Information = CommonConstants.PreParameter + CompanyConstants.Information;
       public const string Sector = CommonConstants.PreParameter + CompanyConstants.SectorID;
       public const string NameEnglish = CommonConstants.PreParameter + CompanyConstants.NameEnglish;
       public const string DescriptionEnglish = CommonConstants.PreParameter + CompanyConstants.DescriptionEnglish;
       public const string InformationEnglish = CommonConstants.PreParameter + CompanyConstants.InformationEnglish;
       public const string Capital = CommonConstants.PreParameter + CompanyConstants.Capital;
       public const string WithLimitedLiability = CommonConstants.PreParameter + CompanyConstants.WithLimitedLiability;
       public const string ClosedJointStockCompany = CommonConstants.PreParameter + CompanyConstants.ClosedJointStockCompany;
       public const string IPO = CommonConstants.PreParameter + CompanyConstants.IPO;
       public const string GeneralCompany = CommonConstants.PreParameter + CompanyConstants.GeneralCompany;
       public const string Rank = CommonConstants.PreParameter + CompanyConstants.Rank;
       public const string Behavior = CommonConstants.PreParameter + CompanyConstants.Behavior;

       public const string SP_Insert = "CompaniesInsert";
       public const string SP_Update = "CompaniesUpdate";
       public const string SP_Delete = "CompaniesDelete";
       public const string SP_FindAll = "CompaniesFindAll";
       public const string SP_FindByID = "CompaniesFindByID";
    }
}
