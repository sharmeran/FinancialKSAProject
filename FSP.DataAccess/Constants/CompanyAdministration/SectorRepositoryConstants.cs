using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.CompanyAdministration
{
   public static class SectorRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + SectorConstants.ID;
       public const string Name = CommonConstants.PreParameter + SectorConstants.Name;
       public const string Description= CommonConstants.PreParameter + SectorConstants.Description;
       public const string NameEnglish = CommonConstants.PreParameter + SectorConstants.NameEnglish;
       public const string DescriptionEnglish = CommonConstants.PreParameter + SectorConstants.DescriptionEnglish;

       public const string SP_Insert = "SectorsInsert";
       public const string SP_Delete = "SectorsDelete";
       public const string SP_Update = "SectorsUpdate";
       public const string SP_FindAll = "SectorsFindAll";
       public const string SP_FindByID = "SectorsFindByID";
    }
}
