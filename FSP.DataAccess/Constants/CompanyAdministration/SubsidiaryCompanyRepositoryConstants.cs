using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.CompanyAdministration
{
   public static class SubsidiaryCompanyRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + SubsidiaryCompanyConstants.ID;
       public const string Name = CommonConstants.PreParameter + SubsidiaryCompanyConstants.Name;
       public const string Description = CommonConstants.PreParameter + SubsidiaryCompanyConstants.Description;
       public const string NameEnglish = CommonConstants.PreParameter + SubsidiaryCompanyConstants.NameEnglish;
       public const string DescriptionEnglish = CommonConstants.PreParameter + SubsidiaryCompanyConstants.DescriptionEnglish;
       public const string FollowDate = CommonConstants.PreParameter + SubsidiaryCompanyConstants.FollowDate;
       public const string Place = CommonConstants.PreParameter + SubsidiaryCompanyConstants.Place;
       public const string PlaceEnglish = CommonConstants.PreParameter + SubsidiaryCompanyConstants.PlaceEnglish;
       public const string OwnPercentage = CommonConstants.PreParameter + SubsidiaryCompanyConstants.OwnPercentage;
       public const string Note = CommonConstants.PreParameter + SubsidiaryCompanyConstants.Note;
       public const string NoteEnglish = CommonConstants.PreParameter + SubsidiaryCompanyConstants.NoteEnglish;
       public const string CompanyID = CommonConstants.PreParameter + SubsidiaryCompanyConstants.CompanyID;
       public const string IsOutKSA = CommonConstants.PreParameter + SubsidiaryCompanyConstants.IsOutKSA;
       public const string EstablishDate = CommonConstants.PreParameter + SubsidiaryCompanyConstants.EstablishDate;
       public const string Sector = CommonConstants.PreParameter + SubsidiaryCompanyConstants.Sector;

       public const string SP_Insert = "SubsidiaryCompanyInsert";
       public const string SP_Delete = "SubsidiaryCompanyDelete";
       public const string SP_Update = "SubsidiaryCompanyUpdate";
       public const string SP_FindAll = "SubsidiaryCompanyFindAll";
       public const string SP_FindByID = "SubsidiaryCompanyFindByID";
       public const string SP_FindByCompanyID = "SubsidiaryCompanyFindCompanyID";
    }
}
