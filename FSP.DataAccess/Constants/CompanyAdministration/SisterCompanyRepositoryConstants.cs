using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.CompanyAdministration
{
   public static class SisterCompanyRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + SisterCompanyConstants.ID;
       public const string Name = CommonConstants.PreParameter + SisterCompanyConstants.Name;
       public const string Description = CommonConstants.PreParameter + SisterCompanyConstants.Description;
       public const string NameEnglish = CommonConstants.PreParameter + SisterCompanyConstants.NameEnglish;
       public const string DescriptionEnglish = CommonConstants.PreParameter + SisterCompanyConstants.DescriptionEnglish;
       public const string Place = CommonConstants.PreParameter + SisterCompanyConstants.Place;
       public const string PlaceEnglish = CommonConstants.PreParameter + SisterCompanyConstants.PlaceEnglish;
       public const string EstablishDate = CommonConstants.PreParameter + SisterCompanyConstants.EstablishDate;
       public const string Company = CommonConstants.PreParameter + SisterCompanyConstants.Company;
       public const string IsOutKsa = CommonConstants.PreParameter + SisterCompanyConstants.IsOutKsa;
       public const string Sector = CommonConstants.PreParameter + SisterCompanyConstants.Sector;
       public const string OwnPercentage = CommonConstants.PreParameter + SisterCompanyConstants.OwnPercentage;

       public const string SP_Insert = "SisterCompanyInsert";
       public const string SP_Delete = "SisterCompanyDelete";
       public const string SP_Update = "SisterCompanyUpdate";
       public const string SP_FindAll = "SisterCompanyFindAll";
       public const string SP_FindByID = "SisterCompanyFindByID";
       public const string SP_FindByCompanyID = "SisterCompanyFindByCompanyID";
    }
}
