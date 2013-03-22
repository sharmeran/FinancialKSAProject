using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.CompanyAdministration
{
   public static class BehaviorJudgmentRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + BehaviorJudgmentConstants.ID;
       public const string Name = CommonConstants.PreParameter + BehaviorJudgmentConstants.Name;
       public const string Description = CommonConstants.PreParameter + BehaviorJudgmentConstants.Description;
       public const string NameEnglish = CommonConstants.PreParameter + BehaviorJudgmentConstants.NameEnglish;
       public const string DescriptionEnglish = CommonConstants.PreParameter + BehaviorJudgmentConstants.DescriptionEnglish;
       public const string Value = CommonConstants.PreParameter + BehaviorJudgmentConstants.Value;


       public const string SP_Insert = "BehaviorJudgmentInsert";
       public const string SP_Update = "BehaviorJudgmentUpdate";
       public const string SP_Delete = "BehaviorJudgmentDelete";
       public const string SP_FindAll = "BehaviorJudgmentFindAll";
       public const string SP_FindByID = "BehaviorJudgmentFindByID";

    }
}
