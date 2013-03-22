using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.CompanyAdministration
{
   public static class BehaviourRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + BehaviourConstants.ID;
       public const string Name = CommonConstants.PreParameter + BehaviourConstants.Name;
       public const string Description = CommonConstants.PreParameter + BehaviourConstants.Description;
       public const string Judgment = CommonConstants.PreParameter + BehaviourConstants.JudgmentID;
       public const string NameEnglish = CommonConstants.PreParameter + BehaviourConstants.NameEnglish;
       public const string DescriptionEnglish = CommonConstants.PreParameter + BehaviourConstants.DescriptionEnglish;

       public const string CompanyID = "@CompanyID";
       public const string BehaviourID = "@BehaviourID";
       

       public const string SP_Insert = "BehavioursInsert";
       public const string SP_Update = "BehavioursUpdate";
       public const string SP_Delete = "BehavioursDelete";
       public const string SP_FindAll = "BehavioursFindAll";
       public const string SP_FindByID = "BehavioursFindByID";
       public const string SP_FindByCompanyID = "CompanyBehavioursFindByCompanyID";
       public const string SP_InsertCompanyBehaviour = "CompanyBehavioursInsert";
       public const string SP_DeleteCompanyBehaviourByCompanyID = "CompanyBehavioursDeleteByCompanyID";

    }
}
